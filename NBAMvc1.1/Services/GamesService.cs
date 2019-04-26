using Microsoft.EntityFrameworkCore;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Services
{
    public class GamesService
    {
        private readonly ApplicationDbContext _context;

        public GamesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Game> GetLast5(int id)
        {
            var last5 = _context.Game
                .Include(g => g.HomeTeamNav)
                .Include(g => g.AwayTeamNav)
                .Where(g => (g.Status == "Final" || g.Status == "F/OT") && (g.HomeTeamID == id || g.AwayTeamID == id))
                .OrderByDescending(g => g.DateTime)
                .Take(5);

            return last5;
        }

        public IEnumerable<Game> GetNext3(int id)
        {
            var next3 = _context.Game
                .Include(g => g.HomeTeamNav)
                .Include(g => g.AwayTeamNav)
                .Where(g => g.Status == "Scheduled" && (g.HomeTeamID == id || g.AwayTeamID == id))
                .OrderBy(g => g.DateTime)
                .Take(3);

            return next3;
        }

        public async Task<IEnumerable<Game>> GetFinalGamesByTeam(int id)
        {
            List<Game> games = new List<Game>();
            games = await _context.Game
                .Include(g => g.HomeTeamNav)
                .Include(g => g.AwayTeamNav)
                .Include(g => g.PlayerGameStatsNav)
                .Where(g => (g.Status == "Final" || g.Status == "F/OT") && (g.HomeTeamNav.TeamID == id || g.AwayTeamNav.TeamID == id))
                .OrderByDescending(g => g.DateTime)
                .ToListAsync();

            return games;
        }
    }
}
