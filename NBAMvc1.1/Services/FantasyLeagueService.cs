using Microsoft.EntityFrameworkCore;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using NBAMvc1._1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Services
{
    public class FantasyLeagueService : IFantasyLeagueService
    {
        private readonly ApplicationDbContext _context;

        public FantasyLeagueService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FantasyLeague>> GetLeaguesAsync()
        {
            var leagues = await _context.FantasyLeague
                .ToListAsync();
            return leagues;
        }

        public async Task<FantasyLeague> GetLeagueAsync(int id)
        {
            var fantasyLeague = await _context.FantasyLeague
                .Include(m => m.TeamsNav).ThenInclude(m => m.UserNav)
                .Include(m => m.TeamsNav).ThenInclude(m => m.FantasyLeagueStandingsNav)
                .Include(m => m.ComissionerNav)
                .Include(m => m.FantasyMatchupWeeksNav)
                .Where(m => m.FantasyLeagueID == id)
                .FirstOrDefaultAsync();
            return fantasyLeague;
        }

        public async Task Create(FantasyLeague fantasyLeague)
        {
            _context.Add(fantasyLeague);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task Edit(FantasyLeague fantasyLeague)
        {
            try
            {
                _context.Update(fantasyLeague);
                await _context.SaveChangesAsync();
                return;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task Delete(int id)
        {
            var fantasyLeague = await _context.FantasyLeague.FindAsync(id);
            try
            {
                _context.FantasyLeague.Remove(fantasyLeague);
                await _context.SaveChangesAsync();
                return;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task<bool> FantasyLeagueExists(int id)
        {
            return await _context.FantasyLeague.AnyAsync(e => e.FantasyLeagueID == id);
        }

        public async Task IsActiveFalseAsync(FantasyLeague fantasyLeague)
        {
            fantasyLeague.IsActive = false;
            try
            {
                _context.Update(fantasyLeague);
                await _context.SaveChangesAsync();
                return;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task<Dictionary<int, MyTeam>> GetTeamsDictionaryAsync(int leagueID)
        {
            int count = 1;
            var league = await GetLeagueAsync(leagueID);
            if (league != null)
            {
                try
                {
                    return league.TeamsNav.OrderByDescending(x => x.FantasyLeagueStandingsNav.WinPercent).ToDictionary(x => count++, x => x);
                }
                catch (Exception)
                {
                    try
                    {
                        return league.TeamsNav.ToDictionary(x => count++, x => x);
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
            return null;
        }

        public async Task AddTeamConfirm(int id)
        {
            var league = await GetLeagueAsync(id);
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
                return;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task RemoveTeamConfirm(int id)
        {
            var league = await GetLeagueAsync(id);
            league.IsFull = false;
            league.IsSet = false;

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
        }

        public async Task UpdateCurrentWeekAsync(FantasyLeague fantasyLeague, int week)
        {
            fantasyLeague.CurrentWeek = week;
            try
            {
                _context.Update(fantasyLeague);
                await _context.SaveChangesAsync();
                return;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task SetLeagueAsync(FantasyLeague fantasyLeague)
        {
            fantasyLeague.IsSet = true;
            fantasyLeague.IsActive = true;
            fantasyLeague.CurrentWeek = 1;
            try
            {
                _context.Update(fantasyLeague);
                await _context.SaveChangesAsync();
                return;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
