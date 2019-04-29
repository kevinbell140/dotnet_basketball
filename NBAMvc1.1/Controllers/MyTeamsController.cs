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
using NBAMvc1._1.ViewModels;

namespace NBAMvc1._1.Controllers
{
    [Authorize]
    public class MyTeamsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthorizationService _auth;
        private readonly MyTeamsService _myTeamService;

        public MyTeamsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IAuthorizationService auth,
            MyTeamsService myTeamsService)
        {
            _context = context;
            _userManager = userManager;
            _auth = auth;
            _myTeamService = myTeamsService;
        }

        // GET: MyTeams
        public async Task<IActionResult> Index()
        {
            var teams = await _myTeamService.GetMyTeamsByUserID(_userManager.GetUserId(User));
            return View(teams);
        }

        // GET: MyTeams/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            var viewModel = new MyTeamDetailsViewModel();
            if (id == null)
            {
                return NotFound();
            }

            var myTeam = await _myTeamService.GetMyTeamByID(id.Value);
            if (myTeam == null)
            {
                return NotFound();
            }
            viewModel.MyTeam = myTeam;

            //gets player roster
            var playerMyteams = await _context.PlayerMyTeam
                .Where(p => p.MyTeamNav.MyTeamID == id)
                .Include(p => p.PlayerNav).ThenInclude(p => p.StatsNav)
                .Include(p => p.PlayerNav).ThenInclude(p => p.TeamNav)
                .OrderBy(p => p.PlayerNav.Position)
                .AsNoTracking().ToListAsync();


            //dictonary for roster
            Dictionary<string, Player> players = new Dictionary<string, Player>();

            int posCount = 1;

            //add players to in memory dictonary
            foreach(var p in playerMyteams)
            {
                if(p.PlayerNav.Position == "C")
                {
                    players.Add(p.PlayerNav.Position, p.PlayerNav);
                }
                else
                {

                    players.Add(p.PlayerNav.Position + posCount, p.PlayerNav);
                    posCount = (posCount == 1 ? 2 : 1);
                }
            }

            //add players to viewModel dictionary
            foreach(KeyValuePair<string, Player> entry in players)
            {
                viewModel.Roster[entry.Key] = entry.Value;
            }

            if(_userManager.GetUserId(User) != myTeam.UserID)
            {
                return new ChallengeResult();
            }


            return View(viewModel);
        }

        // GET: MyTeams/Create
        public IActionResult Create(int leagueID)
        {
            ViewData["LeagueID"] = leagueID;
            ViewData["UserID"] = _userManager.GetUserId(User);
            return View();
        }

        // POST: MyTeams/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MyTeamID,Name,FantasyLeagueID,UserID")] MyTeam myTeam)
        {
            
            var isAuthorizied = await _auth.AuthorizeAsync(User, myTeam, Operations.Create);

            if (!isAuthorizied.Succeeded)
            {
                return new ChallengeResult();
            }

            if (ModelState.IsValid)
            {
                if (await _myTeamService.Create(myTeam))
                {
                    return RedirectToAction("Details", "FantasyLeagues", new { id = myTeam.FantasyLeagueID } );
                    //return RedirectToAction("Create", "FantasyLeagueStandings", new { myTeamID = myTeam.MyTeamID });
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: MyTeams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {  
            if (id == null)
            {
                return NotFound();
            }

            var myTeam = await _myTeamService.GetMyTeamByID(id.Value);
            if (myTeam == null)
            {
                return NotFound();
            }

            var isAuhtorized = await _auth.AuthorizeAsync(User, myTeam, Operations.Update);
            if (!isAuhtorized.Succeeded)
            {
                return new ChallengeResult();
            }

            return View(myTeam);
        }

        // POST: MyTeams/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,MyTeamID,FantasyLeagueID,UserID")] MyTeam myTeam)
        {
            var oldTeam = await _myTeamService.GetMyTeamByID(id);
            if(oldTeam == null)
            {
                return NotFound();
            }

            var isAuthorized = await _auth.AuthorizeAsync(User, oldTeam, Operations.Update);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            if (ModelState.IsValid)
            {
                if (await _myTeamService.Edit(myTeam))
                {
                    return RedirectToAction("Details", "FantasyLeagues", new { id = myTeam.FantasyLeagueID });
                }
            }
            return View(myTeam);
        }

        // GET: MyTeams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myTeam = await _myTeamService.GetMyTeamByID(id.Value);
            if (myTeam == null)
            {
                return NotFound();
            }

            var isAuthorized = await _auth.AuthorizeAsync(User, myTeam, Operations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }
            return View(myTeam);
        }

        // POST: MyTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myTeam = await _myTeamService.GetMyTeamByID(id);
            int leagueID = myTeam.FantasyLeagueID;

            if(myTeam == null)
            {
                return NotFound();
            }

            var isAuthorized = await _auth.AuthorizeAsync(User, myTeam, Operations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            if (await _myTeamService.Delete(myTeam))
            {
                return RedirectToAction("RemoveTeam", "FantasyLeagues", new { id = leagueID });
            }
            return RedirectToAction("Index", "Home");

        }
    }
}
