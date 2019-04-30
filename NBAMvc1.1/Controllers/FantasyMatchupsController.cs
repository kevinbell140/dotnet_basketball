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
    [Authorize(Policy = "AdminOnly")]
    public class FantasyMatchupsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly FantasyMatchupService _fantasyMatchupService;
        private readonly FantasyLeagueService _fantasyLeagueService;
        private readonly FantasyMatchupsWeeksService _fantasyMatchupsWeeksService;

        public FantasyMatchupsController(ApplicationDbContext context, FantasyMatchupService fantasyMatchupService, FantasyLeagueService fantasyLeagueService,
            FantasyMatchupsWeeksService fantasyMatchupsWeeksService)
        {
            _context = context;
            _fantasyMatchupService = fantasyMatchupService;
            _fantasyLeagueService = fantasyLeagueService;
            _fantasyMatchupsWeeksService = fantasyMatchupsWeeksService;
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
                FantasyMatchup = await _context.FantasyMatchup
                .Include(f => f.AwayTeamNav).ThenInclude(f => f.UserNav)
                .Include(f => f.FantasyLeagueNav).ThenInclude(f => f.FantasyMatchupWeeksNav)
                .Include(f => f.HomeTeamNav).ThenInclude(f => f.UserNav)
                .FirstOrDefaultAsync(m => m.FantasyMatchupID == id)
            };

            //query players to list and not to dictionary b/c there may be empty space on roster
           var home = await _context.PlayerMyTeam
                .Where(p => p.MyTeamNav.MyTeamID == viewModel.FantasyMatchup.HomeTeamID)
                .Include(p => p.PlayerNav).ThenInclude(p => p.StatsNav)
                .Include(p => p.PlayerNav).ThenInclude(p => p.TeamNav)
                .OrderBy(p => p.PlayerNav.Position)
                .AsNoTracking().ToListAsync();

            var away = await _context.PlayerMyTeam
                .Where(p => p.MyTeamNav.MyTeamID == viewModel.FantasyMatchup.AwayTeamID)
                .Include(p => p.PlayerNav).ThenInclude(p => p.StatsNav)
                .Include(p => p.PlayerNav).ThenInclude(p => p.TeamNav)
                .OrderBy(p => p.PlayerNav.Position)
                .AsNoTracking().ToListAsync();

            var matchupWeek = await _context.FantasyMatchupWeeks
                .Where(x => x.FantasyLeagueID == viewModel.FantasyMatchup.FantasyLeagueID)
                .Where(x => x.WeekNum == viewModel.FantasyMatchup.Week)
                .FirstOrDefaultAsync();

            int posCount = 1;

            foreach (var p in home)
            {
                var gameTonight = await _context.Game
                    .Include(g => g.PlayerGameStatsNav)
                    .Include(g => g.HomeTeamNav)
                    .Include(g => g.AwayTeamNav)
                    .Where(g => g.DateTime.Date == matchupWeek.Date)
                    .Where(g => g.AwayTeamID == p.PlayerNav.TeamID || g.HomeTeamID == p.PlayerNav.TeamID)
                    .FirstOrDefaultAsync();

                if (p.PlayerNav.Position == "C")
                {
                    viewModel.HomeRoster[p.PlayerNav.Position] = p.PlayerNav;
                    if (gameTonight != null)
                    {
                        viewModel.HomeOpp[p.PlayerNav.Position] = (gameTonight.AwayTeamID == p.PlayerNav.TeamID ? gameTonight.HomeTeamNav.WikipediaLogoUrl : gameTonight.AwayTeamNav.WikipediaLogoUrl);

                        var stats = await _context.PlayerGameStats
                        .Where(x => x.GameID == gameTonight.GameID)
                        .Where(x => x.PlayerID == p.PlayerID)
                        .FirstOrDefaultAsync();
                        if (stats != null)
                        {
                            viewModel.HomeStats[p.PlayerNav.Position + posCount] = stats;
                        }
                    }
                }
                else
                {
                    viewModel.HomeRoster[p.PlayerNav.Position + posCount] = p.PlayerNav;
                    if (gameTonight != null)
                    {
                        viewModel.HomeOpp[p.PlayerNav.Position + posCount] = (gameTonight.AwayTeamID == p.PlayerNav.TeamID ? gameTonight.HomeTeamNav.WikipediaLogoUrl : gameTonight.AwayTeamNav.WikipediaLogoUrl);
                        var stats = await _context.PlayerGameStats
                            .Where(x => x.GameID == gameTonight.GameID)
                            .Where(x => x.PlayerID == p.PlayerID)
                            .FirstOrDefaultAsync();
                        if (stats != null)
                        {
                            viewModel.HomeStats[p.PlayerNav.Position + posCount] = stats;
                        }
                    }
                    posCount = (posCount == 1 ? 2 : 1);
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

                if (p.PlayerNav.Position == "C")
                {
                    viewModel.AwayRoster[p.PlayerNav.Position] = p.PlayerNav;
                    if (gameTonight != null)
                    {
                        viewModel.AwayOpp[p.PlayerNav.Position] = (gameTonight.AwayTeamID == p.PlayerNav.TeamID ? gameTonight.HomeTeamNav.WikipediaLogoUrl : gameTonight.AwayTeamNav.WikipediaLogoUrl);
                        var stats = await _context.PlayerGameStats
                            .Where(x => x.GameID == gameTonight.GameID)
                            .Where(x => x.PlayerID == p.PlayerID)
                            .FirstOrDefaultAsync();
                        if (stats != null)
                        {
                            viewModel.AwayStats[p.PlayerNav.Position + posCount] = stats;
                        }
                    }
                }
                else
                {
                    viewModel.AwayRoster[p.PlayerNav.Position + posCount] = p.PlayerNav;
                    if (gameTonight != null)
                    {
                        viewModel.AwayOpp[p.PlayerNav.Position + posCount] = (gameTonight.AwayTeamID == p.PlayerNav.TeamID ? gameTonight.HomeTeamNav.WikipediaLogoUrl : gameTonight.AwayTeamNav.WikipediaLogoUrl);
                        var stats = await _context.PlayerGameStats
                            .Where(x => x.GameID == gameTonight.GameID)
                            .Where(x => x.PlayerID == p.PlayerID)
                            .FirstOrDefaultAsync();
                        if (stats != null)
                        {
                            viewModel.AwayStats[p.PlayerNav.Position + posCount] = stats;
                        }
                    }
                    posCount = (posCount == 1 ? 2 : 1);
                }
            }
            var week = await _context.FantasyMatchupWeeks
                .Where(w => w.WeekNum == viewModel.FantasyMatchup.Week)
                .Where(w => w.FantasyLeagueID == viewModel.FantasyMatchup.FantasyLeagueID)
                .FirstOrDefaultAsync();
            
            if(week == null)
            {
                viewModel.Date = DateTime.Today;
            }
            else
            {
                viewModel.Date = week.Date;
            }
            return View(viewModel);
        }

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

        // POST: FantasyMatchups/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public FantasyMatchup Edit(int id, [Bind("FantasyMatchupID,FantasyLeagueID,Week,Status,HomeTeamID,AwayTeamID,HomeTeamScore,AwayTeamScore")] FantasyMatchup fantasyMatchup)
        {
            if (id != fantasyMatchup.FantasyMatchupID)
            {
                return null;
            }

            if (ModelState.IsValid)
            {
                return fantasyMatchup;
            }

            return null;
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
