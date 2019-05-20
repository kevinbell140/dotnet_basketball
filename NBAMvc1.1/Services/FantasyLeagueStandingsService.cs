using Microsoft.EntityFrameworkCore;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Services
{
    public class FantasyLeagueStandingsService
    {
        private readonly ApplicationDbContext _context;

        public FantasyLeagueStandingsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FantasyLeagueStandings>> GetStandings()
        {
            var standings = await _context.FantasyLeagueStandings
                .Include(x => x.FantasyLeagueNav)
                .Include(x => x.MyTeamNav)
                .ToListAsync();
            return standings;
        }

        public async Task<IEnumerable<FantasyLeagueStandings>> GetStandingsActive()
        {
            var standings = await _context.FantasyLeagueStandings
                .Include(x => x.FantasyLeagueNav)
                .Include(x => x.MyTeamNav)
                .Where(x => x.FantasyLeagueNav.IsActive && x.FantasyLeagueNav.IsSet)
                .ToListAsync();
            return standings;
        }

        public async Task Create(FantasyLeague fantasyLeague)
        {
            var teams = fantasyLeague.TeamsNav;
            List<FantasyLeagueStandings> createdStandings = new List<FantasyLeagueStandings>();

            foreach (var t in teams)
            {
                FantasyLeagueStandings created = new FantasyLeagueStandings
                {
                    FantasyLeagueNav = fantasyLeague,
                    MyTeamNav = t,
                };
                createdStandings.Add(created);
            }
            await _context.AddRangeAsync(createdStandings);
            await _context.SaveChangesAsync();
            return;
        }
        private async Task<FantasyLeagueStandings> GetStandingsByTeam(int teamID)
        {
            var standing = await _context.FantasyLeagueStandings
                .Include(x => x.FantasyLeagueNav)
                .Include(x => x.MyTeamNav)
                .Where(x => x.MyTeamID == teamID)
                .AsNoTracking().FirstOrDefaultAsync();
            return standing;
        }

        private async Task<IEnumerable<FantasyMatchup>> GetMatchupsForRecording()
        {
            var matchups = await _context.FantasyMatchup
                    .Include(m => m.AwayTeamNav).ThenInclude(x => x.FantasyLeagueStandingsNav)
                    .Include(m => m.HomeTeamNav).ThenInclude(x => x.FantasyLeagueStandingsNav)
                    .Where(m => m.Status == "Final" && !m.Recorded)
                    .AsNoTracking().ToListAsync();

            return matchups;
        }

        public async Task UpdateGamesBack()
        {
            var standings = await GetStandingsActive();
            var leagues = standings.Select(x => x.FantasyLeagueNav).Distinct();

            foreach(var l in leagues)
            {
                //TODO : calculate GB for each league
            }
        }

        public async Task<List<FantasyMatchup>> UpdateStandings()
        {
            List<FantasyLeagueStandings> standingsUpdated = new List<FantasyLeagueStandings>();
            List<FantasyMatchup> matchupsUpdated = new List<FantasyMatchup>();
            
            //all matchups that need updating
            var matchups = await GetMatchupsForRecording();
            matchups = matchups.Where(x => x.HomeTeamNav.FantasyLeagueStandingsNav != null && x.AwayTeamNav.FantasyLeagueStandingsNav != null).ToList();
            var homeTeamIDs = matchups.Select(x => x.HomeTeamID).Distinct();
            var awayTeamsIDs = matchups.Select(x => x.AwayTeamID).Distinct();
            var teamIDs = homeTeamIDs.Union(awayTeamsIDs);

            //get standings dictionary
            Dictionary<int, FantasyLeagueStandings> currentStandings = new Dictionary<int, FantasyLeagueStandings>();
            
            foreach (var id in teamIDs)
            {
                var standing = await GetStandingsByTeam(id.Value);
                if(standing != null)
                {
                    currentStandings.Add(id.Value, standing);
                }
            }

            foreach (var m in matchups)
            {
                if (m.HomeTeamScore > m.AwayTeamScore)
                {
                    currentStandings[m.HomeTeamID.Value].Wins++;
                    currentStandings[m.HomeTeamID.Value].FantasyPoints += m.HomeTeamScore.Value;
                    currentStandings[m.HomeTeamID.Value].FantasyPointsAgainst += m.AwayTeamScore.Value;
                    currentStandings[m.HomeTeamID.Value].UpdatedAt = DateTime.Now;

                    currentStandings[m.AwayTeamID.Value].Losses++;
                    currentStandings[m.AwayTeamID.Value].FantasyPoints += m.AwayTeamScore.Value;
                    currentStandings[m.AwayTeamID.Value].FantasyPointsAgainst += m.HomeTeamScore.Value;
                    currentStandings[m.AwayTeamID.Value].UpdatedAt = DateTime.Now;
                }
                else if (m.HomeTeamScore < m.AwayTeamScore)
                {
                    currentStandings[m.HomeTeamID.Value].Losses++;
                    currentStandings[m.HomeTeamID.Value].FantasyPoints += m.HomeTeamScore.Value;
                    currentStandings[m.HomeTeamID.Value].FantasyPointsAgainst += m.AwayTeamScore.Value;
                    currentStandings[m.HomeTeamID.Value].UpdatedAt = DateTime.Now;

                    currentStandings[m.AwayTeamID.Value].Wins++;
                    currentStandings[m.AwayTeamID.Value].FantasyPoints += m.AwayTeamScore.Value;
                    currentStandings[m.AwayTeamID.Value].FantasyPointsAgainst += m.HomeTeamScore.Value;
                    currentStandings[m.AwayTeamID.Value].UpdatedAt = DateTime.Now;
                }
                else
                {
                    currentStandings[m.HomeTeamID.Value].Draws++;
                    currentStandings[m.HomeTeamID.Value].FantasyPoints += m.HomeTeamScore.Value;
                    currentStandings[m.HomeTeamID.Value].FantasyPointsAgainst += m.AwayTeamScore.Value;
                    currentStandings[m.HomeTeamID.Value].UpdatedAt = DateTime.Now;

                    currentStandings[m.AwayTeamID.Value].Draws++;
                    currentStandings[m.AwayTeamID.Value].FantasyPoints += m.AwayTeamScore.Value;
                    currentStandings[m.AwayTeamID.Value].FantasyPointsAgainst += m.HomeTeamScore.Value;
                    currentStandings[m.AwayTeamID.Value].UpdatedAt = DateTime.Now;
                }
            }
            standingsUpdated = currentStandings.Values.ToList();
            try
            {
                _context.UpdateRange(standingsUpdated);
                await _context.SaveChangesAsync();
                return matchups.ToList();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
