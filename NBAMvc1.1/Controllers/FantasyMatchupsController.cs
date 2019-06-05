using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using NBAMvc1._1.Services;
using NBAMvc1._1.Services.Interfaces;
using NBAMvc1._1.ViewModels;

namespace NBAMvc1._1.Controllers
{
    public class FantasyMatchupsController : Controller
    {
        private readonly IFantasyMatchupService _fantasyMatchupService;
        private readonly IFantasyLeagueService _fantasyLeagueService;
        private readonly IFantasyMatchupsWeeksService _fantasyMatchupsWeeksService;
        private readonly IPlayerMyTeamService _playerMyTeamService;

        public FantasyMatchupsController(IFantasyMatchupService fantasyMatchupService, IFantasyLeagueService fantasyLeagueService,
            IFantasyMatchupsWeeksService fantasyMatchupsWeeksService, IPlayerMyTeamService playerMyTeamService)
        {
            _fantasyMatchupService = fantasyMatchupService;
            _fantasyLeagueService = fantasyLeagueService;
            _fantasyMatchupsWeeksService = fantasyMatchupsWeeksService;
            _playerMyTeamService = playerMyTeamService;
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
                FantasyMatchup = await _fantasyMatchupService.GetMatchupByIDAsync(id.Value)
            };

            var matchupWeek = await _fantasyMatchupsWeeksService.GetFantasyMatchupWeekByLeagueAsync(viewModel.FantasyMatchup.FantasyLeagueID, viewModel.FantasyMatchup.Week);
            viewModel.Date = matchupWeek.Date;

            var homeRosterTask = _playerMyTeamService.GetRosterDictionaryAsync(viewModel.FantasyMatchup.HomeTeamID.Value);
            var awayRosterTask = _playerMyTeamService.GetRosterDictionaryAsync(viewModel.FantasyMatchup.AwayTeamID.Value);
            var rosterTasks = new List<Task> { homeRosterTask, awayRosterTask };
            while (rosterTasks.Any())
            {
                Task finsihed = await Task.WhenAny(rosterTasks);
                if (finsihed == homeRosterTask)
                {
                    rosterTasks.Remove(homeRosterTask);
                    viewModel.HomeRoster = await homeRosterTask;
                }
                else if (finsihed == awayRosterTask)
                {
                    rosterTasks.Remove(awayRosterTask);
                    viewModel.AwayRoster = await awayRosterTask;
                }
                else
                {
                    rosterTasks.Remove(finsihed);
                }
            }
            
            var homeOppTask = _fantasyMatchupService.GetOpponentLogoDictionaryAsync(viewModel.HomeRoster, matchupWeek);
            var homeStatsTask = _fantasyMatchupService.GetGameStatsDictionaryAsync(viewModel.HomeRoster, matchupWeek);
            var awayOppTask = _fantasyMatchupService.GetOpponentLogoDictionaryAsync(viewModel.AwayRoster, matchupWeek);
            var awayStatsTask = _fantasyMatchupService.GetGameStatsDictionaryAsync(viewModel.AwayRoster, matchupWeek);
            var viewTasks = new List<Task> { homeStatsTask, homeOppTask, awayOppTask, awayStatsTask };
            while (viewTasks.Any())
            {
                Task finished = await Task.WhenAny(viewTasks);
                if(finished == homeOppTask)
                {
                    viewTasks.Remove(homeOppTask);
                    viewModel.HomeOpp = await homeOppTask;
                }
                else if(finished == homeStatsTask)
                {
                    viewTasks.Remove(homeStatsTask);
                    viewModel.HomeStats = await homeStatsTask;
                }
                else if(finished == awayOppTask)
                {
                    viewTasks.Remove(awayOppTask);
                    viewModel.AwayOpp = await awayOppTask;
                }
                else if(finished == awayStatsTask)
                {
                    viewTasks.Remove(awayStatsTask);
                    viewModel.AwayStats = await awayStatsTask;
                }
                else {
                    viewTasks.Remove(finished);
                }
            }
            return View(viewModel);
        }

        public async Task<ActionResult> RefreshViewModel([FromQuery]int id)
        {

            var matchup = await _fantasyMatchupService.GetMatchupByIDAsync(id);

            var matchupWeek = await _fantasyMatchupsWeeksService.GetFantasyMatchupWeekByLeagueAsync(matchup.FantasyLeagueID, matchup.Week);
            var date = matchupWeek.Date;

            var homeRosterTask = _playerMyTeamService.GetRosterDictionaryAsync(matchup.HomeTeamID.Value);
            var awayRosterTask = _playerMyTeamService.GetRosterDictionaryAsync(matchup.AwayTeamID.Value);
            IDictionary<string, Player> homeRoster = new Dictionary<string, Player>();
            IDictionary<string, Player> awayRoster = new Dictionary<string, Player>();
            var rosterTasks = new List<Task> { homeRosterTask, awayRosterTask };
            while (rosterTasks.Any())
            {
                Task finsihed = await Task.WhenAny(rosterTasks);
                if (finsihed == homeRosterTask)
                {
                    rosterTasks.Remove(homeRosterTask);
                    homeRoster = await homeRosterTask;
                }
                else if (finsihed == awayRosterTask)
                {
                    rosterTasks.Remove(awayRosterTask);
                    awayRoster = await awayRosterTask;
                }
                else
                {
                    rosterTasks.Remove(finsihed);
                }
            }

            var homeStatsTask = _fantasyMatchupService.GetGameStatsDictionaryAsync(homeRoster, matchupWeek);
            IDictionary<string, PlayerGameStats> homeStats = new Dictionary<string, PlayerGameStats>();
            var awayStatsTask = _fantasyMatchupService.GetGameStatsDictionaryAsync(awayRoster, matchupWeek);
            IDictionary<string, PlayerGameStats> awayStats = new Dictionary<string, PlayerGameStats>();
            var viewTasks = new List<Task> { homeStatsTask, awayStatsTask };
            while (viewTasks.Any())
            {
                Task finished = await Task.WhenAny(viewTasks);
                if (finished == homeStatsTask)
                {
                    viewTasks.Remove(homeStatsTask);
                    homeStats = await homeStatsTask;
                }
                else if (finished == awayStatsTask)
                {
                    viewTasks.Remove(awayStatsTask);
                    awayStats = await awayStatsTask;
                }
                else
                {
                    viewTasks.Remove(finished);
                }
            }

            return Json(new { homeRoster = homeRoster, homeStats = homeStats, awayRoster = awayRoster, awayStats = awayStats });
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet]
        public async Task<IActionResult> Create(int leagueID)
        {
            var fantasyLeague = await _fantasyLeagueService.GetLeagueAsync(leagueID);
            if(fantasyLeague == null)
            {
                return NotFound();
            }
            if (!fantasyLeague.IsFull)
            {
                TempData["NotSet"] = "League needs to be set first boss...";
                return RedirectToAction("Details", "FantasyLeagues", new { id = leagueID });
            }
            await _fantasyMatchupService.Create(fantasyLeague);
            return RedirectToAction("Details", "FantasyLeagues", new { id = leagueID });
        }
    }
}
