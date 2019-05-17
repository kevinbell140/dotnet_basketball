using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Services
{
    public class PlayerGameStatsService
    {
        private readonly ApplicationDbContext _context;
        private readonly DataService _dataService;

        public PlayerGameStatsService(ApplicationDbContext context, DataService dataService)
        {
            _context = context;
            _dataService = dataService;
        }

        public async Task<IEnumerable<PlayerGameStats>> GetPlayerGameStats()
        {
            var stats = await _context.PlayerGameStats
                .ToListAsync();
            return stats;
        }

        public async Task<PlayerGameStats> GetPlayerGameStatsByGameAsync(int playerID, int gameID)
        {
            var log = await _context.PlayerGameStats
                .Include(a => a.PlayerNav)
                .Include(a => a.GameNav)
                .Where(a => a.GameNav.GameID == gameID && a.PlayerNav.PlayerID == playerID)
                .FirstOrDefaultAsync();
            return log;
        }

        public async Task<List<PlayerGameStats>> GetGameLeadersAsync(int id)
        {
            var leaders = await _context.PlayerGameStats
               .Include(p => p.GameNav)
               .Include(p => p.PlayerNav)
               .Where(p => p.GameID == id)
               .OrderByDescending(p => p.Points)
               .Take(2).ToListAsync();

            return leaders;
        }

        public async Task FetchAsync()
        {
            DateTime startDate = new DateTime(2019, 04, 10);
            DateTime endDate = DateTime.Today;

            List<PlayerGameStats> created = new List<PlayerGameStats>();
            List<PlayerGameStats> updated = new List<PlayerGameStats>();

            for (DateTime d = startDate; d <= endDate; d = d.AddDays(1))
            {
                List<PlayerGameStats> stats = await _dataService.FetchGameStatsAsync(d.ToString("yyyy-MMM-dd"));
                foreach (var p in stats)
                {
                    if (!await PlayerGameStatsExist(p.StatID))
                    {
                        if (await PlayerAndGameExist(p.PlayerID, p.GameID))
                        {
                            created.Add(p);
                        }
                    }
                    else
                    {
                        if (await PlayerAndGameExist(p.PlayerID, p.GameID))
                        {
                            updated.Add(p);
                        }
                    }
                }
            }
            try
            {
                await _context.AddRangeAsync(created);
                _context.UpdateRange(updated);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        private async Task<bool> PlayerGameStatsExist(int id)
        {
            return await _context.PlayerGameStats.AnyAsync(s => s.StatID == id);
        }
        
        private async Task<bool> PlayerAndGameExist(int playerID, int gameID)
        {
            return (await _context.Player.AnyAsync(a => a.PlayerID == playerID) && await _context.Game.AnyAsync(a => a.GameID == gameID));
        }
    }
}