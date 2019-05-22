using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NBAMvc1._1.Areas.Identity;
using NBAMvc1._1.Models;
using NBAMvc1._1.Services;
using NBAMvc1._1.Services.Interfaces;
using NBAMvc1._1.ViewModels;

namespace NBAMvc1._1.Controllers
{
    public class FantasyLeaguesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFantasyLeagueService _fantasyLeagueService;
        private readonly IFantasyMatchupService _fantasyMatchupService;

        public FantasyLeaguesController(IFantasyLeagueService fantasyLeagueService, UserManager<ApplicationUser> userManager, 
            IFantasyMatchupService fantasyMatchupService)
        {
            _userManager = userManager;
            _fantasyLeagueService = fantasyLeagueService;
            _fantasyMatchupService = fantasyMatchupService;
        }

        // GET: FantasyLeagues
        public async Task<IActionResult> Index()
        {
            var viewModel = new FantasyLeagueIndexViewModel();

            var openTask = _fantasyLeagueService.GetOpenLeaguesAsync();
            var closedTask = _fantasyLeagueService.GetClosedLeaguesAsync();
            var tasks = new List<Task> { openTask, closedTask };
            while (tasks.Any())
            {
                var finished = await Task.WhenAny(tasks);
                if(finished == openTask)
                {
                    tasks.Remove(openTask);
                    viewModel.OpenLeagues = await openTask;
                }else if(finished == closedTask)
                {
                    tasks.Remove(closedTask);
                    viewModel.ClosedLeagues = await closedTask;
                }
                else
                {
                    tasks.Remove(finished);
                }
            }
            return View(viewModel);
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
                FantasyLeague = await _fantasyLeagueService.GetLeagueAsync(id.Value)
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

            viewModel.Teams = await _fantasyLeagueService.GetTeamsDictionaryAsync(viewModel.FantasyLeague.FantasyLeagueID);
            if (viewModel.FantasyLeague.IsSet)
            {
                viewModel.Matchups = await _fantasyMatchupService.GetMatchupsByWeekAsync(viewModel.FantasyLeague.FantasyLeagueID, viewModel.SelectedWeek);
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
                await _fantasyLeagueService.Create(fantasyLeague);
                return RedirectToAction("Details", "FantasyLeagues", new { id = fantasyLeague.FantasyLeagueID });
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
            var fantasyLeague = await _fantasyLeagueService.GetLeagueAsync(id.Value);
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
                await _fantasyLeagueService.Edit(fantasyLeague);
                return RedirectToAction("Details", "FantasyLeagues", new { id = fantasyLeague.FantasyLeagueID });
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
            var fantasyLeague = await _fantasyLeagueService.GetLeagueAsync(id.Value);
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
            await _fantasyLeagueService.Delete(id);
            return RedirectToAction("Index", "FantasyLeagues");
        }
    }
}