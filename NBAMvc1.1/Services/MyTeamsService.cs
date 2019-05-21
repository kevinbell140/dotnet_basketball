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
    public class MyTeamsService : IMyTeamsService
    {
        private readonly ApplicationDbContext _context;
        private readonly IFantasyLeagueService _fantasyLeagueService;

        public MyTeamsService(ApplicationDbContext context, IFantasyLeagueService fantasyLeagueService)
        {
            _context = context;
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

        public async Task<MyTeam> GetMyTeamByIDAsync(int myTeamID)
        {
            var myTeam = await _context.MyTeam
                .Include(m => m.PlayerMyTeamNav)
                .Include(m => m.UserNav)
                .Include(m => m.FantasyLeagueNav)
                .Where(m => m.MyTeamID == myTeamID)
                .AsNoTracking().FirstOrDefaultAsync();

            return myTeam;
        }

        public async Task<List<MyTeam>> GetMyTeamsByLeague(int leagueID)
        {
            var myTeam = await _context.MyTeam
                .Include(m => m.PlayerMyTeamNav)
                .Include(m => m.UserNav)
                .Include(m => m.FantasyLeagueNav)
                .Include(m => m.HomeMatchupNav)
                .Include(m => m.AwayMatchupNav)
                .Where(m => m.FantasyLeagueID == leagueID)
                .AsNoTracking().ToListAsync();

            return myTeam;
        }

        public async Task Create(MyTeam myTeam)
        {
            var league = await _fantasyLeagueService.GetLeagueAsync(myTeam.FantasyLeagueID);
            if (league != null)
            {
                if (!league.IsFull)
                {
                    _context.Add(myTeam);
                    await _context.SaveChangesAsync();
                    await _fantasyLeagueService.AddTeamConfirm(myTeam.FantasyLeagueID);
                }
            }
        }

        public async Task Edit(MyTeam myTeam)
        {
            try
            {
                _context.Update(myTeam);
                await _context.SaveChangesAsync();
                return;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task Delete(MyTeam myTeam)
        {
            _context.MyTeam.Remove(myTeam);
            await _context.SaveChangesAsync();
            await _fantasyLeagueService.RemoveTeamConfirm(myTeam.FantasyLeagueID);
            return;
        }
    }
}
