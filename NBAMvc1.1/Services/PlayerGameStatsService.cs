using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using NBAMvc1._1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Services
{
    public class PlayerGameStatsService : IPlayerGameStatsService
    {
        private readonly ApplicationDbContext _context;
        private readonly IDataService _dataService;
        private readonly ILogger _logger;

        public PlayerGameStatsService(ApplicationDbContext context, IDataService dataService,
            ILogger<PlayerGameStatsService> logger)
        {
            _context = context;
            _dataService = dataService;
            _logger = logger;
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

        public async Task<List<PlayerGameStats>> GetGameLeadersAsync(int gameID)
        {
            var leaders = await _context.PlayerGameStats
               .Include(p => p.GameNav)
               .Include(p => p.PlayerNav)
               .Where(p => p.GameID == gameID)
               .OrderByDescending(p => p.Points)
               .Take(2).ToListAsync();

            return leaders;
        }

        public async Task FetchAsync()
        {
            //DateTime startDate = DateTime.Today.AddDays(-1);
            DateTime startDate = _context.PlayerGameStats.Max(x => x.TimeStamp);
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
                            _logger.LogDebug("Added game log to created list");
                        }
                    }
                    else
                    {
                        if (await PlayerAndGameExist(p.PlayerID, p.GameID))
                        {
                            updated.Add(p);
                            _logger.LogDebug("Added game log to updated list");
                        }
                    }
                }
            }
            try
            {
                await _context.AddRangeAsync(created);
                _context.UpdateRange(updated);
                _logger.LogDebug("Attempting to save to the database");
                await _context.SaveChangesAsync();
                _logger.LogDebug("Saved logs to database");
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