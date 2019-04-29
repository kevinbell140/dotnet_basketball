using Microsoft.EntityFrameworkCore;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Services
{
    public class FantasyMatchupsWeeksService
    {
        private readonly ApplicationDbContext _context;
        private readonly DataService _dataService;

        public FantasyMatchupsWeeksService(ApplicationDbContext context, DataService dataService)
        {
            _context = context;
            _dataService = dataService;
        }

        public async Task<IEnumerable<FantasyMatchupWeeks>> GetFantasyMatchupWeeksByLeague(int leagueID)
        {
            var weeks = await _context.FantasyMatchupWeeks
                    .Where(f => f.FantasyLeagueID == leagueID)
                    .AsNoTracking().ToListAsync();
            return weeks;
        }

        public FantasyMatchupWeeks GetThisWeek(IEnumerable<FantasyMatchupWeeks> weeks)
        {
            var thisWeek = weeks
                    .Where(w => w.Date == DateTime.Today)
                    .FirstOrDefault();
            return thisWeek;
        }

    }
}
