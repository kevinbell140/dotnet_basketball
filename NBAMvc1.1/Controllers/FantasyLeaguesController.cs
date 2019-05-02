using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NBAMvc1._1.Areas.Identity;
using NBAMvc1._1.Models;
using NBAMvc1._1.Services;
using NBAMvc1._1.ViewModels;

namespace NBAMvc1._1.Controllers
{
    public class FantasyLeaguesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly FantasyLeagueService _fantasyLeagueService;
        private readonly FantasyMatchupsWeeksService _fantasyMatchupsWeeksService;
        private readonly FantasyMatchupService _fantasyMatchupService;
        private readonly FantasyLeagueStandingsService _fantasyLeagueStandingsService;

        public FantasyLeaguesController(FantasyLeagueService fantasyLeagueService, UserManager<ApplicationUser> userManager, 
            FantasyMatchupsWeeksService fantasyMatchupsWeeksService, FantasyMatchupService fantasyMatchupService,
            FantasyLeagueStandingsService fantasyLeagueStandingsService)
        {
            _userManager = userManager;
            _fantasyLeagueService = fantasyLeagueService;
            _fantasyMatchupsWeeksService = fantasyMatchupsWeeksService;
            _fantasyMatchupService = fantasyMatchupService;
            _fantasyLeagueStandingsService = fantasyLeagueStandingsService;
        }

        // GET: FantasyLeagues
        public async Task<IActionResult> Index()
        {
            var leagues = await  _fantasyLeagueService.GetLeagues();
            return View(leagues);
        }

        // GET: FantasyLeagues/Details/5
        public async Task<IActionResult> Details(int? id, int? selectedWeek)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = new FantasyLeagueDetailsViewModel()
            {
                FantasyLeague = await _fantasyLeagueService.GetLeague(id.Value)
            };

            int currentWeek = 0;

            //gets the current week league
            if (viewModel.FantasyLeague.IsActive)
            {
                var weeks = await _fantasyMatchupsWeeksService.GetFantasyMatchupWeeksByLeague(viewModel.FantasyLeague.FantasyLeagueID);
                var thisWeek = _fantasyMatchupsWeeksService.GetThisWeek(weeks);

                if (thisWeek == null)
                {
                    _fantasyLeagueService.IsActiveFalseAsync(viewModel.FantasyLeague.FantasyLeagueID);
                    currentWeek = 14;
                }
                else
                {
                    currentWeek = thisWeek.WeekNum;
                }
            }
            viewModel.CurrentWeek = currentWeek;

            //browse between different matchup weeks
            if(selectedWeek == null)
            {
                viewModel.SelectedWeek = currentWeek;
            }
            else if(selectedWeek > 14)
            {
                viewModel.SelectedWeek = 14;
            }else if(selectedWeek < 1)
            {
                viewModel.SelectedWeek = 1;
            }
            else
            {
                viewModel.SelectedWeek = selectedWeek.Value;
            }

            viewModel.Teams = await _fantasyLeagueService.GetTeamsDictionary(viewModel.FantasyLeague.FantasyLeagueID);

            if (viewModel.FantasyLeague.IsSet)
            {
                //the matchups to display for the chosen week
                viewModel.Matchups = await _fantasyMatchupService.GetMatchupsByWeek(viewModel.FantasyLeague.FantasyLeagueID, viewModel.SelectedWeek);

                //all of the matchups prior to this week for updating purposes
                var matchupUpdates = await _fantasyMatchupService.GetMatchupsForUpdate(viewModel.FantasyLeague.FantasyLeagueID, currentWeek);
                var test = await _fantasyLeagueService.UpdateMatchups(matchupUpdates, currentWeek);



                //int numWeeks = await _fantasyMatchupService.WeeksThatNeedRecording(viewModel.FantasyLeague.FantasyLeagueID);

                //var test2 = await _fantasyLeagueStandingsService.UpdateStandings(matchupUpdates, currentWeek-1);

                //var test3 = await _fantasyLeagueService.StandingsRecorded(matchupUpdates, currentWeek-1);

                //var test4 = true;

            }
            return View(viewModel);
        }


        // GET: FantasyLeagues/Create
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: FantasyLeagues/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Create([Bind("FantasyLeagueID,Name,IsFull,IsSet,IsActive")] FantasyLeague fantasyLeague)
        {
            if (!User.IsInRole("Administrator"))
            {
                return new ChallengeResult();
            }
            fantasyLeague.CommissionerID = _userManager.GetUserId(User);

            if (ModelState.IsValid)
            {
                if (await _fantasyLeagueService.Create(fantasyLeague))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(fantasyLeague);
        }

        // GET: FantasyLeagues/Edit/5
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var fantasyLeague = await _fantasyLeagueService.GetLeague(id.Value);
            if (fantasyLeague == null)
            {
                return NotFound();
            }
            return View(fantasyLeague);
        }

        // POST: FantasyLeagues/Edit/5
        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FantasyLeagueID,Name,IsFull,IsSet,IsActive")] FantasyLeague fantasyLeague)
        {
            if (id != fantasyLeague.FantasyLeagueID)
            {
                return NotFound();
            }
            fantasyLeague.CommissionerID = _userManager.GetUserId(User);

            if (ModelState.IsValid && await _fantasyLeagueService.FantasyLeagueExists(id))
            {
                if(await _fantasyLeagueService.Edit(fantasyLeague))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(fantasyLeague);
        }

        // GET: FantasyLeagues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var fantasyLeague = await _fantasyLeagueService.GetLeague(id.Value);
            if (fantasyLeague == null)
            {
                return NotFound();
            }
            return View(fantasyLeague);
        }

        // POST: FantasyLeagues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await _fantasyLeagueService.Delete(id))
            {
                return RedirectToAction("Index", "FantasyLeagues");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}



//THIS NEEDS ITS OWN METHOD IN A SERVICE CLASS

//public async Task<List<FantasyLeagueStandings>> UpdateStandings(int id)
//{
//    var league = await _context.FantasyLeague
//        .Where(x => x.FantasyLeagueID == id)
//        .AsNoTracking().FirstOrDefaultAsync();

//    if(league == null)
//    {
//        return null; 
//    }

//    List<FantasyLeagueStandings> standings = await _context.FantasyLeagueStandings
//        .Where(x => x.FantasyLeagueID == league.FantasyLeagueID)
//        .AsNoTracking().ToListAsync();

//    List<FantasyMatchup> matchups = await _context.FantasyMatchup
//        .Where(x => x.FantasyLeagueID == league.FantasyLeagueID)
//        .Where(x => x.Status == "Final" && !x.Recorded)
//        .AsNoTracking().ToListAsync();


//    foreach(var m in matchups)
//    {
//        var homeStandings = standings.Find(x => x.MyTeamID == m.HomeTeamID);
//        int homeWins = homeStandings.Wins;
//        int homeLosses = homeStandings.Losses;
//        decimal homeFPS = homeStandings.FantasyPoints;

//        var awayStandings = standings.Find(x => x.MyTeamID == m.AwayTeamID);
//        int awayWins = awayStandings.Wins;
//        int awayLosses = awayStandings.Losses;
//        decimal awayFPS = awayStandings.FantasyPoints;


//        if (m.HomeTeamScore > m.AwayTeamScore)
//        {
//            homeStandings.Wins++;
//            awayStandings.Losses--;

//        }
//    }

//}