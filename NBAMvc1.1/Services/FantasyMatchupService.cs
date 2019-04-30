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
        private readonly MyTeamsService _myTeamsService;

        public FantasyMatchupService(ApplicationDbContext context, DataService dataService, MyTeamsService myTeamsService)
        {
            _context = context;
            _dataService = dataService;
            _myTeamsService = myTeamsService;
        }

        public async Task<IEnumerable<FantasyMatchup>> GetMatchups()
        {
            var matchups = await _context.FantasyMatchup
                .Include(f => f.FantasyLeagueNav)
                .Include(f => f.AwayTeamNav)
                .Include(f => f.HomeTeamNav)
                .ToListAsync();
            return matchups;
        }

        public async Task<bool> Create(FantasyLeague fantasyLeague)
        {
            List<MyTeam> teams = await _myTeamsService.GetMyTeamsByLeague(fantasyLeague.FantasyLeagueID);
            if(!await MatchupsExists(fantasyLeague.FantasyLeagueID))
            {
                int numWeeks = (teams.Count() - 1) * 2;
                int halfSize = teams.Count() / 2;

                List<MyTeam> listTeams = new List<MyTeam>();

                listTeams.AddRange(teams);
                listTeams.RemoveAt(0);

                int teamSize = listTeams.Count();

                List<FantasyMatchup> matchups = new List<FantasyMatchup>();

                for (int week = 0; week < numWeeks; week++)
                {
                    var matchup = new FantasyMatchup();
                    matchup.Week = week + 1;
                    matchup.FantasyLeagueID = fantasyLeague.FantasyLeagueID;
                    matchup.Status = "Scheduled";

                    int teamIdx = week % teamSize;

                    matchup.AwayTeamNav = listTeams[teamIdx];
                    matchup.HomeTeamNav = teams[0];
                    matchup.HomeTeamScore = 0;
                    matchup.AwayTeamScore = 0;

                    matchups.Add(matchup);

                    for (int i = 1; i < halfSize; i++)
                    {
                        var nextMatchup = new FantasyMatchup();
                        nextMatchup.Week = week + 1;
                        nextMatchup.FantasyLeagueID = fantasyLeague.FantasyLeagueID;
                        nextMatchup.Status = "Scheduled";

                        nextMatchup.AwayTeamNav = listTeams[(week + i) % teamSize];
                        nextMatchup.HomeTeamNav = listTeams[(week + teamSize - i) % teamSize];
                        nextMatchup.AwayTeamScore = 0;
                        nextMatchup.HomeTeamScore = 0;
                        matchups.Add(nextMatchup);
                    }
                }
                try
                {
                    _context.FantasyMatchup.AddRange(matchups);
                    await _context.SaveChangesAsync();
                    return true;
                    //return RedirectToAction("IsSetConfrim", "FantasyLeagues", new { id = leagueID });
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }
        
        private async Task<bool> MatchupsExists(int leagueID)
        {
            return await _context.FantasyMatchup.Where(m => m.FantasyLeagueID == leagueID).AnyAsync();
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
