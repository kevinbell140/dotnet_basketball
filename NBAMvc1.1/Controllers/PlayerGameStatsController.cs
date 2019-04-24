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

        // POST: PlayerGameStats/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        private PlayerGameStats Create([Bind("StatID,PlayerID,GameID,Updated,Minutes,FieldGoalsMade,FieldGoalsAttempted,FieldGoalsPercentage,ThreePointersMade,ThreePointersAttempted,ThreePointersPercentage,FreeThrowsMade,FreeThrowsAttempted,FreeThrowsPercentage,OffensiveRebounds,DefensiveRebounds,Rebounds,Assists,Steals,BlockedShots,Turnovers,PersonalFouls,Points,PlusMinus,Started")] PlayerGameStats playerGameStats)
        {      
            if (ModelState.IsValid)
            {
                Boolean playerExists = _context.Player.Any(a => a.PlayerID == playerGameStats.PlayerID);

                if (playerExists)
                {
                    return playerGameStats;
                }
            }
            return null;
        }

        // POST: PlayerGameStats/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        private PlayerGameStats Edit(int id, [Bind("StatID,PlayerID,Updated,Minutes,FieldGoalsMade,FieldGoalsAttempted,FieldGoalsPercentage,ThreePointersMade,ThreePointersAttempted,ThreePointersPercentage,FreeThrowsMade,FreeThrowsAttempted,FreeThrowsPercentage,OffensiveRebounds,DefensiveRebounds,Rebounds,Assists,Steals,BlockedShots,Turnovers,PersonalFouls,Points,PlusMinus,Started")] PlayerGameStats playerGameStats)
        {
            if (id != playerGameStats.StatID)
            {
                return null;
            }

            if (ModelState.IsValid)
            {
                Boolean playerExists = _context.Player.Any(a => a.PlayerID == playerGameStats.PlayerID);
                if (playerExists)
                {
                    return playerGameStats;
                }  
            }
            return null;
        }

        private bool PlayerGameStatsExists(int id)
        {
            return _context.PlayerGameStats.Any(e => e.StatID == id);
        }

        //GET : Teams/Fetch()
        public async Task<IActionResult> Fetch()
        {
            //logic to fetch all missing data
            DateTime startDate = new DateTime(2019, 04, 22);
            DateTime endDate = DateTime.Today;

            List<PlayerGameStats> created = new List<PlayerGameStats>();
            List<PlayerGameStats> updated = new List<PlayerGameStats>();

            for (DateTime d = startDate; d <= endDate; d = d.AddDays(1))
            {
                List<PlayerGameStats> stats = await _service.FetchGamesStats(d.ToString("yyyy-MMM-dd"));


                foreach (PlayerGameStats p in stats)
                {

                    if (!await _context.PlayerGameStats.AsNoTracking().AnyAsync(s => s.StatID == p.StatID))
                    {
                        var createdStat = Create(p);
                        if(createdStat != null)
                        {
                            created.Add(createdStat);
                        }
                    }
                    else
                    {
                        var editedStat = Edit(p.StatID, p);
                        if(editedStat != null)
                        {
                            updated.Add(editedStat);
                        }
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
            return RedirectToAction(nameof(Index));
        }
    }
}
