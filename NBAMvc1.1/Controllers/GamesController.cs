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
using NBAMvc1._1.ViewModels;

namespace NBAMvc1._1.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly DataService _service;

        public GamesController(ApplicationDbContext context, DataService service)
        {
            _context = context;
            _service = service;
        }

        // GET: Games
        public async Task<IActionResult> Index(DateTime? dayOf)
        {
            var viewModel = new GameIndexViewModel();

            if (dayOf != null)
            {
                viewModel.dayOf = dayOf;
            }
            else
            {
                viewModel.dayOf = DateTime.Today.Date;
            }

            viewModel.Games = await _context.Game
                .Include(g => g.AwayTeamNav)
                .Include(g => g.HomeTeamNav)
                .Include(g => g.PlayerGameStatsNav)
                .Where(g => g.DateTime.Date == viewModel.dayOf)
                .OrderBy(g => g.DateTime)
                .ToListAsync();

            int count = 0;


            foreach (var g in viewModel.Games)
            {
                List<PlayerGameStats> leaders = await _context.PlayerGameStats
               .Include(p => p.GameNav)
               .Include(p => p.PlayerNav)
               .Where(p => p.GameID == g.GameID)
               .OrderByDescending(p => p.Points)
               .Take(2).ToListAsync();

                if (leaders.Count() == 2)
                {
                    viewModel.Leaders[count++] = leaders[0];
                    viewModel.Leaders[count++] = leaders[1];
                }

            }

            return View(viewModel);
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.AwayTeamNav)
                .Include(g => g.HomeTeamNav)
                .Include(g => g.PlayerGameStatsNav).ThenInclude(g => g.PlayerNav)
                .FirstOrDefaultAsync(m => m.GameID == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            ViewData["AwayTeamID"] = new SelectList(_context.Team, "TeamID", "Key");
            ViewData["HomeTeamID"] = new SelectList(_context.Team, "TeamID", "Key");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GameID,Season,SeasonType,Status,DateTime,HomeTeamID,AwayTeamID,HomeTeamScore,AwayTeamScore,Updated,PointSpread,OverUnder,AwayTeamMoneyLine,HomeTeamMoneyLine")] Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AwayTeamID"] = new SelectList(_context.Team, "TeamID", "Key", game.AwayTeamID);
            ViewData["HomeTeamID"] = new SelectList(_context.Team, "TeamID", "Key", game.HomeTeamID);
            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            ViewData["AwayTeamID"] = new SelectList(_context.Team, "TeamID", "Key", game.AwayTeamID);
            ViewData["HomeTeamID"] = new SelectList(_context.Team, "TeamID", "Key", game.HomeTeamID);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GameID,Season,SeasonType,Status,DateTime,HomeTeamID,AwayTeamID,HomeTeamScore,AwayTeamScore,Updated,PointSpread,OverUnder,AwayTeamMoneyLine,HomeTeamMoneyLine")] Game game)
        {
            if (id != game.GameID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.GameID))
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
            ViewData["AwayTeamID"] = new SelectList(_context.Team, "TeamID", "Key", game.AwayTeamID);
            ViewData["HomeTeamID"] = new SelectList(_context.Team, "TeamID", "Key", game.HomeTeamID);
            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.AwayTeamNav)
                .Include(g => g.HomeTeamNav)
                .FirstOrDefaultAsync(m => m.GameID == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Game.FindAsync(id);
            _context.Game.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
            return _context.Game.Any(e => e.GameID == id);
        }

        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Fetch()
        {

            var games = await _service.FetchGames();

            foreach (Game g in games)
            {
                var exists = await _context.Game.AnyAsync(a => a.GameID == g.GameID);

                if (!exists)
                {
                    await Create(g);
                }
                else
                {
                    await Edit(g.GameID, g);
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
