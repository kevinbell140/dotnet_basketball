using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBAMvc1._1.Data;
using NBAMvc1._1.Services;

namespace NBAMvc1._1.Models
{
    [Authorize(Policy = "AdminOnly")]
    public class PlayerGameStatsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly DataService _service;

        public PlayerGameStatsController(ApplicationDbContext context, DataService service)
        {
            _context = context;
            _service = service;
        }

        // GET: PlayerGameStats
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PlayerGameStats.Include(p => p.GameNav).Include(p => p.PlayerNav);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PlayerGameStats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerGameStats = await _context.PlayerGameStats
                .Include(p => p.GameNav)
                .Include(p => p.PlayerNav)
                .FirstOrDefaultAsync(m => m.StatID == id);
            if (playerGameStats == null)
            {
                return NotFound();
            }

            return View(playerGameStats);
        }

        // GET: PlayerGameStats/Create
        public IActionResult Create()
        {
            ViewData["GameID"] = new SelectList(_context.Game, "GameID", "GameID");
            ViewData["PlayerID"] = new SelectList(_context.Player, "PlayerID", "PlayerID");
            return View();
        }

        // POST: PlayerGameStats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public PlayerGameStats Create([Bind("StatID,PlayerID,GameID,Updated,Minutes,FieldGoalsMade,FieldGoalsAttempted,FieldGoalsPercentage,ThreePointersMade,ThreePointersAttempted,ThreePointersPercentage,FreeThrowsMade,FreeThrowsAttempted,FreeThrowsPercentage,OffensiveRebounds,DefensiveRebounds,Rebounds,Assists,Steals,BlockedShots,Turnovers,PersonalFouls,Points,PlusMinus,Started")] PlayerGameStats playerGameStats)
        {      
            if (ModelState.IsValid)
            {
                return playerGameStats;
            }
            return null;

        }

        // GET: PlayerGameStats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerGameStats = await _context.PlayerGameStats.FindAsync(id);
            if (playerGameStats == null)
            {
                return NotFound();
            }
            ViewData["GameID"] = new SelectList(_context.Game, "GameID", "GameID", playerGameStats.GameID);
            ViewData["PlayerID"] = new SelectList(_context.Player, "PlayerID", "PlayerID", playerGameStats.PlayerID);
            return View(playerGameStats);
        }

        // POST: PlayerGameStats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public PlayerGameStats Edit(int id, [Bind("StatID,PlayerID,Updated,Minutes,FieldGoalsMade,FieldGoalsAttempted,FieldGoalsPercentage,ThreePointersMade,ThreePointersAttempted,ThreePointersPercentage,FreeThrowsMade,FreeThrowsAttempted,FreeThrowsPercentage,OffensiveRebounds,DefensiveRebounds,Rebounds,Assists,Steals,BlockedShots,Turnovers,PersonalFouls,Points,PlusMinus,Started")] PlayerGameStats playerGameStats)
        {
            if (id != playerGameStats.StatID)
            {
                return null;
            }

            if (ModelState.IsValid)
            {
                return playerGameStats;
            }

            return null;
        }

        // GET: PlayerGameStats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerGameStats = await _context.PlayerGameStats
                .Include(p => p.GameNav)
                .Include(p => p.PlayerNav)
                .FirstOrDefaultAsync(m => m.StatID == id);
            if (playerGameStats == null)
            {
                return NotFound();
            }

            return View(playerGameStats);
        }

        // POST: PlayerGameStats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playerGameStats = await _context.PlayerGameStats.FindAsync(id);
            _context.PlayerGameStats.Remove(playerGameStats);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerGameStatsExists(int id)
        {
            return _context.PlayerGameStats.Any(e => e.StatID == id);
        }


        //GET : Teams/Fetch()
        public async Task<IActionResult> Fetch()
        {
            //logic to fetch all missing data
            DateTime startDate = new DateTime(2019, 04, 15);
            DateTime endDate = DateTime.Today;

            List<PlayerGameStats> created = new List<PlayerGameStats>();
            List<PlayerGameStats> updated = new List<PlayerGameStats>();

            for (DateTime d = startDate; d < endDate; d.AddDays(1))
            {
                List<PlayerGameStats> stats = await _service.FetchGamesStats(d.ToString("yyyy-MMM-dd"));


                foreach (PlayerGameStats p in stats)
                {

                    if (!await _context.PlayerGameStats.AsNoTracking().AnyAsync(s => s.StatID == p.StatID))
                    {
                        created.Add(Create(p));
                    }
                    else
                    {
                        updated.Add(Edit(p.StatID, p));

                    }
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        await _context.AddRangeAsync(created);
                        _context.UpdateRange(updated);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        throw;
                    }

                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
