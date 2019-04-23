using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using NBAMvc1._1.Services;

namespace NBAMvc1._1.Controllers
{
    [Authorize(Policy="AdminOnly")]
    public class PlayerSeasonStatsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly DataService _service;

        public PlayerSeasonStatsController(ApplicationDbContext context, DataService service)
        {
            _context = context;
            _service = service;
        }

        // GET: PlayerSeasonStats
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PlayerSeasonStats.Include(p => p.PlayNav);
            return View(await applicationDbContext.ToListAsync());
        }


        // POST: PlayerSeasonStats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public PlayerSeasonStats Create([Bind("StatID,PlayerID,Games,FieldGoalsPercentage,FreeThrowsPercentage,ThreePointersMade,Points,Assists,Rebounds,Steals,BlockedShots,Turnovers")] PlayerSeasonStats playerSeasonStats)
        {
            if (ModelState.IsValid)
            {
                Boolean playerExists = _context.Player.Any(a => a.PlayerID == playerSeasonStats.PlayerID);

                if (playerExists)
                {
                    return playerSeasonStats;
                }
            }
            return null;
        }

        // POST: PlayerSeasonStats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public PlayerSeasonStats Edit(int id, [Bind("StatID,PlayerID,Games,FieldGoalsPercentage,FreeThrowsPercentage,ThreePointersMade,Points,Assists,Rebounds,Steals,BlockedShots,Turnovers")] PlayerSeasonStats playerSeasonStats)
        {
            if (id != playerSeasonStats.StatID)
            {
                return null;
            }

            if (ModelState.IsValid)
            {
                Boolean playerExists = _context.Player.Any(a => a.PlayerID == playerSeasonStats.PlayerID);

                if (playerExists)
                {
                    return playerSeasonStats;
                }
            }
            return null;
        }

        private bool PlayerSeasonStatsExists(int id)
        {
            return _context.PlayerSeasonStats.Any(e => e.StatID == id);
        }


        public async Task<ActionResult> Fetch()
        {
            var stats = await _service.FetchStats();

            List<PlayerSeasonStats> created = new List<PlayerSeasonStats>();
            List<PlayerSeasonStats> updated = new List<PlayerSeasonStats>();

            foreach (PlayerSeasonStats s in stats)
            {
                var exists = await _context.PlayerSeasonStats.AnyAsync(a => a.StatID == s.StatID);

                if (!exists)
                {
                    var createdStat = Create(s);
                    if(createdStat != null)
                    {
                        created.Add(createdStat);
                    }
                }
                else
                {
                    var updatedStat = Edit(s.StatID, s);
                    if(updatedStat != null)
                    {
                        updated.Add(updatedStat);
                    }
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
            return RedirectToAction("Index", "Players");
        }
    }
}
