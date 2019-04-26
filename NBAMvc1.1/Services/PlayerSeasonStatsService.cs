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
    public class PlayerSeasonStatsService
    {
        private readonly ApplicationDbContext _context;
        private readonly DataService _dataService;

        public PlayerSeasonStatsService(ApplicationDbContext context, DataService dataService)
        {
            _context = context;
            _dataService = dataService;
        }
        public async Task<List<PlayerSeasonStats>> GetPlayerSeasonStats()
        {
            List<PlayerSeasonStats> stats = new List<PlayerSeasonStats>();
            stats = await _context.PlayerSeasonStats
                .Include(p => p.PlayNav)
                .ToListAsync();
            return stats;
        }

        public async Task<bool> Fetch()
        {
            var stats = await _dataService.FetchStats();

            List<PlayerSeasonStats> created = new List<PlayerSeasonStats>();
            List<PlayerSeasonStats> updated = new List<PlayerSeasonStats>();

            foreach (PlayerSeasonStats s in stats)
            {
                if (!await PlayerSeasonStatsExists(s.StatID))
                {
                    var createdStat = Create(s);
                    if (createdStat != null)
                    {
                        created.Add(await createdStat);
                    }
                }
                else
                {
                    var updatedStat = Edit(s.StatID, s);
                    if (updatedStat != null)
                    {
                        updated.Add(await updatedStat);
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

        private async Task<bool> PlayerSeasonStatsExists(int id)
        {
            return await _context.PlayerSeasonStats.AnyAsync(a => a.StatID == id);
        }

        public async Task<PlayerSeasonStats> Create([Bind("StatID,PlayerID,Games,FieldGoalsPercentage,FreeThrowsPercentage,ThreePointersMade,Points,Assists,Rebounds,Steals,BlockedShots,Turnovers")] PlayerSeasonStats playerSeasonStats)
        {
            Boolean playerExists = await _context.Player.AnyAsync(a => a.PlayerID == playerSeasonStats.PlayerID);
            if (playerExists)
            {
                return playerSeasonStats;
            }
            return null;
        }

        public async Task<PlayerSeasonStats> Edit(int id, [Bind("StatID,PlayerID,Games,FieldGoalsPercentage,FreeThrowsPercentage,ThreePointersMade,Points,Assists,Rebounds,Steals,BlockedShots,Turnovers")] PlayerSeasonStats playerSeasonStats)
        {
            if (id != playerSeasonStats.StatID)
            {
                return null;
            }
            Boolean playerExists = await _context.Player.AnyAsync(a => a.PlayerID == playerSeasonStats.PlayerID);
            if (playerExists)
            {
                return playerSeasonStats;
            }
            return null;
        }
    }
}
