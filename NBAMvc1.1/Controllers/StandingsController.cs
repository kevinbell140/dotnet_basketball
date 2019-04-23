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


        // POST: Standings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminOnly")]
        private Standings Create([Bind("TeamID,Wins,Losses,Percentage,ConferenceWins,ConferenceLosses,DivisionWins,DivisionLosses,HomeWins,HomeLosses,AwayWins,AwayLosses,LastTenWins,LastTenLosses,Streak,GamesBack")] Standings standings)
        {
            if (ModelState.IsValid)
            {
                return standings;
            }
            return null;
        }


        // POST: Standings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminOnly")]
        private Standings Edit(int id, [Bind("TeamID,Wins,Losses,Percentage,ConferenceWins,ConferenceLosses,DivisionWins,DivisionLosses,HomeWins,HomeLosses,AwayWins,AwayLosses,LastTenWins,LastTenLosses,Streak,GamesBack")] Standings standings)
        {
            if (id != standings.TeamID)
            {
                return null;
            }

            if (ModelState.IsValid)
            {
                return standings;
            }
            return null;
        }

        private bool StandingsExists(int id)
        {
            return _context.Standings.Any(e => e.TeamID == id);
        }

        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Fetch()
        {
            var standings = await _service.FetchStandings();

            List<Standings> created = new List<Standings>();
            List<Standings> updated = new List<Standings>();

            foreach (Standings s in standings)
            {
                var exists = await _context.Standings.AnyAsync(a => a.TeamID == s.TeamID);

                if (!exists)
                {
                    created.Add(Create(s));
                }
                else
                {
                    updated.Add(Edit(s.TeamID, s));
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
            return RedirectToAction("Index");
        }
    }
}
