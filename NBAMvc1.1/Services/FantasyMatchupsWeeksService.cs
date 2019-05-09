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

        public FantasyMatchupsWeeksService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FantasyMatchupWeeks>> GetWeeks()
        {
            var weeks = await _context.FantasyMatchupWeeks
                .Include(f => f.FantasyLeagueNav)
                .ToListAsync();
            return weeks;
        }

        public async Task<bool> WeeksExist(int leagueID)
        {
            var exists = await _context.FantasyMatchupWeeks
                .Where(l => l.FantasyLeagueID == leagueID)
                .AnyAsync();
            return exists;
        }

        public async Task<bool> Create(FantasyLeague fantasyLeague)
        {
            if(!await WeeksExist(fantasyLeague.FantasyLeagueID))
            {
                DateTime startDate = DateTime.Today.AddDays(-1);
                int numWeeks = (fantasyLeague.TeamsNav.Count() - 1) * 2;
                List<FantasyMatchupWeeks> list = new List<FantasyMatchupWeeks>();

                for (int i = 1; i <= numWeeks; i++)
                {
                    FantasyMatchupWeeks week = new FantasyMatchupWeeks
                    {
                        FantasyLeagueNav = fantasyLeague,
                        WeekNum = i,
                        Date = startDate.AddDays(i),
                    };
                    list.Add(week);
                }
                try
                {
                    await _context.FantasyMatchupWeeks.AddRangeAsync(list);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<FantasyMatchupWeeks>> GetFantasyMatchupWeeksByLeague(int leagueID)
        {
            var weeks = await _context.FantasyMatchupWeeks
                    .Where(f => f.FantasyLeagueID == leagueID)
                    .AsNoTracking().ToListAsync();
            return weeks;
        }

        public async Task<FantasyMatchupWeeks> GetFantasyMatchupWeekByLeague(int leagueID, int weekNum)
        {
            var matchupWeek = await _context.FantasyMatchupWeeks
                    .Where(x => x.FantasyLeagueID == leagueID)
                    .Where(x => x.WeekNum == weekNum)
                    .FirstOrDefaultAsync();
            return matchupWeek;
        }

        public async Task<FantasyMatchupWeeks> GetFantasyMatchupWeekByLeagueByDate(int leagueID, DateTime date)
        {
            var matchupWeek = await _context.FantasyMatchupWeeks
                    .Where(x => x.FantasyLeagueID == leagueID)
                    .Where(x => x.Date == date)
                    .FirstOrDefaultAsync();
            return matchupWeek;
        }

        public FantasyMatchupWeeks GetThisWeek(IEnumerable<FantasyMatchupWeeks> weeks)
        {
            var thisWeek = weeks
                    .Where(w => w.Date == DateTime.Today)
                    .FirstOrDefault();
            return thisWeek;
        }

        public async Task<FantasyMatchupWeeks> GetFantasyMatchupWeeksByID(int id)
        {
            var fantasyMatchupWeeks = await _context.FantasyMatchupWeeks
                .Include(f => f.FantasyLeagueNav)
                .Where(f => f.FantasyMatchupWeeksID == id)
                .FirstOrDefaultAsync();
            return fantasyMatchupWeeks;
        }
    }
}
