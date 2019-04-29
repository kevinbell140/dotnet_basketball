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
        private readonly DataService _dataService;
        private readonly UserManager<ApplicationUser> _userManager;

        public FantasyLeagueService(ApplicationDbContext context, DataService dataService, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _dataService = dataService;
            _userManager = userManager;
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
                .FirstOrDefaultAsync(m => m.FantasyLeagueID == id);
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
    }
}
