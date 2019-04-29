using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Services
{
    public class MyTeamsService
    {
        private readonly ApplicationDbContext _context;
        private readonly DataService _dataService;
        private readonly FantasyLeagueService _fantasyLeagueService;

        public MyTeamsService(ApplicationDbContext context, DataService dataService, FantasyLeagueService fantasyLeagueService)
        {
            _context = context;
            _dataService = dataService;
            _fantasyLeagueService = fantasyLeagueService;
        }

        public async Task<IEnumerable<MyTeam>> GetMyTeamsByUserID(string id)
        {
            var myTeam = await _context.MyTeam
                .Include(t => t.FantasyLeagueNav)
                .Include(t => t.PlayerMyTeamNav)
                .Where(t => t.UserID == id)
                .ToListAsync();

            return myTeam;
        }

        public async Task<MyTeam> GetMyTeamByID(int myTeamID)
        {
            var myTeam = await _context.MyTeam
                .Include(m => m.PlayerMyTeamNav)
                .Include(m => m.UserNav)
                .Include(m => m.FantasyLeagueNav)
                .Where(m => m.MyTeamID == myTeamID)
                .AsNoTracking().FirstOrDefaultAsync();

            return myTeam;
        }

        public async Task<bool> Create(MyTeam myTeam)
        {
            var league = await _fantasyLeagueService.GetLeague(myTeam.FantasyLeagueID);
            if(league != null)
            {
                if (!league.IsFull)
                {
                    try
                    {
                        _context.Add(myTeam);
                        await _context.SaveChangesAsync();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public async Task<bool> Edit(MyTeam myTeam)
        {
            try
            {
                _context.Update(myTeam);
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

        public async Task<bool> Delete(MyTeam myTeam)
        {
            try
            {
                _context.MyTeam.Remove(myTeam);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
