using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NBAMvc1._1.Data;
using NBAMvc1._1.Services;
using NBAMvc1._1.ViewModels;

namespace NBAMvc1._1.Controllers
{
    public class FantasyMatchupsController : Controller
    {
        private readonly FantasyMatchupService _fantasyMatchupService;
        private readonly FantasyLeagueService _fantasyLeagueService;
        private readonly FantasyMatchupsWeeksService _fantasyMatchupsWeeksService;
        private readonly PlayerMyTeamService _playerMyTeamService;


        public FantasyMatchupsController(FantasyMatchupService fantasyMatchupService, FantasyLeagueService fantasyLeagueService,
            FantasyMatchupsWeeksService fantasyMatchupsWeeksService, PlayerMyTeamService playerMyTeamService)
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
                FantasyMatchup = await _fantasyMatchupService.GetMatchupByID(id.Value)
            };

            var matchupWeek = await _fantasyMatchupsWeeksService.GetFantasyMatchupWeekByLeague(viewModel.FantasyMatchup.FantasyLeagueID, viewModel.FantasyMatchup.Week);
            viewModel.Date = matchupWeek.Date;

            viewModel.HomeRoster = await _playerMyTeamService.GetRosterDictionaryAsync(viewModel.FantasyMatchup.HomeTeamID.Value);
            viewModel.HomeOpp = await _fantasyMatchupService.GetOpponentLogoDictionary(viewModel.HomeRoster, matchupWeek);
            viewModel.HomeStats = await _fantasyMatchupService.GetGameStatsDictionary(viewModel.HomeRoster, matchupWeek);

            viewModel.AwayRoster = await _playerMyTeamService.GetRosterDictionaryAsync(viewModel.FantasyMatchup.AwayTeamID.Value);
            viewModel.AwayOpp = await _fantasyMatchupService.GetOpponentLogoDictionary(viewModel.AwayRoster, matchupWeek);
            viewModel.AwayStats = await _fantasyMatchupService.GetGameStatsDictionary(viewModel.AwayRoster, matchupWeek);

            return View(viewModel);
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
    }
}
