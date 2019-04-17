using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;

namespace NBAMvc1._1.Controllers
{
    public class FantasyMatchupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FantasyMatchupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FantasyMatchups
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FantasyMatchup.Include(f => f.AwayTeamNav).Include(f => f.FantasyLeagueNav).Include(f => f.HomeTeamNav);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FantasyMatchups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fantasyMatchup = await _context.FantasyMatchup
                .Include(f => f.AwayTeamNav)
                .Include(f => f.FantasyLeagueNav)
                .Include(f => f.HomeTeamNav)
                .FirstOrDefaultAsync(m => m.FantasyMatchupID == id);
            if (fantasyMatchup == null)
            {
                return NotFound();
            }

            return View(fantasyMatchup);
        }

        // GET: FantasyMatchups/Create
        public IActionResult Create()
        {
            ViewData["AwayTeamID"] = new SelectList(_context.MyTeam, "MyTeamID", "MyTeamID");
            ViewData["FantasyLeagueID"] = new SelectList(_context.FantasyLeague, "FantasyLeagueID", "FantasyLeagueID");
            ViewData["HomeTeamID"] = new SelectList(_context.MyTeam, "MyTeamID", "MyTeamID");
            return View();
        }

        // POST: FantasyMatchups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FantasyMatchupID,FantasyLeagueID,Week,Status,HomeTeamID,AwayTeamID,HomeTeamScore,AwayTeamScore")] FantasyMatchup fantasyMatchup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fantasyMatchup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AwayTeamID"] = new SelectList(_context.MyTeam, "MyTeamID", "MyTeamID", fantasyMatchup.AwayTeamID);
            ViewData["FantasyLeagueID"] = new SelectList(_context.FantasyLeague, "FantasyLeagueID", "FantasyLeagueID", fantasyMatchup.FantasyLeagueID);
            ViewData["HomeTeamID"] = new SelectList(_context.MyTeam, "MyTeamID", "MyTeamID", fantasyMatchup.HomeTeamID);
            return View(fantasyMatchup);
        }

        // GET: FantasyMatchups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fantasyMatchup = await _context.FantasyMatchup.FindAsync(id);
            if (fantasyMatchup == null)
            {
                return NotFound();
            }
            ViewData["AwayTeamID"] = new SelectList(_context.MyTeam, "MyTeamID", "MyTeamID", fantasyMatchup.AwayTeamID);
            ViewData["FantasyLeagueID"] = new SelectList(_context.FantasyLeague, "FantasyLeagueID", "FantasyLeagueID", fantasyMatchup.FantasyLeagueID);
            ViewData["HomeTeamID"] = new SelectList(_context.MyTeam, "MyTeamID", "MyTeamID", fantasyMatchup.HomeTeamID);
            return View(fantasyMatchup);
        }

        // POST: FantasyMatchups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FantasyMatchupID,FantasyLeagueID,Week,Status,HomeTeamID,AwayTeamID,HomeTeamScore,AwayTeamScore")] FantasyMatchup fantasyMatchup)
        {
            if (id != fantasyMatchup.FantasyMatchupID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fantasyMatchup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FantasyMatchupExists(fantasyMatchup.FantasyMatchupID))
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
            ViewData["AwayTeamID"] = new SelectList(_context.MyTeam, "MyTeamID", "MyTeamID", fantasyMatchup.AwayTeamID);
            ViewData["FantasyLeagueID"] = new SelectList(_context.FantasyLeague, "FantasyLeagueID", "FantasyLeagueID", fantasyMatchup.FantasyLeagueID);
            ViewData["HomeTeamID"] = new SelectList(_context.MyTeam, "MyTeamID", "MyTeamID", fantasyMatchup.HomeTeamID);
            return View(fantasyMatchup);
        }

        // GET: FantasyMatchups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fantasyMatchup = await _context.FantasyMatchup
                .Include(f => f.AwayTeamNav)
                .Include(f => f.FantasyLeagueNav)
                .Include(f => f.HomeTeamNav)
                .FirstOrDefaultAsync(m => m.FantasyMatchupID == id);
            if (fantasyMatchup == null)
            {
                return NotFound();
            }

            return View(fantasyMatchup);
        }

        // POST: FantasyMatchups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fantasyMatchup = await _context.FantasyMatchup.FindAsync(id);
            _context.FantasyMatchup.Remove(fantasyMatchup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FantasyMatchupExists(int id)
        {
            return _context.FantasyMatchup.Any(e => e.FantasyMatchupID == id);
        }
    }
}
