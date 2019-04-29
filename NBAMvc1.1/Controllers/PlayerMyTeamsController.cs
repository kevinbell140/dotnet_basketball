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
using NBAMvc1._1.Services;
using NBAMvc1._1.Utils;
using NBAMvc1._1.ViewModels;

namespace NBAMvc1._1.Controllers
{
    public class PlayerMyTeamsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthorizationService _auth;
        private readonly PlayerMyTeamService _playerMyTeamService;
        private readonly MyTeamsService _myTeamsService;
        private readonly PlayersService _playersService;

        public PlayerMyTeamsController(PlayersService playersService, MyTeamsService myTeamsService, PlayerMyTeamService playerMyTeamService, ApplicationDbContext context, UserManager<ApplicationUser> userManager, IAuthorizationService auth)
        {
            _context = context;
            _userManager = userManager;
            _auth = auth;
            _playerMyTeamService = playerMyTeamService;
            _myTeamsService = myTeamsService;
            _playersService = playersService;
        }

        // GET: PlayerMyTeams
        [Authorize(Policy = "AdminOnly" )]
        public async Task<IActionResult> Index()
        {
            var players = await  _playerMyTeamService.GetPlayerMyTeams();
            return View(players);
        }

        // GET: PlayerMyTeams/Create
        public async Task<IActionResult> Create(int? teamID, string sortParam, string currentFilter, string searchString, int? pageNumber, string posFilter)
        {
            var viewModel = new PlayerMyTeamCreateViewModel();
            if (teamID == null)
            {
                return BadRequest();
            }

            viewModel.MyTeam = await _myTeamsService.GetMyTeamByID(teamID.Value);

            var isAuthorized = await _auth.AuthorizeAsync(User, viewModel.MyTeam, Operations.Create);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            //sort param
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

            IQueryable<Player> players = _playersService.GetPlayers(searchString, posFilter);
            players = _playersService.SortPLayers(players, sortParam);
            int pageSize = 20;

            viewModel.Players = await PaginatedList<Player>.Create(players.AsNoTracking(), pageNumber ?? 1, pageSize);

            return View(viewModel);
        }

        // POST: PlayerMyTeams/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerID,MyTeamID")] PlayerMyTeam playerMyTeam)
        {
            var myTeam = await _myTeamsService.GetMyTeamByID(playerMyTeam.MyTeamID);
            var isAuthorized = await _auth.AuthorizeAsync(User, myTeam, Operations.Create);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            if (ModelState.IsValid)
            {
                if (await _playerMyTeamService.Create(playerMyTeam))
                {
                    return RedirectToAction("Details", "MyTeams", new { id = playerMyTeam.MyTeamID });
                }
            }
            return RedirectToAction("Details", "MyTeams", new { id = playerMyTeam.MyTeamID });
        }

        // POST: PlayerMyTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int playerID, int myTeamID)
        {
            var playerMyTeam = await _playerMyTeamService.GetPlayerMyTeam(playerID, myTeamID);

            if(playerMyTeam == null)
            {
                return NotFound();
            }

            var isAuthorized = await _auth.AuthorizeAsync(User, playerMyTeam, Operations.Delete);

            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            if (await _playerMyTeamService.Delete(playerMyTeam))
            {
                return RedirectToAction("Details", "MyTeams", new { id = playerMyTeam.MyTeamID });
            }

            return RedirectToAction("Details", "MyTeams", new { id = playerMyTeam.MyTeamID });
        }
    }
}
