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
        private readonly FantasyMatchupService _fantasyMatchupService;

        public FantasyLeaguesController(FantasyLeagueService fantasyLeagueService, UserManager<ApplicationUser> userManager, 
            FantasyMatchupService fantasyMatchupService)
        {
            _userManager = userManager;
            _fantasyLeagueService = fantasyLeagueService;
            _fantasyMatchupService = fantasyMatchupService;
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
            viewModel.CurrentWeek = viewModel.FantasyLeague.CurrentWeek;

            //for browsing matchups
            if(selectedWeek == null)
            {
                viewModel.SelectedWeek = viewModel.CurrentWeek;
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
                //TODO : display standings

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
            var fantasyLeague = await _fantasyLeagueService.GetLeague(id);
            return View(fantasyLeague);
        }
    }
}