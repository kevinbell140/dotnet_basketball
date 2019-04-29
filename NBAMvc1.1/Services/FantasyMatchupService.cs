using Microsoft.EntityFrameworkCore;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Services
{
    public class FantasyMatchupService
    {
        private readonly ApplicationDbContext _context;
        private readonly DataService _dataService;

        public FantasyMatchupService(ApplicationDbContext context, DataService dataService)
        {
            _context = context;
            _dataService = dataService;
        }
        public async Task<IEnumerable<FantasyMatchup>> GetMatchupsByWeek(int leagueID, int selectedWeek)
        {
            var matchups = await _context.FantasyMatchup
                    .Include(m => m.AwayTeamNav)
                    .Include(m => m.HomeTeamNav)
                    .Where(m => m.FantasyLeagueID == leagueID && m.Week == selectedWeek)
                    .AsNoTracking().ToListAsync();
            return matchups;
        }

        public async Task<IEnumerable<FantasyMatchup>> GetMatchupsForUpdate(int leagueID, int currentWeek)
        {
            var matchups = await _context.FantasyMatchup
                    .Include(m => m.AwayTeamNav)
                    .Include(m => m.HomeTeamNav)
                    .Where(m => m.FantasyLeagueID == leagueID && m.Week <= currentWeek)
                    .AsNoTracking().ToListAsync();

            return matchups;
        }

        public async Task<FantasyMatchup> GetMatchupByID(int id)
        {
            var matchup = await _context.FantasyMatchup
                .Include(f => f.AwayTeamNav).ThenInclude(f => f.UserNav)
                .Include(f => f.FantasyLeagueNav).ThenInclude(f => f.FantasyMatchupWeeksNav)
                .Include(f => f.HomeTeamNav).ThenInclude(f => f.UserNav)
                .Where(f => f.FantasyMatchupID == id)
                .AsNoTracking().FirstOrDefaultAsync();
            return matchup;
        }

    }
}
