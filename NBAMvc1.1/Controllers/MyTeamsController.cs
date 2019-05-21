using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NBAMvc1._1.Areas.Auth;
using NBAMvc1._1.Areas.Identity;
using NBAMvc1._1.Models;
using NBAMvc1._1.Services;
using NBAMvc1._1.Services.Interfaces;
using NBAMvc1._1.ViewModels;

namespace NBAMvc1._1.Controllers
{
    [Authorize]
    public class MyTeamsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthorizationService _auth;
        private readonly IMyTeamsService _myTeamService;
        private readonly IPlayerMyTeamService _playerMyTeamService;

        public MyTeamsController(UserManager<ApplicationUser> userManager, IAuthorizationService auth,
            IMyTeamsService myTeamsService, IPlayerMyTeamService playerMyTeamService)
        {
            _userManager = userManager;
            _auth = auth;
            _myTeamService = myTeamsService;
            _playerMyTeamService = playerMyTeamService;
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
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = new MyTeamDetailsViewModel();
            viewModel.MyTeam = await _myTeamService.GetMyTeamByIDAsync(id.Value);
            if (viewModel.MyTeam == null)
            {
                return NotFound();
            }

            var isAuthorized = await _auth.AuthorizeAsync(User, viewModel.MyTeam, Operations.Read);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            viewModel.Roster = await _playerMyTeamService.GetRosterDictionaryAsync(viewModel.MyTeam.MyTeamID);
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
                await _myTeamService.Create(myTeam);
                return RedirectToAction("Details", "FantasyLeagues", new { id = myTeam.FantasyLeagueID });
            }
            return View();
        }

        // GET: MyTeams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {  
            if (id == null)
            {
                return NotFound();
            }

            var myTeam = await _myTeamService.GetMyTeamByIDAsync(id.Value);
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
            var oldTeam = await _myTeamService.GetMyTeamByIDAsync(id);
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
                await _myTeamService.Edit(myTeam);
                return RedirectToAction("Details", "FantasyLeagues", new { id = myTeam.FantasyLeagueID });
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

            var myTeam = await _myTeamService.GetMyTeamByIDAsync(id.Value);
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
            var myTeam = await _myTeamService.GetMyTeamByIDAsync(id);
            if(myTeam == null)
            {
                return NotFound();
            }

            var isAuthorized = await _auth.AuthorizeAsync(User, myTeam, Operations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            await _myTeamService.Delete(myTeam);
            return RedirectToAction("Details", "FantasyLeagues", new { id = myTeam.FantasyLeagueID });
        }
    }
}
