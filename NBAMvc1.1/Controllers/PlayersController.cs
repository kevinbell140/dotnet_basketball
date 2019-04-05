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
using NBAMvc1._1.Utils;
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
        public async Task<IActionResult> Index(string sortParam, string currentFilter, string searchString, int? pageNumber)
        {
            //sort param
            ViewData["currentSort"] = sortParam;

            ViewData["playerSort"] = String.IsNullOrEmpty(sortParam) ? "player_desc" : " ";
            ViewData["fgSort"] = sortParam == "FG" ? "fg_desc" : "FG";
            ViewData["ftSort"] = sortParam == "FT" ? "ft_desc" : "FT";
            ViewData["3ptSort"] = sortParam == "3PT" ? "3pt_desc" : "3PT";
            ViewData["ppgSort"] = sortParam == "PPG" ? "ppg_desc" : "PPG";
            ViewData["apgSort"] = sortParam == "APG" ? "apg_desc" : "APG";
            ViewData["rpgSort"] = sortParam == "RPG" ? "rpg_desc" : "RPG";
            ViewData["spgSort"] = sortParam == "SPG" ? "spg_desc" : "SPG";
            ViewData["bpgSort"] = sortParam == "BPG" ? "bpg_desc" : "BPG";
            ViewData["toSort"] = sortParam == "TO" ? "to_desc" : "TO";

            //for paging 
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["currentFilter"] = searchString;

            IQueryable<Player> players;

            //for search
            if (searchString != null)
            {
                players = _context.Player
                    .Where(p => p.StatsNav != null && p.FullName.ToLower().Contains(searchString.ToLower()))
                    .Include(p => p.TeamNav)
                    .Include(p => p.StatsNav);
            }
            else
            {
                players = _context.Player
                    .Where(p => p.StatsNav != null)
                    .Include(p => p.TeamNav)
                    .Include(p => p.StatsNav);
            }

            //for sort
            switch (sortParam)
            {
                case "player_desc":
                    players = players.OrderBy(p => p.LastName);
                    break;

                case "FG":
                    players = players.OrderBy(p => p.StatsNav.FieldGoalsPercentage);
                    break;

                case "fg_desc":
                    players = players.OrderByDescending(p => p.StatsNav.FieldGoalsPercentage);
                    break;

                case "FT":
                    players = players.OrderBy(p => p.StatsNav.FreeThrowsPercentage);
                    break;

                case "ft_desc":
                    players = players.OrderByDescending(p => p.StatsNav.FreeThrowsPercentage);
                    break;

                case "3PT":
                    players = players.OrderBy(p => p.StatsNav.ThreePointersMade);
                    break;

                case "3pt_desc":
                    players = players.OrderByDescending(p => p.StatsNav.ThreePointersMade);
                    break;

                case "PPG":
                    players = players.OrderBy(p => p.StatsNav.PPG);
                    break;

                case "ppg_desc":
                    players = players.OrderByDescending(p => p.StatsNav.PPG);
                    break;

                case "APG":
                    players = players.OrderBy(p => p.StatsNav.APG);
                    break;

                case "apg_desc":
                    players = players.OrderByDescending(p => p.StatsNav.APG);
                    break;

                case "RPG":
                    players = players.OrderBy(p => p.StatsNav.RPG);
                    break;

                case "rpg_desc":
                    players = players.OrderByDescending(p => p.StatsNav.RPG);
                    break;

                case "SPG":
                    players = players.OrderBy(p => p.StatsNav.SPG);
                    break;

                case "spg_desc":
                    players = players.OrderByDescending(p => p.StatsNav.SPG);
                    break;

                case "BPG":
                    players = players.OrderBy(p => p.StatsNav.BPG);
                    break;

                case "bpg_desc":
                    players = players.OrderByDescending(p => p.StatsNav.BPG);
                    break;

                case "TO":
                    players = players.OrderBy(p => p.StatsNav.TPG);
                    break;

                case "to_desc":
                    players = players.OrderByDescending(p => p.StatsNav.TPG);
                    break;

                default:
                    players = players.OrderBy(p => p.LastName);
                    break;
            }
            int pageSize = 20;

            return View(await PaginatedList<Player>.Create(players.AsNoTracking(), pageNumber ?? 1, pageSize));
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
                .Include(p => p.GameStatsNav)
                .FirstOrDefaultAsync(m => m.PlayerID == id),     
                
            };

            viewModel.Games = _context.Game
                .Where(g => (g.Status == "Final" || g.Status == "F/OT") && (g.HomeTeamNav.TeamID == viewModel.Player.TeamID || g.AwayTeamNav.TeamID == viewModel.Player.TeamID))
                .Include(g => g.HomeTeamNav)
                .Include(g => g.AwayTeamNav)
                .Include(g => g.PlayerGameStatsNav)
                .OrderByDescending(g => g.DateTime)
                .ToList();

            viewModel.GameLogs = new List<PlayerGameStats>();
            foreach (Game g in viewModel.Games )
            {
                var log = _context.PlayerGameStats
                    .Where(a => a.GameNav.GameID == g.GameID && a.PlayerNav.PlayerID == id)
                    .FirstOrDefault();
                viewModel.GameLogs.Add(log);               
            }

            return View(viewModel);
        }

        // GET: Players/Create
        [Authorize(Policy = "AdminOnly")]
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
        [Authorize(Policy = "AdminOnly")]
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
        [Authorize(Policy = "AdminOnly")]
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
        [Authorize(Policy = "AdminOnly")]
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