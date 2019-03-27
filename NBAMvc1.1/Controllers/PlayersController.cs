using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using NBAMvc1._1.Services;
using NBAMvc1._1.ViewModels;

namespace NBAMvc1._1.Controllers
{
    public class PlayersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly DataService _service;

        public PlayersController(ApplicationDbContext context, DataService service)
        {
            _context = context;
            _service = service;
        }
                     
        // GET: Players
        public async Task<IActionResult> Index()
        {

            var applicationDbContext = _context.Player.Include(p => p.TeamNav);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Players/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = new PlayerDetailsViewModel()
            {
                Player = await _context.Player
                .Include(p => p.TeamNav).ThenInclude(p => p.HomeGamesNav)
                .Include(p => p.TeamNav).ThenInclude(p => p.AwayGamesNav)
                .Include(p => p.StatsNav)
                .FirstOrDefaultAsync(m => m.PlayerID == id),                
            };

            viewModel.Games = viewModel.Player.TeamNav.HomeGamesNav.ToList();
            viewModel.Games.Union(viewModel.Player.TeamNav.AwayGamesNav.ToList());

            return View(viewModel);
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            ViewData["TeamID"] = new SelectList(_context.Team, "TeamID", "Key");
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(include: "PlayerID,Status,Jersey,Position,FirstName,LastName,Height,Weight,BirthDate,TeamID")] Player player)
        {
            if (ModelState.IsValid)
            {
                _context.Add(player);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamID"] = new SelectList(_context.Team, "TeamID", "Key", player.TeamID);
            return View(player);
        }

        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            ViewData["TeamID"] = new SelectList(_context.Team, "TeamID", "Key", player.TeamID);
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlayerID,Status,Jersey,Position,FirstName,LastName,Height,Weight,BirthDate,TeamID")] Player player)
        {
            if (id != player.PlayerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(player);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerExists(player.PlayerID))
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
            ViewData["TeamID"] = new SelectList(_context.Team, "TeamID", "Key", player.TeamID);
            return View(player);
        }

        // GET: Players/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player
                .Include(p => p.TeamNav)
                .FirstOrDefaultAsync(m => m.PlayerID == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var player = await _context.Player.FindAsync(id);
            _context.Player.Remove(player);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerExists(int id)
        {
            return _context.Player.Any(e => e.PlayerID == id);
        }

        public async Task<ActionResult> Fetch()
        {
            List<Player> players = await _service.FetchPLayers();

            foreach (Player p in players)
            {
                var exists = await _context.Player.AnyAsync(o => o.PlayerID == p.PlayerID);

                if (!exists)
                {
                    await Create(p);
                }
                else
                {
                    await Edit(p.PlayerID, p);
                }
            }

            return RedirectToAction(nameof(Index));
        }

    }
}