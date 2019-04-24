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
    public class FantasyLeagueStandingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FantasyLeagueStandingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FantasyLeagueStandings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FantasyLeagueStandings.Include(f => f.FantasyLeagueNav).Include(f => f.MyTeamNav);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FantasyLeagueStandings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fantasyLeagueStandings = await _context.FantasyLeagueStandings
                .Include(f => f.FantasyLeagueNav)
                .Include(f => f.MyTeamNav)
                .FirstOrDefaultAsync(m => m.FantasyLeagueStandingsID == id);
            if (fantasyLeagueStandings == null)
            {
                return NotFound();
            }

            return View(fantasyLeagueStandings);
        }

        // GET: FantasyLeagueStandings/Create
        public IActionResult Create()
        {
            ViewData["FantasyLeagueID"] = new SelectList(_context.FantasyLeague, "FantasyLeagueID", "FantasyLeagueID");
            ViewData["MyTeamID"] = new SelectList(_context.MyTeam, "MyTeamID", "MyTeamID");
            return View();
        }

        // POST: FantasyLeagueStandings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FantasyLeagueStandingsID,FantasyLeagueID,MyTeamID,Wins,Losses,Draws,FantasyPoints,FantasyPointsAgainst,GamesBack")] FantasyLeagueStandings fantasyLeagueStandings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fantasyLeagueStandings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FantasyLeagueID"] = new SelectList(_context.FantasyLeague, "FantasyLeagueID", "FantasyLeagueID", fantasyLeagueStandings.FantasyLeagueID);
            ViewData["MyTeamID"] = new SelectList(_context.MyTeam, "MyTeamID", "MyTeamID", fantasyLeagueStandings.MyTeamID);
            return View(fantasyLeagueStandings);
        }

        // GET: FantasyLeagueStandings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fantasyLeagueStandings = await _context.FantasyLeagueStandings.FindAsync(id);
            if (fantasyLeagueStandings == null)
            {
                return NotFound();
            }
            ViewData["FantasyLeagueID"] = new SelectList(_context.FantasyLeague, "FantasyLeagueID", "FantasyLeagueID", fantasyLeagueStandings.FantasyLeagueID);
            ViewData["MyTeamID"] = new SelectList(_context.MyTeam, "MyTeamID", "MyTeamID", fantasyLeagueStandings.MyTeamID);
            return View(fantasyLeagueStandings);
        }

        // POST: FantasyLeagueStandings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FantasyLeagueStandingsID,FantasyLeagueID,MyTeamID,Wins,Losses,Draws,FantasyPoints,FantasyPointsAgainst,GamesBack")] FantasyLeagueStandings fantasyLeagueStandings)
        {
            if (id != fantasyLeagueStandings.FantasyLeagueStandingsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fantasyLeagueStandings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FantasyLeagueStandingsExists(fantasyLeagueStandings.FantasyLeagueStandingsID))
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
            ViewData["FantasyLeagueID"] = new SelectList(_context.FantasyLeague, "FantasyLeagueID", "FantasyLeagueID", fantasyLeagueStandings.FantasyLeagueID);
            ViewData["MyTeamID"] = new SelectList(_context.MyTeam, "MyTeamID", "MyTeamID", fantasyLeagueStandings.MyTeamID);
            return View(fantasyLeagueStandings);
        }

        // GET: FantasyLeagueStandings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fantasyLeagueStandings = await _context.FantasyLeagueStandings
                .Include(f => f.FantasyLeagueNav)
                .Include(f => f.MyTeamNav)
                .FirstOrDefaultAsync(m => m.FantasyLeagueStandingsID == id);
            if (fantasyLeagueStandings == null)
            {
                return NotFound();
            }

            return View(fantasyLeagueStandings);
        }

        // POST: FantasyLeagueStandings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fantasyLeagueStandings = await _context.FantasyLeagueStandings.FindAsync(id);
            _context.FantasyLeagueStandings.Remove(fantasyLeagueStandings);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FantasyLeagueStandingsExists(int id)
        {
            return _context.FantasyLeagueStandings.Any(e => e.FantasyLeagueStandingsID == id);
        }
    }
}
