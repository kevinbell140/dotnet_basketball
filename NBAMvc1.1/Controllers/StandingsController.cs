using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using NBAMvc1._1.Services;

namespace NBAMvc1._1.Controllers
{
    public class StandingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly DataService _service;

        public StandingsController(ApplicationDbContext context, DataService service)
        {
            _context = context;
            _service = service;
        }


        // GET: Standings
        public async Task<IActionResult> Index(string filter = "Eastern")
        {
            ViewData["filter"] = filter;

            List<Standings> standings = await _context.Standings
                .Include(s => s.TeamNav)
                .Where(s => s.TeamNav.Conference == filter)
                .OrderBy(s => s.GamesBack)
                .ToListAsync();

            return View(standings);

        }


        // GET: Standings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standings = await _context.Standings
                .Include(s => s.TeamNav)
                .FirstOrDefaultAsync(m => m.TeamID == id);
            if (standings == null)
            {
                return NotFound();
            }

            return View(standings);
        }

        // GET: Standings/Create
        private IActionResult Create()
        {
            ViewData["TeamID"] = new SelectList(_context.Team, "TeamID", "Key");
            return View();
        }

        // POST: Standings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeamID,Wins,Losses,Percentage,ConferenceWins,ConferenceLosses,DivisionWins,DivisionLosses,HomeWins,HomeLosses,AwayWins,AwayLosses,LastTenWins,LastTenLosses,Streak,GamesBack")] Standings standings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(standings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamID"] = new SelectList(_context.Team, "TeamID", "Key", standings.TeamID);
            return View(standings);
        }

        // GET: Standings/Edit/5
        private async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standings = await _context.Standings.FindAsync(id);
            if (standings == null)
            {
                return NotFound();
            }
            ViewData["TeamID"] = new SelectList(_context.Team, "TeamID", "Key", standings.TeamID);
            return View(standings);
        }

        // POST: Standings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        private async Task<IActionResult> Edit(int id, [Bind("TeamID,Wins,Losses,Percentage,ConferenceWins,ConferenceLosses,DivisionWins,DivisionLosses,HomeWins,HomeLosses,AwayWins,AwayLosses,LastTenWins,LastTenLosses,Streak,GamesBack")] Standings standings)
        {
            if (id != standings.TeamID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(standings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StandingsExists(standings.TeamID))
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
            ViewData["TeamID"] = new SelectList(_context.Team, "TeamID", "Key", standings.TeamID);
            return View(standings);
        }

        // GET: Standings/Delete/5
        private async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standings = await _context.Standings
                .Include(s => s.TeamNav)
                .FirstOrDefaultAsync(m => m.TeamID == id);
            if (standings == null)
            {
                return NotFound();
            }

            return View(standings);
        }

        // POST: Standings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        private async Task<IActionResult> DeleteConfirmed(int id)
        {
            var standings = await _context.Standings.FindAsync(id);
            _context.Standings.Remove(standings);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StandingsExists(int id)
        {
            return _context.Standings.Any(e => e.TeamID == id);
        }

        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Fetch()
        {
            var standings = await _service.FetchStandings();

            foreach (Standings s in standings)
            {
                var exists = await _context.Standings.AnyAsync(a => a.TeamID == s.TeamID);

                if (!exists)
                {
                    await Create(s);
                }
                else
                {
                    await Edit(s.TeamID, s);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
