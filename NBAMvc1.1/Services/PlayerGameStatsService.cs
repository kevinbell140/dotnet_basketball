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

        public PlayerGameStatsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public PlayerGameStats GetPlayerGameStatsByGame(int playerID, int gameID)
        {
            var log = _context.PlayerGameStats
                    .Where(a => a.GameNav.GameID == gameID && a.PlayerNav.PlayerID == playerID)
                    .FirstOrDefault();
            return log;
        }
    }
}
