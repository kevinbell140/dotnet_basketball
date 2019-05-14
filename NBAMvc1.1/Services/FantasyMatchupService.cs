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
        private readonly PlayerMyTeamService _playerMyTeamService;
        private readonly FantasyMatchupsWeeksService _fantasyMatchupsWeeksService;
        private readonly PlayerGameStatsService _playerGameStatsService;
        private readonly GamesService _gamesService;
        private readonly FantasyLeagueStandingsService _fantasyLeagueStandingsService;

        public FantasyMatchupService(ApplicationDbContext context, PlayerMyTeamService playerMyTeamService,
           FantasyMatchupsWeeksService fantasyMatchupsWeeksService, PlayerGameStatsService playerGameStatsService,
            GamesService gamesService, FantasyLeagueStandingsService fantasyLeagueStandingsService)
        {
            _context = context;
            _playerMyTeamService = playerMyTeamService;
            _fantasyMatchupsWeeksService = fantasyMatchupsWeeksService;
            _playerGameStatsService = playerGameStatsService;
            _gamesService = gamesService;
            _fantasyLeagueStandingsService = fantasyLeagueStandingsService;
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
            if(await _fantasyMatchupsWeeksService.Create(fantasyLeague))
            {
               if(await CreateMatchups(fantasyLeague))
                {
                    if(await _fantasyLeagueStandingsService.Create(fantasyLeague))
                    {
                        if(await SetLeague(fantasyLeague))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public async Task<bool> SetLeague(FantasyLeague fantasyLeague)
        {
            fantasyLeague.IsSet = true;
            fantasyLeague.IsActive = true;
            fantasyLeague.CurrentWeek = 1;
            try
            {
                _context.Update(fantasyLeague);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task<bool> CreateMatchups(FantasyLeague fantasyLeague)
        {
            List<MyTeam> teams = fantasyLeague.TeamsNav;
            
            if (!await MatchupsExists(fantasyLeague.FantasyLeagueID))
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

        public async Task<bool> SetStatus(FantasyMatchup matchup, string status)
        {
            matchup.Status = status;
            try
            {
                _context.Update(matchup);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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

        public async Task<IEnumerable<FantasyMatchup>> GetMatchupsForScoring()
        {
            var matchups = await _context.FantasyMatchup
                    .Include(m => m.AwayTeamNav)
                    .Include(m => m.HomeTeamNav)
                    .Where(m => (m.Status == "In Progress" || m.Status == "Final") && !m.Recorded) 
                    .AsNoTracking().ToListAsync();

            return matchups;
        }

        public async Task<bool> UpdateScores(IEnumerable<FantasyMatchup> matchups)
        {
            List<FantasyMatchup> updateList = new List<FantasyMatchup>();

            foreach (var m in matchups)
            {
                updateList = await UpdateScore(m, updateList);
            }
            try
            {
                _context.UpdateRange(updateList);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task<List<FantasyMatchup>> UpdateScore(FantasyMatchup matchup, List<FantasyMatchup> updateList)
        {
            var scores = await CalculateScore(matchup);
            matchup.HomeTeamScore = scores[0];
            matchup.AwayTeamScore = scores[1];
            matchup.UpdatedAt = DateTime.Now;

            updateList.Add(matchup);
            return updateList;
        }


        private async Task<decimal[]> CalculateScore(FantasyMatchup matchup)
        {
            var matchupWeek = await _fantasyMatchupsWeeksService.GetFantasyMatchupWeekByLeague(matchup.FantasyLeagueID, matchup.Week);
            decimal homeScore = 0;
            decimal awayScore = 0;
            if (matchupWeek != null)
            {
                var home = await _playerMyTeamService.GetRoster(matchup.HomeTeamID.Value);
                if (home.Any() && home != null)
                {
                    List<PlayerGameStats> homeStats = await GetGameStatsList(home, matchupWeek);
                    if (homeStats != null)
                    {
                        homeScore = homeStats.Sum(x => x.FantasyPoints);
                    }
                }

                var away = await _playerMyTeamService.GetRoster(matchup.AwayTeamID.Value);
                if (away.Any() && away != null)
                {
                    List<PlayerGameStats> awayStats = await GetGameStatsList(away, matchupWeek);
                    if (awayStats != null)
                    {
                        awayScore = awayStats.Sum(x => x.FantasyPoints);
                    }
                }
            }           
            return new decimal[] { homeScore, awayScore};
        }


        public async Task<IEnumerable<FantasyMatchup>> GetMatchupsForRecording(int leagueID, int week)
        {
            var matchups = await _context.FantasyMatchup
                    .Include(m => m.AwayTeamNav)
                    .Include(m => m.HomeTeamNav)
                    .Where(m => m.FantasyLeagueID == leagueID && m.Week == week && !m.Recorded)
                    .AsNoTracking().ToListAsync();

            return matchups;
        }


        //public async Task<bool> StandingsRecorded(int leagueID, int week)
        //{
        //    var matchups = await GetMatchupsByWeek(leagueID, week);
        //    List<FantasyMatchup> updatedMatchups = new List<FantasyMatchup>();

        //    foreach(var m in matchups)
        //    {
        //        m.Recorded = true;
        //        updatedMatchups.Add(m);
        //    }
        //    try
        //    {
        //        _context.UpdateRange(updatedMatchups);
        //        await _context.SaveChangesAsync();
        //        return true;
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        return false;
        //    }
        //}

            //do i need this?
        public async Task<int> WeeksThatNeedRecording(int leagueID)
        {
            var weeks = await _context.FantasyMatchup
                    .Where(m => m.FantasyLeagueID == leagueID && m.Status == "Final" && !m.Recorded)
                    .Select(m => m.Week).Distinct().CountAsync();
            return weeks;
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



        public async Task<Dictionary<string, string>> GetOpponentLogoDictionary(IDictionary<string, Player> roster, FantasyMatchupWeeks matchupWeek)
        {
            Dictionary<string, string> OppDictionary = new Dictionary<string, string>
                {
                    { "PG1", null},
                    { "PG2", null},
                    { "SG1", null},
                    { "SG2", null},
                    { "SF1", null},
                    { "SF2", null},
                    { "PF1", null},
                    { "PF2", null},
                    { "C", null},
                };

            foreach (KeyValuePair<string, Player> player in roster)
            {
                if (player.Value != null)
                {
                    var gameTonight = await _gamesService.HasGameTonight(matchupWeek, player.Value.TeamID);

                    if (gameTonight != null)
                    {
                        OppDictionary[player.Key] = (gameTonight.AwayTeamID == player.Value.TeamID ? gameTonight.HomeTeamNav.WikipediaLogoUrl : gameTonight.AwayTeamNav.WikipediaLogoUrl);
                    }
                }
            }
            return OppDictionary;
        }

        public async Task<Dictionary<string, PlayerGameStats>> GetGameStatsDictionary(IDictionary<string, Player> roster, FantasyMatchupWeeks matchupWeek)
        {
            Dictionary<string, PlayerGameStats> statsDictionary = new Dictionary<string, PlayerGameStats>
                {
                    { "PG1", null},
                    { "PG2", null},
                    { "SG1", null},
                    { "SG2", null},
                    { "SF1", null},
                    { "SF2", null},
                    { "PF1", null},
                    { "PF2", null},
                    { "C", null},
                };

            foreach (KeyValuePair<string, Player> player in roster)
            {
                if (player.Value != null)
                {
                    var gameTonight = await _gamesService.HasGameTonight(matchupWeek, player.Value.TeamID);

                    if (gameTonight != null)
                    {
                        var stats = await _playerGameStatsService.GetPlayerGameStatsByGame(player.Value.PlayerID, gameTonight.GameID);
                        if (stats != null)
                        {
                            statsDictionary[player.Key] = stats; ;
                        }
                    }
                }
            }
            return statsDictionary;
        }

        public async Task<List<PlayerGameStats>> GetGameStatsList(IEnumerable<PlayerMyTeam> roster, FantasyMatchupWeeks matchupWeek)
        {
            List<PlayerGameStats> statsList = new List<PlayerGameStats>();
            foreach (PlayerMyTeam player in roster)
            {
                var gameTonight = await _gamesService.HasGameTonight(matchupWeek, player.PlayerNav.TeamID);
                if (gameTonight != null)
                {
                    var stats = await _playerGameStatsService.GetPlayerGameStatsByGame(player.PlayerNav.PlayerID, gameTonight.GameID);
                    if (stats != null)
                    {
                        statsList.Add(stats);
                    }
                }
            }
            return statsList;
        }
    }
}
