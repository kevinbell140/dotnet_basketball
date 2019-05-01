using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using NBAMvc1._1.Services;
using NBAMvc1._1.ViewModels;

namespace NBAMvc1._1.Controllers
{
    public class FantasyMatchupsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly FantasyMatchupService _fantasyMatchupService;
        private readonly FantasyLeagueService _fantasyLeagueService;
        private readonly FantasyMatchupsWeeksService _fantasyMatchupsWeeksService;
        private readonly PlayerMyTeamService _playerMyTeamService;
        private readonly GamesService _gamesService;
        private readonly PlayerGameStatsService _playerGameStatsService;

        public FantasyMatchupsController(ApplicationDbContext context, FantasyMatchupService fantasyMatchupService, FantasyLeagueService fantasyLeagueService,
            FantasyMatchupsWeeksService fantasyMatchupsWeeksService, PlayerMyTeamService playerMyTeamService, GamesService gamesService, PlayerGameStatsService playerGameStatsService)
        {
            _context = context;
            _fantasyMatchupService = fantasyMatchupService;
            _fantasyLeagueService = fantasyLeagueService;
            _fantasyMatchupsWeeksService = fantasyMatchupsWeeksService;
            _playerMyTeamService = playerMyTeamService;
            _gamesService = gamesService;
            _playerGameStatsService = playerGameStatsService;
        }

        // GET: FantasyMatchups
        public async Task<IActionResult> Index()
        {
            var matchups = await _fantasyMatchupService.GetMatchups();
            return View(matchups);
        }

        // GET: FantasyMatchups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = new FantasyMatchupDetailsViewModel
            {
                FantasyMatchup = await _fantasyMatchupService.GetMatchupByID(id.Value)
            };

            //query players to list and not to dictionary b/c there may be empty space on roster

            //get home roster
            viewModel.HomeRoster = await _playerMyTeamService.GetRosterDictionaryAsync(viewModel.FantasyMatchup.HomeTeamID.Value);
            viewModel.AwayRoster = await _playerMyTeamService.GetRosterDictionaryAsync(viewModel.FantasyMatchup.AwayTeamID.Value);
            var matchupWeek = await _fantasyMatchupsWeeksService.GetFantasyMatchupWeekByLeague(viewModel.FantasyMatchup.FantasyLeagueID, viewModel.FantasyMatchup.Week);
            viewModel.Date = matchupWeek.Date;

            foreach(KeyValuePair<string, Player> player in viewModel.HomeRoster)
            {
                if(player.Value != null)
                {
                    var gameTonight = await _gamesService.HasGameTonight(matchupWeek, player.Value.TeamID);

                    if (gameTonight != null)
                    {
                        viewModel.HomeOpp[player.Key] = (gameTonight.AwayTeamID == player.Value.TeamID ? gameTonight.HomeTeamNav.WikipediaLogoUrl : gameTonight.AwayTeamNav.WikipediaLogoUrl);
                        var stats = await _playerGameStatsService.GetPlayerGameStatsByGame(player.Value.PlayerID, gameTonight.GameID);
                        if (stats != null)
                        {
                            viewModel.HomeStats[player.Key] = stats;
                        }
                    }
                }
            }
            foreach (KeyValuePair<string, Player> player in viewModel.AwayRoster)
            {
                if(player.Value != null)
                {
                    var gameTonight = await _gamesService.HasGameTonight(matchupWeek, player.Value.TeamID);

                    if (gameTonight != null)
                    {
                        viewModel.HomeOpp[player.Key] = (gameTonight.AwayTeamID == player.Value.TeamID ? gameTonight.HomeTeamNav.WikipediaLogoUrl : gameTonight.AwayTeamNav.WikipediaLogoUrl);
                        var stats = await _playerGameStatsService.GetPlayerGameStatsByGame(player.Value.PlayerID, gameTonight.GameID);
                        if (stats != null)
                        {
                            viewModel.HomeStats[player.Key] = stats;
                        }
                    }
                }
            }
            return View(viewModel);


            //var home = await _context.PlayerMyTeam
            //     .Where(p => p.MyTeamNav.MyTeamID == viewModel.FantasyMatchup.HomeTeamID)
            //     .Include(p => p.PlayerNav).ThenInclude(p => p.StatsNav)
            //     .Include(p => p.PlayerNav).ThenInclude(p => p.TeamNav)
            //     .OrderBy(p => p.PlayerNav.Position)
            //     .AsNoTracking().ToListAsync();

            // //get away roster
            // var away = await _context.PlayerMyTeam
            //     .Where(p => p.MyTeamNav.MyTeamID == viewModel.FantasyMatchup.AwayTeamID)
            //     .Include(p => p.PlayerNav).ThenInclude(p => p.StatsNav)
            //     .Include(p => p.PlayerNav).ThenInclude(p => p.TeamNav)
            //     .OrderBy(p => p.PlayerNav.Position)
            //     .AsNoTracking().ToListAsync();

