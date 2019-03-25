using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using NBAMvc1._1.Services;

namespace NBAMvc1._1.Controllers
{
    public class PlayerSeasonStatsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly DataService _service;

        public PlayerSeasonStatsController(ApplicationDbContext context, DataService service)
        {
            _context = context;
            _service = service;
        }

        public async Task<ActionResult> Fetch()
        {
            var stats = await _service.FetchStats();

            foreach(PlayerSeasonStats s in stats)
            {
                var exists = await _context.PlayerSeasonStats.AnyAsync(a => a.StatID == s.StatID);

                if (!exists)
                {
                    await Create(s);
                }
                else
                {
                    await Edit(s.StatID, s);
                }
            }
            return RedirectToAction("Index");

        }

        // GET: PlayerSeasonStats
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PlayerSeasonStats.Include(p => p.PlayNav);
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: PlayerSeasonStats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerSeasonStats = await _context.PlayerSeasonStats
                .Include(p => p.PlayNav)
                .FirstOrDefaultAsync(m => m.StatID == id);
            if (playerSeasonStats == null)
            {
                return NotFound();
            }

            return View(playerSeasonStats);
        }

        // GET: PlayerSeasonStats/Create
        public IActionResult Create()
        {
            ViewData["PlayerID"] = new SelectList(_context.Player, "PlayerID", "PlayerID");
            return View();
        }

        // POST: PlayerSeasonStats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatID,PlayerID,Games,FieldGoalsPercentage,FreeThrowsPercentage,ThreePointersMade,Points,Assists,Rebounds,Steals,BlockedShots,Turnovers")] PlayerSeasonStats playerSeasonStats)
        {
            if (ModelState.IsValid)
            {
                Boolean playerExists = await _context.Player.AnyAsync(a => a.PlayerID == playerSeasonStats.PlayerID);

                if (!playerExists)
                {
                    return RedirectToAction(nameof(Index));
                }
                _context.Add(playerSeasonStats);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlayerID"] = new SelectList(_context.Player, "PlayerID", "PlayerID", playerSeasonStats.PlayerID);
            return View(playerSeasonStats);
        }

        // GET: PlayerSeasonStats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerSeasonStats = await _context.PlayerSeasonStats.FindAsync(id);
            if (playerSeasonStats == null)
            {
                return NotFound();
            }
            ViewData["PlayerID"] = new SelectList(_context.Player, "PlayerID", "PlayerID", playerSeasonStats.PlayerID);
            return View(playerSeasonStats);
        }

        // POST: PlayerSeasonStats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StatID,PlayerID,Games,FieldGoalsPercentage,FreeThrowsPercentage,ThreePointersMade,Points,Assists,Rebounds,Steals,BlockedShots,Turnovers")] PlayerSeasonStats playerSeasonStats)
        {
            if (id != playerSeasonStats.StatID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerSeasonStats);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerSeasonStatsExists(playerSeasonStats.StatID))
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
            ViewData["PlayerID"] = new SelectList(_context.Player, "PlayerID", "PlayerID", playerSeasonStats.PlayerID);
            return View(playerSeasonStats);
        }

        // GET: PlayerSeasonStats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerSeasonStats = await _context.PlayerSeasonStats
                .Include(p => p.PlayNav)
                .FirstOrDefaultAsync(m => m.StatID == id);
            if (playerSeasonStats == null)
            {
                return NotFound();
            }

            return View(playerSeasonStats);
        }

        // POST: PlayerSeasonStats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playerSeasonStats = await _context.PlayerSeasonStats.FindAsync(id);
            _context.PlayerSeasonStats.Remove(playerSeasonStats);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerSeasonStatsExists(int id)
        {
            return _context.PlayerSeasonStats.Any(e => e.StatID == id);
        }
    }
}
