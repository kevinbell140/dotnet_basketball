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

        public FantasyLeaguesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IAuthorizationService auth, FantasyMatchupsController fantasyMatchupsController)
        {
            _context = context;
            _userManager = userManager;
            _auth = auth;
            _fantasyMatchupsController = fantasyMatchupsController;
        }

        // GET: FantasyLeagues
        public async Task<IActionResult> Index()
        {
            return View(await _context.FantasyLeague.ToListAsync());
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
                FantasyLeague = await _context.FantasyLeague
                .Include(m => m.TeamsNav).ThenInclude(m => m.UserNav)
                .Include(m => m.ComissionerNav)
                .FirstOrDefaultAsync(m => m.FantasyLeagueID == id)
            };

            int currentWeek = 0;

            //gets the current week league
            if (viewModel.FantasyLeague.IsActive)
            {
                var weeks = _context.FantasyMatchupWeeks
                    .Where(f => f.FantasyLeagueID == id)
                    .AsNoTracking();

                var thisWeek = weeks
                    .Where(w => w.Date == DateTime.Today)
                    .FirstOrDefault();

                if (thisWeek == null)
                {
                    await IsActiveFalseAsync(id);
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

            int count = 1;

            viewModel.Teams = viewModel.FantasyLeague.TeamsNav.ToDictionary(x => count++, x => x);

            if (viewModel.FantasyLeague.IsSet)
            {
                viewModel.Matchups = await _context.FantasyMatchup
                    .Include(m => m.AwayTeamNav)
                    .Include(m => m.HomeTeamNav)
                    .Where(m => m.FantasyLeagueID == id && m.Week == viewModel.SelectedWeek)
                    .AsNoTracking().ToListAsync();

                List<FantasyMatchup> updateList = new List<FantasyMatchup>();

                foreach (var m in viewModel.Matchups)
                {
                    if(m.Week <= currentWeek)
                    {
                        //update matchup status
                        updateList = await UpdateMatchupStatus(m.FantasyMatchupID, currentWeek, updateList);
                        //check for game stat records
                        //if there are records then,
                        //calculate score
                        //update score
                        //update league standings
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

        private async Task<List<FantasyMatchup>> UpdateMatchupScores(int id, int[] scores, List<FantasyMatchup> updateList)
        {
            var matchup = await _context.FantasyMatchup
                .Where(x => x.FantasyMatchupID == id)
                .AsNoTracking().FirstOrDefaultAsync();

            matchup.HomeTeamScore = scores[0];
            matchup.AwayTeamScore = scores[1];

            FantasyMatchup updatedMatch = _fantasyMatchupsController.Edit(matchup.FantasyMatchupID, matchup);
            if (updatedMatch != null)
            {
                updateList.Add(updatedMatch);
            }
            return updateList;
        }

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
        public async Task<IActionResult> Create([Bind("FantasyLeagueID,Name,isFull")] FantasyLeague fantasyLeague)
        {

            if (!User.IsInRole("Administrator"))
            {
                return new ChallengeResult();
            }

            fantasyLeague.CommissionerID = _userManager.GetUserId(User);
            fantasyLeague.IsActive = false;

            if (ModelState.IsValid)
            {
                _context.Add(fantasyLeague);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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

            var fantasyLeague = await _context.FantasyLeague.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("FantasyLeagueID,CommissionerID,Name,isFull")] FantasyLeague fantasyLeague)
        {
            if (id != fantasyLeague.FantasyLeagueID)
            {
                return NotFound();
            }
            fantasyLeague.CommissionerID = _userManager.GetUserId(User);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fantasyLeague);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FantasyLeagueExists(fantasyLeague.FantasyLeagueID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
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

            var fantasyLeague = await _context.FantasyLeague
                .FirstOrDefaultAsync(m => m.FantasyLeagueID == id);
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
            var fantasyLeague = await _context.FantasyLeague.FindAsync(id);
            _context.FantasyLeague.Remove(fantasyLeague);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FantasyLeagueExists(int id)
        {
            return _context.FantasyLeague.Any(e => e.FantasyLeagueID == id);
        }

        public async Task<IActionResult> AddTeam(int? id)
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

            if (!league.IsFull)
            {
                if (league.TeamsNav == null || league.TeamsNav.Count() < 8)
                {
                    return RedirectToAction("Create", "MyTeams", new { leagueID = league.FantasyLeagueID });
                }
            }
            return RedirectToAction("Details", "FantasyLeagues", new { id = league.FantasyLeagueID });
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

        public async Task<IActionResult> IsActiveFalseAsync(int? id)
        {
            var league = await _context.FantasyLeague
                .Where(l => l.FantasyLeagueID == id)
                .FirstOrDefaultAsync();

            if (league == null)
            {
                return NotFound();
            }
            
            league.IsActive = false;

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
