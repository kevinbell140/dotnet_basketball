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
                .Where(g => (g.Status == "Final" || g.Status == "F/OT") && (g.HomeTeamID == id || g.AwayTeamID == id))
                .Include(g => g.HomeTeamNav)
                .Include(g => g.AwayTeamNav)
                .OrderByDescending(g => g.DateTime)
                .Take(5);

            if(last5 != null)
            {
                return last5;
            }
            return null;
        }

        public IEnumerable<Game> GetNext3(int id)
        {
            var next3 = _context.Game
                .Where(g => g.Status == "Scheduled" && (g.HomeTeamID == id || g.AwayTeamID == id))
                .Include(g => g.HomeTeamNav)
                .Include(g => g.AwayTeamNav)
                .OrderBy(g => g.DateTime)
                .Take(3);

            if(next3 != null)
            {
                return next3;
            }
            return null;
        }
    }
}
