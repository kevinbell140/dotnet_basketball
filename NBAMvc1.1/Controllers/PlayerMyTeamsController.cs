using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBAMvc1._1.Areas.Auth;
using NBAMvc1._1.Areas.Identity;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using NBAMvc1._1.Utils;
using NBAMvc1._1.ViewModels;

namespace NBAMvc1._1.Controllers
{
    public class PlayerMyTeamsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthorizationService _auth;

        public PlayerMyTeamsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IAuthorizationService auth)
        {
            _context = context;
            _userManager = userManager;
            _auth = auth;
        }

        // GET: PlayerMyTeams
        [Authorize(Policy = "AdminOnly" )]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PlayerMyTeam.Include(p => p.MyTeamNav).Include(p => p.PlayerNav);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PlayerMyTeams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerMyTeam = await _context.PlayerMyTeam
                .Include(p => p.MyTeamNav)
                .Include(p => p.PlayerNav)
                .FirstOrDefaultAsync(m => m.PlayerID == id);
            if (playerMyTeam == null)
            {
                return NotFound();
            }

            return View(playerMyTeam);
        }

        // GET: PlayerMyTeams/Create
        public async Task<IActionResult> Create(int? teamID, string sortParam, string currentFilter, string searchString, int? pageNumber, string posFilter)
        {
            var viewModel = new PlayerMyTeamCreateViewModel();
            if (teamID == null)
            {
                return BadRequest();
            }

            var myTeam = _context.MyTeam
                .Where(t => t.MyTeamID == teamID)
                .Include(t => t.PlayerMyTeamNav)
                .AsNoTracking().FirstOrDefault();

            viewModel.MyTeam = myTeam;

            ViewData["currentSort"] = sortParam;

            ViewData["playerSort"] = String.IsNullOrEmpty(sortParam) ? "player_desc" : " ";
            ViewData["fgSort"] = sortParam == "fg_desc" ? "FG" : "fg_desc";
            ViewData["ftSort"] = sortParam == "ft_desc" ? "FT" : "ft_desc";
            ViewData["3ptSort"] = sortParam == "3pt_desc" ? "3PT" : "3pt_desc";
            ViewData["ppgSort"] = sortParam == "ppg_desc" ? "PPG" : "ppg_desc";
            ViewData["apgSort"] = sortParam == "apg_desc" ? "APG" : "apg_desc";
            ViewData["rpgSort"] = sortParam == "rpg_desc" ? "RPG" : "rpg_desc";
            ViewData["spgSort"] = sortParam == "spg_desc" ? "SPG" : "spg_desc";
            ViewData["bpgSort"] = sortParam == "bpg_desc" ? "BPG" : "bpg_desc";
            ViewData["toSort"] = sortParam == "to_desc" ? "TO" : "to_desc";

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
            ViewData["posFilter"] = posFilter;

            IQueryable<Player> players;

            //for search
            if (searchString != null)
            {
                players = _context.Player
                    .Where(p => p.StatsNav != null && p.FullName.ToLower().Contains(searchString.ToLower()))
                    .Include(p => p.TeamNav)
                    .Include(p => p.StatsNav);

            }
            else if(posFilter != null)
            {
                players = _context.Player
                    .Where(p => p.StatsNav != null && p.Position == posFilter)
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

            viewModel.Players = await PaginatedList<Player>.Create(players.AsNoTracking(), pageNumber ?? 1, pageSize);

            var isAuthorized = await _auth.AuthorizeAsync(User, myTeam, Operations.Create);

            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            return View(viewModel);
        }

        // POST: PlayerMyTeams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerID,MyTeamID")] PlayerMyTeam playerMyTeam)
        {

            var player = await _context.Player
                .Where(p => p.PlayerID == playerMyTeam.PlayerID)
                .FirstOrDefaultAsync();

            var roster = _context.PlayerMyTeam
                .Where(p => p.MyTeamID == playerMyTeam.MyTeamID)
                .Include(p => p.MyTeamID)
                .Include(p => p.PlayerNav)
                .AsNoTracking();

            int spots = roster.Where(p => p.PlayerNav.Position == player.Position).Count();
            
            //need to create a custom exception for this
            if(player.Position == "C" && spots > 0 || player.Position != "C" && spots > 1 || await roster.AnyAsync(p => p.PlayerID == player.PlayerID))
            {
                return RedirectToAction("Details", "MyTeams", new { id = playerMyTeam.MyTeamID});
            }


            if (ModelState.IsValid)
            {
                _context.Add(playerMyTeam);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "MyTeams", new { id = playerMyTeam.MyTeamID });
            }

            return RedirectToAction("Details", "MyTeams", new { id = playerMyTeam.MyTeamID });
        }

        // GET: PlayerMyTeams/Edit/5
        public async Task<IActionResult> Edit(int? playerID, int? myTeamID)
        {
            if (playerID == null || myTeamID == null)
            {
                return NotFound();
            }

            var playerMyTeam = await _context.PlayerMyTeam
                .Where(c => c.MyTeamID == myTeamID && c.PlayerID == playerID)
                .FirstOrDefaultAsync();

            if (playerMyTeam == null)
            {
                return NotFound();
            }

            return View(playerMyTeam);
        }

        // POST: PlayerMyTeams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlayerID,MyTeamID")] PlayerMyTeam playerMyTeam)
        {
            if (id != playerMyTeam.PlayerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerMyTeam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerMyTeamExists(playerMyTeam.PlayerID))
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
            ViewData["MyTeamID"] = new SelectList(_context.MyTeam, "MyTeamID", "MyTeamID", playerMyTeam.MyTeamID);
            ViewData["PlayerID"] = new SelectList(_context.Player, "PlayerID", "PlayerID", playerMyTeam.PlayerID);
            return View(playerMyTeam);
        }


        // GET: PlayerMyTeams/Delete/5
        public async Task<IActionResult> Delete(int? playerID, int? myTeamID)
        {
            if (playerID == null || myTeamID == null)
            {
                return NotFound();
            }

            var playerMyTeam = await _context.PlayerMyTeam
                .Include(p => p.MyTeamNav)
                .Include(p => p.PlayerNav)
                .FirstOrDefaultAsync(m => m.PlayerID == playerID && m.MyTeamID == myTeamID );

            if (playerMyTeam == null)
            {
                return NotFound();
            }

            var isAuthorized = await _auth.AuthorizeAsync(User, playerMyTeam, Operations.Delete);

            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            return View(playerMyTeam);
        }

        // POST: PlayerMyTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? playerID, int? myTeamID)
        {
            var playerMyTeam = await _context.PlayerMyTeam
                .Include(p => p.MyTeamNav)
                .Include(p => p.PlayerNav)
                .FirstOrDefaultAsync(p => p.PlayerID == playerID && p.MyTeamID == myTeamID);

            var pmt = await _context.PlayerMyTeam
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PlayerID == playerID && p.MyTeamID == myTeamID);

            if(pmt == null)
            {
                return NotFound();
            }

            var isAuthorized = await _auth.AuthorizeAsync(User, playerMyTeam, Operations.Delete);

            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            _context.PlayerMyTeam.Remove(playerMyTeam);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "MyTeams", new { id = playerMyTeam.MyTeamID });
        }

        private bool PlayerMyTeamExists(int id)
        {
            return _context.PlayerMyTeam.Any(e => e.PlayerID == id);
        }
    }
}
