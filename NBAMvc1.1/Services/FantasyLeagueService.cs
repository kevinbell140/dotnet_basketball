using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NBAMvc1._1.Areas.Identity;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NBAMvc1._1.Services
{
    public class FantasyLeagueService
    {
        private readonly ApplicationDbContext _context;
        private readonly FantasyMatchupService _fantasyMatchupService;

        public FantasyLeagueService(ApplicationDbContext context, FantasyMatchupService fantasyMatchupService)
        {
            _context = context;
            _fantasyMatchupService = fantasyMatchupService;
        }
        public async Task<IEnumerable<FantasyLeague>> GetLeagues()
        {
            var leagues = await _context.FantasyLeague
                .ToListAsync();

            return leagues;
        }

        public async Task<FantasyLeague> GetLeague(int id)
        {
            var fantasyLeague = await _context.FantasyLeague
                .Include(m => m.TeamsNav).ThenInclude(m => m.UserNav)
                .Include(m => m.ComissionerNav)
                .Include(m => m.FantasyMatchupWeeksNav)
                .Where(m => m.FantasyLeagueID == id)
                .FirstOrDefaultAsync();
            return fantasyLeague;
        }

        public async Task<bool> Create(FantasyLeague fantasyLeague)
        {
            try
            {
                _context.Add(fantasyLeague);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Edit(FantasyLeague fantasyLeague)
        {
            try
            {
                _context.Update(fantasyLeague);
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

        public async Task<bool> Delete(int id)
        {
            var fantasyLeague = await _context.FantasyLeague.FindAsync(id);
            try
            {       
                _context.FantasyLeague.Remove(fantasyLeague);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> FantasyLeagueExists(int id)
        {
            return await _context.FantasyLeague.AnyAsync(e => e.FantasyLeagueID == id);
        }

        public async void IsActiveFalseAsync(int id)
        {
            var league = await GetLeague(id);
            if(league != null)
            {
                league.IsActive = false;
                try
                {
                    _context.Update(league);
                    await _context.SaveChangesAsync();
                    return;
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        public async Task<Dictionary<int, MyTeam>> GetTeamsDictionary(int leagueID)
        {
            int count = 1;
            var league = await GetLeague(leagueID);
            if(league != null)
            {
                var teams = league.TeamsNav.ToDictionary(x => count++, x => x);
                return teams;
            }
            return null;
        }

        public async Task<bool> AddTeamConfirm(int id)
        {
            var league = await GetLeague(id);
            if(league == null)
            {
                return false;
            }

            if (league.TeamsNav.Count() < 8)
            {
                league.IsFull = false;
            }
            else
            {
                league.IsFull = true;
            }

            try
            {
                _context.Update(league);
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

        public async Task<bool> RemoveTeamConfirm(int id)
        {
            var league = await GetLeague(id);
            if(league == null)
            {
                return false;
            }
            league.IsFull = false;
            league.IsSet = false;

            try
            {
                _context.Update(league);
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

        public async Task<bool> IsSetConfirm(int id)
        {
            var league = await GetLeague(id);
            if(league == null)
            {
                return false;
            }
            league.IsSet = true;
            league.IsActive = true;

            try
            {
                _context.Update(league);
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

        public async Task<bool> UpdateMatchups(IEnumerable<FantasyMatchup> matchups, int currentWeek)
        {
            List<FantasyMatchup> updateList = new List<FantasyMatchup>();

            foreach (var m in matchups)
            {
                updateList = await UpdateMatchup(m, currentWeek, updateList);
            }
            try
            {
                _context.UpdateRange(updateList);
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

        private async Task<List<FantasyMatchup>> UpdateMatchup(FantasyMatchup matchup, int currentWeek, List<FantasyMatchup> updateList)
        {
            if (matchup.Week < currentWeek)
            {
                matchup.Status = "Final";
            }
            else
            {
                matchup.Status = "In Progress";
            }

            var scores = await _fantasyMatchupService.CalculateScore(matchup);
            matchup.HomeTeamScore = scores[0];
            matchup.AwayTeamScore = scores[1];

            updateList.Add(matchup);
            return updateList;
        }
    }
}
