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

        public async Task<IEnumerable<FantasyLeagueStandings>> GetStandingsByLeague(FantasyLeague fantasyLeague)
        {
            var standing = await _context.FantasyLeagueStandings
                .Include(x => x.FantasyLeagueNav)
                .Include(x => x.MyTeamNav)
                .Where(x => x.FantasyLeagueID == fantasyLeague.FantasyLeagueID)
                .AsNoTracking().ToListAsync();
            return standing;
        }

        public async Task<bool> Create(FantasyLeague fantasyLeague)
        {
            var teams = fantasyLeague.TeamsNav;
            List<FantasyLeagueStandings> createdStandings = new List<FantasyLeagueStandings>();

            foreach(var t in teams)
            {
                FantasyLeagueStandings created = new FantasyLeagueStandings
                {
                    FantasyLeagueNav = fantasyLeague,
                    MyTeamNav = t,
                };
                createdStandings.Add(created);
            }
            try
            {
                await _context.AddRangeAsync(createdStandings);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



        public async Task<bool> UpdateStandings(IEnumerable<FantasyMatchup> matchups, int week)
        {
            var currentStandings = (await GetStandingsByLeague((matchups).ToList()[0].FantasyLeagueNav)).ToList();
            List<FantasyLeagueStandings> standingsUpdated = new List<FantasyLeagueStandings>();

            foreach (var m in matchups.Where(x => x.Week == week))
            {
                var homeStandings = currentStandings.Find(x => x.MyTeamID == m.HomeTeamID);

                var awayStandings = currentStandings.Find(x => x.MyTeamID == m.AwayTeamID);


                if (m.HomeTeamScore > m.AwayTeamScore)
                {
                    homeStandings.Wins = homeStandings.Wins++;
                    homeStandings.FantasyPoints += m.HomeTeamScore.Value;
                    homeStandings.FantasyPointsAgainst += m.AwayTeamScore.Value;

                    awayStandings.Losses = awayStandings.Losses++;
                    awayStandings.FantasyPoints += m.AwayTeamScore.Value;
                    awayStandings.FantasyPointsAgainst += m.HomeTeamScore.Value;
                }
                else if (m.HomeTeamScore < m.AwayTeamScore)
                {
                    homeStandings.Losses = homeStandings.Losses++;
                    homeStandings.FantasyPoints += m.HomeTeamScore.Value;
                    homeStandings.FantasyPointsAgainst += m.AwayTeamScore.Value;

                    awayStandings.Wins = awayStandings.Wins++;
                    awayStandings.FantasyPoints += m.AwayTeamScore.Value;
                    awayStandings.FantasyPointsAgainst += m.HomeTeamScore.Value;
                }
                else
                {
                    homeStandings.Draws = homeStandings.Draws++;
                    homeStandings.FantasyPoints += m.HomeTeamScore.Value;
                    homeStandings.FantasyPointsAgainst += m.AwayTeamScore.Value;

                    awayStandings.Draws = awayStandings.Draws++;
                    awayStandings.FantasyPoints += m.AwayTeamScore.Value;
                    awayStandings.FantasyPointsAgainst += m.HomeTeamScore.Value;
                }
                standingsUpdated.Add(homeStandings);
                standingsUpdated.Add(awayStandings);
            }
            try
            {
                _context.UpdateRange(standingsUpdated);

                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            catch (Exception)
            {
                return false;
            }
        }

        ////this mehto still isnt writing anything
        //public async Task<bool> UpdateStandings(FantasyLeague fantasyLeague, int week)
        //{
        //    var currentStandings = (await GetStandingsByLeague(fantasyLeague)).ToList();
        //    List<FantasyLeagueStandings> standingsUpdated = new List<FantasyLeagueStandings>();
            
        //    var matchupsToRecord = (await _fantasyMatchupService.GetMatchupsForRecording(fantasyLeague.FantasyLeagueID, week));

        //    foreach(var m in matchupsToRecord)
        //    {
        //        var homeStandings = currentStandings.Find(x => x.MyTeamID == m.HomeTeamID);
        //        var awayStandings = currentStandings.Find(x => x.MyTeamID == m.AwayTeamID);


        //        if (m.HomeTeamScore > m.AwayTeamScore)
        //        {
        //            homeStandings.Wins = homeStandings.Wins++;
        //            homeStandings.FantasyPoints += m.HomeTeamScore.Value;
        //            homeStandings.FantasyPointsAgainst += m.AwayTeamScore.Value;

        //            awayStandings.Losses = awayStandings.Losses++;
        //            awayStandings.FantasyPoints += m.AwayTeamScore.Value;
        //            awayStandings.FantasyPointsAgainst += m.HomeTeamScore.Value;
        //        }else if(m.HomeTeamScore < m.AwayTeamScore)
        //        {
        //            homeStandings.Losses = homeStandings.Losses++;
        //            homeStandings.FantasyPoints += m.HomeTeamScore.Value;
        //            homeStandings.FantasyPointsAgainst += m.AwayTeamScore.Value;

        //            awayStandings.Wins = awayStandings.Wins++;
        //            awayStandings.FantasyPoints += m.AwayTeamScore.Value;
        //            awayStandings.FantasyPointsAgainst += m.HomeTeamScore.Value;
        //        }
        //        else
        //        {
        //            homeStandings.Draws = homeStandings.Draws++;
        //            homeStandings.FantasyPoints += m.HomeTeamScore.Value;
        //            homeStandings.FantasyPointsAgainst += m.AwayTeamScore.Value;

        //            awayStandings.Draws = awayStandings.Draws++;
        //            awayStandings.FantasyPoints += m.AwayTeamScore.Value;
        //            awayStandings.FantasyPointsAgainst += m.HomeTeamScore.Value;
        //        }
        //        standingsUpdated.Add(homeStandings);
        //        standingsUpdated.Add(awayStandings);
        //    }
        //    try
        //    {
        //        _context.UpdateRange(standingsUpdated);
                
        //        await _context.SaveChangesAsync();
        //        return true;
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        throw;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}
    }
}
