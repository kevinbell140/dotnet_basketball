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

        public async Task Create(FantasyLeague fantasyLeague)
        {
            await _fantasyMatchupsWeeksService.Create(fantasyLeague);
            await CreateMatchupsAsync(fantasyLeague);
            await _fantasyLeagueStandingsService.Create(fantasyLeague);
            await SetLeagueAsync(fantasyLeague);
            return;
        }

        public async Task SetLeagueAsync(FantasyLeague fantasyLeague)
        {
            fantasyLeague.IsSet = true;
            fantasyLeague.IsActive = true;
            fantasyLeague.CurrentWeek = 1;
            try
            {
                _context.Update(fantasyLeague);
                await _context.SaveChangesAsync();
                return;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        private async Task CreateMatchupsAsync(FantasyLeague fantasyLeague)
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
                _context.FantasyMatchup.AddRange(matchups);
                await _context.SaveChangesAsync();
                return;
            }
        }

        
        private async Task<bool> MatchupsExists(int leagueID)
        {
            return await _context.FantasyMatchup.Where(m => m.FantasyLeagueID == leagueID).AnyAsync();
        }

        public async Task<IEnumerable<FantasyMatchup>> GetMatchupsByWeekAsync(int leagueID, int selectedWeek)
        {
            var matchups = await _context.FantasyMatchup
                    .Include(m => m.AwayTeamNav)
                    .Include(m => m.HomeTeamNav)
                    .Where(m => m.FantasyLeagueID == leagueID && m.Week == selectedWeek)
                    .AsNoTracking().ToListAsync();
            return matchups;
        }

        

        public async Task SetRecordedAsync(List<FantasyMatchup> matchups, bool status)
        {
            foreach(var m in matchups)
            {
                m.Recorded = status;
                m.UpdatedAt = DateTime.Now;
            }
            try
            {
                _context.UpdateRange(matchups);
                await _context.SaveChangesAsync();
                return;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task<IEnumerable<FantasyMatchup>> GetMatchupsForUpdate()
        {
            var matchups = await _context.FantasyMatchup
                    .Include(m => m.AwayTeamNav)
                    .Include(m => m.HomeTeamNav)
                    .Where(m => m.Status != "Final")
                    .AsNoTracking().ToListAsync();

            return matchups;
        }

        public async Task<IEnumerable<FantasyMatchup>> GetMatchupsForScoringAsync()
        {
            var matchups = await _context.FantasyMatchup
                    .Include(m => m.AwayTeamNav)
                    .Include(m => m.HomeTeamNav)
                    .Where(m => (m.Status == "In Progress" || m.Status == "Final") && !m.Recorded) 
                    .AsNoTracking().ToListAsync();

            return matchups;
        }

        public async Task UpdateScoresAsync(IEnumerable<FantasyMatchup> matchups)
        {
            List<FantasyMatchup> updateList = new List<FantasyMatchup>();

            foreach (var m in matchups)
            {
                updateList = await UpdateScoreAsync(m, updateList);
            }
            try
            {
                _context.UpdateRange(updateList);
                await _context.SaveChangesAsync();
                return;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        private async Task<List<FantasyMatchup>> UpdateScoreAsync(FantasyMatchup matchup, List<FantasyMatchup> updateList)
        {
            var scores = await CalculateScoreAsync(matchup);
            matchup.HomeTeamScore = scores[0];
            matchup.AwayTeamScore = scores[1];
            matchup.UpdatedAt = DateTime.Now;

            updateList.Add(matchup);
            return updateList;
        }


        private async Task<decimal[]> CalculateScoreAsync(FantasyMatchup matchup)
        {
            var matchupWeek = await _fantasyMatchupsWeeksService.GetFantasyMatchupWeekByLeagueAsync(matchup.FantasyLeagueID, matchup.Week);
            decimal homeScore = 0;
            decimal awayScore = 0;
            if (matchupWeek != null)
            {
                var home = await _playerMyTeamService.GetRosterAsync(matchup.HomeTeamID.Value);
                if (home.Any() && home != null)
                {
                    List<PlayerGameStats> homeStats = await GetGameStatsListAsync(home, matchupWeek);
                    if (homeStats != null)
                    {
                        homeScore = homeStats.Sum(x => x.FantasyPoints);
                    }
                }

                var away = await _playerMyTeamService.GetRosterAsync(matchup.AwayTeamID.Value);
                if (away.Any() && away != null)
                {
                    List<PlayerGameStats> awayStats = await GetGameStatsListAsync(away, matchupWeek);
                    if (awayStats != null)
                    {
                        awayScore = awayStats.Sum(x => x.FantasyPoints);
                    }
                }
            }           
            return new decimal[] { homeScore, awayScore};
        }


        public async Task<FantasyMatchup> GetMatchupByIDAsync(int id)
        {
            var matchup = await _context.FantasyMatchup
                .Include(f => f.AwayTeamNav).ThenInclude(f => f.UserNav)
                .Include(f => f.FantasyLeagueNav).ThenInclude(f => f.FantasyMatchupWeeksNav)
                .Include(f => f.HomeTeamNav).ThenInclude(f => f.UserNav)
                .Where(f => f.FantasyMatchupID == id)
                .AsNoTracking().FirstOrDefaultAsync();
            return matchup;
        }

        public async Task<Dictionary<string, string>> GetOpponentLogoDictionaryAsync(IDictionary<string, Player> roster, FantasyMatchupWeeks matchupWeek)
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
                    var gameTonight = await _gamesService.HasGameTonightAsync(matchupWeek, player.Value.TeamID);

                    if (gameTonight != null)
                    {
                        OppDictionary[player.Key] = (gameTonight.AwayTeamID == player.Value.TeamID ? gameTonight.HomeTeamNav.WikipediaLogoUrl : gameTonight.AwayTeamNav.WikipediaLogoUrl);
                    }
                }
            }
            return OppDictionary;
        }

        public async Task<Dictionary<string, PlayerGameStats>> GetGameStatsDictionaryAsync(IDictionary<string, Player> roster, FantasyMatchupWeeks matchupWeek)
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
                    var gameTonight = await _gamesService.HasGameTonightAsync(matchupWeek, player.Value.TeamID);

                    if (gameTonight != null)
                    {
                        var stats = await _playerGameStatsService.GetPlayerGameStatsByGameAsync(player.Value.PlayerID, gameTonight.GameID);
                        if (stats != null)
                        {
                            statsDictionary[player.Key] = stats; ;
                        }
                    }
                }
            }
            return statsDictionary;
        }

        public async Task<List<PlayerGameStats>> GetGameStatsListAsync(IEnumerable<PlayerMyTeam> roster, FantasyMatchupWeeks matchupWeek)
        {
            List<PlayerGameStats> statsList = new List<PlayerGameStats>();
            foreach (PlayerMyTeam player in roster)
            {
                var gameTonight = await _gamesService.HasGameTonightAsync(matchupWeek, player.PlayerNav.TeamID);
                if (gameTonight != null)
                {
                    var stats = await _playerGameStatsService.GetPlayerGameStatsByGameAsync(player.PlayerNav.PlayerID, gameTonight.GameID);
                    if (stats != null)
                    {
                        statsList.Add(stats);
                    }
                }
            }
            return statsList;
        }

        public async Task UpdateCurrentWeek(IEnumerable<FantasyMatchup> matchups)
        {
            List<FantasyMatchup> updatedMatchups = new List<FantasyMatchup>();

            foreach (var m in matchups)
            {
                var weeks = await _fantasyMatchupsWeeksService.GetFantasyMatchupWeeksByLeague(m.FantasyLeagueID);
                if (weeks != null && weeks.Any())
                {
                    var currentWeek = weeks.Where(x => x.Date.Date == DateTime.Today.Date).FirstOrDefault();
                    int currentWeekNum = (currentWeek == null ? 15 : currentWeek.WeekNum);
                    if (m.Week == currentWeekNum)
                    {
                        m.Status = "In Progress";
                        m.UpdatedAt = DateTime.Now;
                        updatedMatchups.Add(m);
                    }
                    else if (m.Week < currentWeekNum)
                    {
                        m.Status = "Final";
                        m.UpdatedAt = DateTime.Now;
                        updatedMatchups.Add(m);
                    }
                    else
                    {
                        m.Status = "Scheduled";
                        m.UpdatedAt = DateTime.Now;
                        updatedMatchups.Add(m);
                    }
                }
            }
            try
            {
                _context.UpdateRange(updatedMatchups);
                await _context.SaveChangesAsync();
                return;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
