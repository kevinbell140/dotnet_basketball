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
using NBAMvc1._1.ViewModels;

namespace NBAMvc1._1.Controllers
{
    [Authorize]
    public class MyTeamsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthorizationService _auth;

        public MyTeamsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IAuthorizationService auth)
        {
            _context = context;
            _userManager = userManager;
            _auth = auth;
        }

        // GET: MyTeams
        public async Task<IActionResult> Index()
        {
            var teams = _context.MyTeam
                .Include(c => c.PlayerMyTeamNav)
                .Where(c => c.UserID == _userManager.GetUserId(User));

            return View(await teams.ToListAsync());
        }

        // GET: MyTeams/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            var viewModel = new MyTeamDetailsViewModel();
            if (id == null)
            {
                return NotFound();
            }


            var myTeam = await _context.MyTeam
                .Include(m => m.PlayerMyTeamNav)
                .FirstOrDefaultAsync(m => (m.MyTeamID == id) );

            if (myTeam == null)
            {
                return NotFound();
            }

            viewModel.MyTeam = myTeam;

            //gets player roster
            var playerMyteams = await _context.PlayerMyTeam
                .Where(p => p.MyTeamNav.MyTeamID == id)
                .Include(p => p.PlayerNav)
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
        public IActionResult Create()
        { 
            return View();
        }

        // POST: MyTeams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] MyTeam myTeam)
        {
            if (ModelState.IsValid)
            {
                myTeam.UserID = _userManager.GetUserId(User);

                var isAuthorizied = await _auth.AuthorizeAsync(User, myTeam, Operations.Create);

                if (!isAuthorizied.Succeeded)
                {
                    return new ChallengeResult();
                }

                _context.Add(myTeam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(myTeam);
        }

        // GET: MyTeams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var myTeam = await _context.MyTeam.FindAsync(id);
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name")] MyTeam myTeam)
        {

            var oldTeam = await _context.MyTeam.AsNoTracking().FirstOrDefaultAsync(m => m.MyTeamID == id);

            if(oldTeam == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var isAuthorized = await _auth.AuthorizeAsync(User, oldTeam, Operations.Update);

                if (!isAuthorized.Succeeded)
                {
                    return new ChallengeResult();
                }

                myTeam.UserID = oldTeam.UserID;
                myTeam.MyTeamID = oldTeam.MyTeamID;

                try
                {
                    _context.Attach(myTeam).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
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

            var myTeam = await _context.MyTeam
                .Include(m => m.UserNav)
                .FirstOrDefaultAsync(m => m.MyTeamID == id);
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
            var myTeam = await _context.MyTeam.FindAsync(id);

            var team = await _context.MyTeam.AsNoTracking().FirstOrDefaultAsync(m => m.MyTeamID == id);

            if(team == null)
            {
                return NotFound();
            }

            var isAuthorized = await _auth.AuthorizeAsync(User, team, Operations.Delete);

            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            _context.MyTeam.Remove(myTeam);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool MyTeamExists(int id)
        {
            return _context.MyTeam.Any(e => e.MyTeamID == id);
        }
    }
}
