using Microsoft.EntityFrameworkCore;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Services
{
    public class StandingsService
    {
        private readonly ApplicationDbContext _context;

        public StandingsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Standings>> GetStandings(string conference)
        {
            List<Standings> standings = new List<Standings>();

            standings = await _context.Standings
                .Where(t => t.TeamNav.Conference == conference)
                .Include(t => t.TeamNav)
                .OrderBy(t => t.GamesBack)
                .ToListAsync();

            return standings;
        }
    }
}
