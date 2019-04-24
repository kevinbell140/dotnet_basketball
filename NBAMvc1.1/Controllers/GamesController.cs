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

        // POST: Games/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        private Game Create([Bind("GameID,Season,SeasonType,Status,DateTime,HomeTeamID,AwayTeamID,HomeTeamScore,AwayTeamScore,Updated,PointSpread,OverUnder,AwayTeamMoneyLine,HomeTeamMoneyLine")] Game game)
        {
            if(game.Status == "Canceled" || game.DateTime.Year != 2019)
            {
                return null;
            }

            if (ModelState.IsValid)
            {
                return game;
            }
            return null;
        }

        // POST: Games/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        private Game Edit(int id, [Bind("GameID,Season,SeasonType,Status,DateTime,HomeTeamID,AwayTeamID,HomeTeamScore,AwayTeamScore,Updated,PointSpread,OverUnder,AwayTeamMoneyLine,HomeTeamMoneyLine")] Game game)
        {
            if (id != game.GameID)
            {
                return null;
            }

            if (ModelState.IsValid)
            {
                return game;
            }
            return null;
        }


        private bool GameExists(int id)
        {
            return _context.Game.Any(e => e.GameID == id);
        }

        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Fetch()
        {

            var games = await _service.FetchGames();

            List<Game> gamesList = new List<Game>();
            List<Game> editedList = new List<Game>();

            foreach (Game g in games)
            {
                var exists = await _context.Game.AnyAsync(a => a.GameID == g.GameID);

                if (!exists)
                {
                    Game created = Create(g);
                    if (created != null)
                        gamesList.Add(created);
                }
                else
                {
                    Game edited = Edit(g.GameID, g);
                    if (edited != null)
                        editedList.Add(edited);           
                }
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.AddRangeAsync(gamesList);
                    _context.UpdateRange(editedList);
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

        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> FetchPost()
        {

            var games = await _service.FetchGamesPost();

            List<Game> gamesList = new List<Game>();
            List<Game> editedList = new List<Game>();

            foreach (Game g in games)
            {
                var exists = await _context.Game.AnyAsync(a => a.GameID == g.GameID);

                if (!exists)
                {
                    Game created = Create(g);
                    if (created != null)
                        gamesList.Add(created);
                }
                else
                {
                    Game edited = Edit(g.GameID, g);
                    if (edited != null)
                        editedList.Add(edited);
                }
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.AddRangeAsync(gamesList);
                    _context.UpdateRange(editedList);
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
