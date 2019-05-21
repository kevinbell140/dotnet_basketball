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
    public class StandingsService : IStandingsService
    {
        private readonly ApplicationDbContext _context;
        private readonly IDataService _dataService;

        public StandingsService(ApplicationDbContext context, IDataService dataService)
        {
            _context = context;
            _dataService = dataService;
        }

        public async Task<List<Standings>> GetStandingsAsync(string conference)
        {
            List<Standings> standings = new List<Standings>();

            standings = await _context.Standings
                .Where(t => t.TeamNav.Conference == conference)
                .Include(t => t.TeamNav)
                .OrderBy(t => t.GamesBack)
                .ToListAsync();

            return standings;
        }

        public async Task FetchAsync()
        {
            var standings = await _dataService.FetchStandingsAsync();
            List<Standings> created = new List<Standings>();
            List<Standings> updated = new List<Standings>();

            foreach (Standings s in standings)
            {
                if (!await StandingsExistAsync(s.TeamID))
                {
                    created.Add(s);
                }
                else
                {
                    updated.Add(s);
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
        private async Task<bool> StandingsExistAsync(int teamID)
        {
            return await _context.Standings.AnyAsync(a => a.TeamID == teamID);
        }
    }
}