            //get week schedule
            //var matchupWeek = await _context.FantasyMatchupWeeks
            //    .Where(x => x.FantasyLeagueID == viewModel.FantasyMatchup.FantasyLeagueID)
            //    .Where(x => x.WeekNum == viewModel.FantasyMatchup.Week)
            //    .FirstOrDefaultAsync();

            //int posCount = 1;
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet]
        public async Task<IActionResult> Create(int leagueID)
        {
            var fantasyLeague = await _fantasyLeagueService.GetLeague(leagueID);
            if(fantasyLeague == null)
            {
                return NotFound();
            }

            //needs validation
            if (!fantasyLeague.IsFull)
            {
                return RedirectToAction("Details", "FantasyLeagues", new { id = leagueID });
            }

            if (await _fantasyMatchupsWeeksService.Create(fantasyLeague))
            {
                if(await _fantasyMatchupService.Create(fantasyLeague))
                {
                    if(await _fantasyLeagueService.IsSetConfirm(fantasyLeague.FantasyLeagueID))
                    {
                        return RedirectToAction("Details", "FantasyLeagues", new { id = leagueID });
                    }
                }
            }
            return RedirectToAction("Index", "Home", new { id = leagueID });
        }

        public async Task<decimal[]> CalculateScore(int id)
        {
            var matchup = await _context.FantasyMatchup
                .Include(f => f.AwayTeamNav).ThenInclude(f => f.UserNav)
                .Include(f => f.FantasyLeagueNav).ThenInclude(f => f.FantasyMatchupWeeksNav)
                .Include(f => f.HomeTeamNav).ThenInclude(f => f.UserNav)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.FantasyMatchupID == id);

            if (matchup == null)
            {
                return null;
            }

            var home = await _context.PlayerMyTeam
                 .Where(p => p.MyTeamNav.MyTeamID == matchup.HomeTeamID)
                 .Include(p => p.PlayerNav).ThenInclude(p => p.StatsNav)
                 .Include(p => p.PlayerNav).ThenInclude(p => p.TeamNav)
                 .OrderBy(p => p.PlayerNav.Position)
                 .AsNoTracking().ToListAsync();

            var away = await _context.PlayerMyTeam
                .Where(p => p.MyTeamNav.MyTeamID == matchup.AwayTeamID)
                .Include(p => p.PlayerNav).ThenInclude(p => p.StatsNav)
                .Include(p => p.PlayerNav).ThenInclude(p => p.TeamNav)
                .OrderBy(p => p.PlayerNav.Position)
                .AsNoTracking().ToListAsync();

            var matchupWeek = await _context.FantasyMatchupWeeks
                .Where(x => x.FantasyLeagueID == matchup.FantasyLeagueID)
                .Where(x => x.WeekNum == matchup.Week)
                .FirstOrDefaultAsync();

            List<PlayerGameStats> homeStats = new List<PlayerGameStats>();
            List<PlayerGameStats> awayStats = new List<PlayerGameStats>();

            foreach (var p in home)
            {
                var gameTonight = await _context.Game
                    .Include(g => g.PlayerGameStatsNav)
                    .Include(g => g.HomeTeamNav)
                    .Include(g => g.AwayTeamNav)
                    .Where(g => g.DateTime.Date == matchupWeek.Date)
                    .Where(g => g.AwayTeamID == p.PlayerNav.TeamID || g.HomeTeamID == p.PlayerNav.TeamID)
                    .FirstOrDefaultAsync();

                if (gameTonight != null)
                {
                    var stats = await _context.PlayerGameStats
                    .Where(x => x.GameID == gameTonight.GameID)
                    .Where(x => x.PlayerID == p.PlayerID)
                    .FirstOrDefaultAsync();
                    if (stats != null)
                    {
                        homeStats.Add(stats);
                    }
                }
            }
            foreach (var p in away)
            {
                var gameTonight = await _context.Game
                    .Include(g => g.PlayerGameStatsNav)
                    .Include(g => g.HomeTeamNav)
                    .Include(g => g.AwayTeamNav)
                    .Where(g => g.DateTime.Date == matchupWeek.Date)
                    .Where(g => g.AwayTeamID == p.PlayerNav.TeamID || g.HomeTeamID == p.PlayerNav.TeamID)
                    .FirstOrDefaultAsync();

                if (gameTonight != null)
                {
                    var stats = await _context.PlayerGameStats
                    .Where(x => x.GameID == gameTonight.GameID)
                    .Where(x => x.PlayerID == p.PlayerID)
                    .FirstOrDefaultAsync();
                    if (stats != null)
                    {
                        awayStats.Add(stats);
                    }
                }
            }
            return new decimal[] { homeStats.Sum(x => x.FantasyPoints), awayStats.Sum(x => x.FantasyPoints) };
        }
    }
}
