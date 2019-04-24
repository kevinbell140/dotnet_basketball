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

        // POST: Players/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminOnly")]
        private Player Create([Bind(include: "PlayerID,Status,Jersey,Position,FirstName,LastName,Height,Weight,BirthDate,TeamID")] Player player)
        {
            if (ModelState.IsValid)
            {
                return player;
            }
            return null;
        }

        // POST: Players/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminOnly")]
        private Player Edit(int id, [Bind("PlayerID,Status,Jersey,Position,FirstName,LastName,Height,Weight,BirthDate,TeamID")] Player player)
        {
            if (id != player.PlayerID)
            {
                return null;
            }
            if (ModelState.IsValid)
            {
                return player;
            }
            return null;
        }

        private bool PlayerExists(int id)
        {
            return _context.Player.Any(e => e.PlayerID == id);
        }

        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult> Fetch()
        {
            List<Player> players = await _service.FetchPLayers();
            List<Player> created = new List<Player>();
            List<Player> updated = new List<Player>();

            foreach (Player p in players)
            {
                var exists = await _context.Player.AnyAsync(o => o.PlayerID == p.PlayerID);

                if (!exists)
                {
                    var createdPlayer = Create(p);
                    if(createdPlayer != null)
                    {
                        created.Add(createdPlayer);
                    }
                }
                else
                {
                    var editedPlayer = Edit(p.PlayerID, p);
                    if(editedPlayer != null)
                    {
                        updated.Add(editedPlayer);
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