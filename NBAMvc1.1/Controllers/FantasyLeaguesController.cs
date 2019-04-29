using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBAMvc1._1.Areas.Identity;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using NBAMvc1._1.Services;
using NBAMvc1._1.Utils;
using NBAMvc1._1.ViewModels;

namespace NBAMvc1._1.Controllers
{
    public class FantasyLeaguesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthorizationService _auth;
        private readonly FantasyMatchupsController _fantasyMatchupsController;
        private readonly FantasyLeagueStandingsController _fantasyLeagueStandingsController;
        private readonly FantasyLeagueService _fantasyLeagueService;
        private readonly FantasyMatchupsWeeksService _fantasyMatchupsWeeksService;
        private readonly FantasyMatchupService _fantasyMatchupService;

        public FantasyLeaguesController(FantasyLeagueService fantasyLeagueService, ApplicationDbContext context, UserManager<ApplicationUser> userManager, IAuthorizationService auth, 
            FantasyMatchupsController fantasyMatchupsController, FantasyLeagueStandingsController fantasyLeagueStandingsController,
            FantasyMatchupsWeeksService fantasyMatchupsWeeksService, FantasyMatchupService fantasyMatchupService)
        {
            _context = context;
            _userManager = userManager;
            _auth = auth;
            _fantasyMatchupsController = fantasyMatchupsController;
            _fantasyLeagueStandingsController = fantasyLeagueStandingsController;
            _fantasyLeagueService = fantasyLeagueService;
            _fantasyMatchupsWeeksService = fantasyMatchupsWeeksService;
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

                //Went to go work on matchups service

                ////THIS NEEDS TO BE DONE STILL
                List<FantasyMatchup> updateList = new List<FantasyMatchup>();

                foreach (var m in matchupUpdates)
                {
                    if(m.Week <= currentWeek)
                    {
                        updateList = await UpdateMatchupStatus(m.FantasyMatchupID, currentWeek, updateList);
                    }
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.UpdateRange(updateList);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        throw;
                    }
                    return View(viewModel);
                }               
            }
            return View(viewModel);
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

        private async Task<List<FantasyMatchup>> UpdateMatchupStatus(int id, int currentWeek, List<FantasyMatchup> updateList)
        {
            var matchup = await _context.FantasyMatchup
                .Where(x => x.FantasyMatchupID == id)
                .AsNoTracking().FirstOrDefaultAsync();

            if(matchup.Week < currentWeek)
            {
                matchup.Status = "Final";
            }else
            {
                matchup.Status = "In Progress";
            }

            var scores = await _fantasyMatchupsController.CalculateScore(matchup.FantasyMatchupID);

            matchup.HomeTeamScore = scores[0];
            matchup.AwayTeamScore = scores[1];

            FantasyMatchup updatedMatch = _fantasyMatchupsController.Edit(matchup.FantasyMatchupID, matchup);
            if(updatedMatch != null)
            {
                updateList.Add(updatedMatch);
            }
            return updateList;
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

        private bool FantasyLeagueExists(int id)
        {
            return _context.FantasyLeague.Any(e => e.FantasyLeagueID == id);
        }


        public async Task<IActionResult> AddTeamConfirm(int? id) 
        {
            if(id == null)
            {
                return NotFound();
            }

            var league = await _context.FantasyLeague
                .Include(l => l.TeamsNav)
                .Where(l => l.FantasyLeagueID == id)
                .FirstOrDefaultAsync();

            if (league == null)
            {
                return NotFound();
            }

            if (league.TeamsNav.Count() < 8 )
            {
                league.IsFull = false;
            }
            else
            {
                league.IsFull = true;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(league);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FantasyLeagueExists(league.FantasyLeagueID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "FantasyLeagues", new { id = league.FantasyLeagueID });
            }
            return RedirectToAction("Details", "FantasyLeagues", new { id = league.FantasyLeagueID });
        }


        public async Task<IActionResult> RemoveTeam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var league = await _context.FantasyLeague
                .Where(l => l.FantasyLeagueID == id)
                .FirstOrDefaultAsync();

            if (league == null)
            {
                return NotFound();
            }

            league.IsFull = false;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(league);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FantasyLeagueExists(league.FantasyLeagueID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "FantasyLeagues", new { id = league.FantasyLeagueID });
            }
            return RedirectToAction("Details", "FantasyLeagues", new { id = league.FantasyLeagueID });
        }
        public async Task<IActionResult> IsSetConfrim(int id)
        {
            var league = await _context.FantasyLeague
                .Where(l => l.FantasyLeagueID == id)
                .FirstOrDefaultAsync();

            if(league == null)
            {
                return NotFound();
            }

            league.IsSet = true;
            league.IsActive = true;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(league);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FantasyLeagueExists(league.FantasyLeagueID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "FantasyLeagues", new { id = league.FantasyLeagueID });
            }
            return RedirectToAction("Details", "FantasyLeagues", new { id = league.FantasyLeagueID });
        }
    }
}
