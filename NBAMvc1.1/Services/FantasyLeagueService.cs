using Microsoft.EntityFrameworkCore;
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

        public FantasyLeagueService(ApplicationDbContext context)
        {
            _context = context;
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

        public async Task<bool> IsActiveFalseAsync(FantasyLeague fantasyLeague)
        {
            fantasyLeague.IsActive = false;
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

        public async Task<bool> UpdateCurrentWeek(FantasyLeague fantasyLeague, int week)
        {
            fantasyLeague.CurrentWeek = week;
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

        public async Task<bool> StandingsRecorded(IEnumerable<FantasyMatchup> matchups, int week)
        {
            List<FantasyMatchup> updatedMatchups = new List<FantasyMatchup>();

            foreach (var m in matchups.Where(x => x.Week == week))
            {
                m.Recorded = true;
                updatedMatchups.Add(m);
            }
            try
            {
                _context.UpdateRange(updatedMatchups);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }
    }
}
