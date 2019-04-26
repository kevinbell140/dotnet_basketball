using Microsoft.EntityFrameworkCore;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Services
{
    public class MyTeamsService
    {
        private readonly ApplicationDbContext _context;
        private readonly DataService _dataService;

        public MyTeamsService(ApplicationDbContext context, DataService dataService)
        {
            _context = context;
            _dataService = dataService;
        }

        public async Task<IEnumerable<MyTeam>> GetMyTeamByUserID(string id)
        {
            var myTeam = await _context.MyTeam
                .Include(t => t.FantasyLeagueNav)
                .Include(t => t.PlayerMyTeamNav)
                .Where(t => t.UserID == id)
                .ToListAsync();

            return myTeam;
        }
    }
}
