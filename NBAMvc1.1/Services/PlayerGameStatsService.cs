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

        public async Task<PlayerGameStats> GetPlayerGameStatsByGame(int playerID, int gameID)
        {
            var log = await _context.PlayerGameStats
                    .Where(a => a.GameNav.GameID == gameID && a.PlayerNav.PlayerID == playerID)
                    .FirstOrDefaultAsync();
            return log;
        }

        public async Task<bool> Fetch()
        {
            DateTime startDate = new DateTime(2019, 04, 24);
            DateTime endDate = DateTime.Today;

            List<PlayerGameStats> created = new List<PlayerGameStats>();
            List<PlayerGameStats> updated = new List<PlayerGameStats>();

            for (DateTime d = startDate; d <= endDate; d = d.AddDays(1))
            {
                List<PlayerGameStats> stats = await _dataService.FetchGamesStats(d.ToString("yyyy-MMM-dd"));
                foreach (var p in stats)
                {
                    if (!await PlayerGameStatsExist(p.StatID))
                    {
                        var createdStat = Create(p);
                        if (createdStat != null)
                        {
                            created.Add(await createdStat);
                        }
                    }
                    else
                    {
                        var editedStat = Edit(p.StatID, p);
                        if (editedStat != null)
                        {
                            updated.Add(await editedStat);
                        }
                    }
                }
            }
            try
            {
                await _context.AddRangeAsync(created);
                _context.UpdateRange(updated);
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

        private async Task<bool> PlayerGameStatsExist(int id)
        {
            return await _context.PlayerGameStats.AnyAsync(s => s.StatID == id);
        }

        private async Task<PlayerGameStats> Create([Bind("StatID,PlayerID,GameID,Updated,Minutes,FieldGoalsMade,FieldGoalsAttempted,FieldGoalsPercentage,ThreePointersMade,ThreePointersAttempted,ThreePointersPercentage,FreeThrowsMade,FreeThrowsAttempted,FreeThrowsPercentage,OffensiveRebounds,DefensiveRebounds,Rebounds,Assists,Steals,BlockedShots,Turnovers,PersonalFouls,Points,PlusMinus,Started")] PlayerGameStats playerGameStats)
        {
            Boolean playerExists = await _context.Player.AnyAsync(a => a.PlayerID == playerGameStats.PlayerID);
            Boolean gameExists = await _context.Game.AnyAsync(a => a.GameID == playerGameStats.GameID);

            if (playerExists && gameExists)
            {
                return playerGameStats;
            }
            return null;
        }

        private async Task<PlayerGameStats> Edit(int id, [Bind("StatID,PlayerID,Updated,Minutes,FieldGoalsMade,FieldGoalsAttempted,FieldGoalsPercentage,ThreePointersMade,ThreePointersAttempted,ThreePointersPercentage,FreeThrowsMade,FreeThrowsAttempted,FreeThrowsPercentage,OffensiveRebounds,DefensiveRebounds,Rebounds,Assists,Steals,BlockedShots,Turnovers,PersonalFouls,Points,PlusMinus,Started")] PlayerGameStats playerGameStats)
        {
            if (id != playerGameStats.StatID)
            {
                return null;
            }
            Boolean playerExists = await _context.Player.AnyAsync(a => a.PlayerID == playerGameStats.PlayerID);
            Boolean gameExists = await _context.Game.AnyAsync(a => a.GameID == playerGameStats.GameID);
            if (playerExists && gameExists)
            {
                return playerGameStats;
            }
            return null;
        }

        public async Task<List<PlayerGameStats>> GetGameLeaders(int id)
        {
            var leaders = await _context.PlayerGameStats
               .Include(p => p.GameNav)
               .Include(p => p.PlayerNav)
               .Where(p => p.GameID == id)
               .OrderByDescending(p => p.Points)
               .Take(2).ToListAsync();

            return leaders;
        }
    }
}