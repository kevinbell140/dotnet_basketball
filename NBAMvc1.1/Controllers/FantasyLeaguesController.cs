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
using NBAMvc1._1.ViewModels;

namespace NBAMvc1._1.Controllers
{
    public class FantasyLeaguesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthorizationService _auth;

        public FantasyLeaguesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IAuthorizationService auth)
        {
            _context = context;
            _userManager = userManager;
            _auth = auth;
        }

        // GET: FantasyLeagues
        public async Task<IActionResult> Index()
        {
            return View(await _context.FantasyLeague.ToListAsync());
        }

        // GET: FantasyLeagues/Details/5
        public async Task<IActionResult> Details(int? id)
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
   
            if (viewModel.FantasyLeague == null)
            {
                return NotFound();
            }

            int count = 1;

            var teams = viewModel.FantasyLeague.TeamsNav.ToList();

            Dictionary<int, MyTeam> registered = new Dictionary<int, MyTeam>();

            foreach(var t in teams)
            {
                registered.Add(count++, t);
            }

            foreach(KeyValuePair<int, MyTeam> entry in registered)
            {
                viewModel.Teams[entry.Key] = entry.Value;
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

            if (!league.isFull)
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
                league.isFull = false;
            }
            else
            {
                league.isFull = true;
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

            league.isFull = false;

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
