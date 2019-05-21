using Microsoft.AspNetCore.Mvc;
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
    public class PlayerSeasonStatsService : IPlayerSeasonStatsService
    {
        private readonly ApplicationDbContext _context;
        private readonly IDataService _dataService;

        public PlayerSeasonStatsService(ApplicationDbContext context, IDataService dataService)
        {
            _context = context;
            _dataService = dataService;
        }

        public async Task FetchAsync()
        {
            var stats = await _dataService.FetchSeasonStatsAsync();
            List<PlayerSeasonStats> created = new List<PlayerSeasonStats>();
            List<PlayerSeasonStats> updated = new List<PlayerSeasonStats>();

            foreach (PlayerSeasonStats s in stats)
            {
                if (!await PlayerSeasonStatsExists(s.StatID))
                {
                    if (await PlayerExists(s.PlayerID))
                    {
                        created.Add(s);
                    }
                }
                else
                {
                    if (await PlayerExists(s.PlayerID))
                    {
                        updated.Add(s);
                    }
                }
            }
            try
            {
                await _context.AddRangeAsync(created);
                _context.UpdateRange(updated);
                await _context.SaveChangesAsync();
                return;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        private async Task<bool> PlayerSeasonStatsExists(int id)
        {
            return await _context.PlayerSeasonStats.AnyAsync(a => a.StatID == id);
        }

        private async Task<bool> PlayerExists(int id)
        {
            return await _context.Player.AnyAsync(a => a.PlayerID == id);
        }
    }
}
