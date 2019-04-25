using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;

namespace NBAMvc1._1.Controllers
{
    public class FantasyLeagueStandingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FantasyLeagueStandingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FantasyLeagueStandings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FantasyLeagueStandings.Include(f => f.FantasyLeagueNav).Include(f => f.MyTeamNav);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FantasyLeagueStandings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fantasyLeagueStandings = await _context.FantasyLeagueStandings
                .Include(f => f.FantasyLeagueNav)
                .Include(f => f.MyTeamNav)
                .FirstOrDefaultAsync(m => m.FantasyLeagueStandingsID == id);
            if (fantasyLeagueStandings == null)
            {
                return NotFound();
            }

            return View(fantasyLeagueStandings);
        }


        //redirected from MyTeam/Create
        public async Task<IActionResult> Create(int myTeamID)
        {
            var myTeam = _context.MyTeam
                .Include(x => x.FantasyLeagueNav)
                .Where(x => x.MyTeamID == myTeamID)
                .AsNoTracking().FirstOrDefault();

            if(myTeam != null)
            {
                FantasyLeagueStandings s = new FantasyLeagueStandings();
                s.FantasyLeagueID = myTeam.FantasyLeagueID;
                s.MyTeamID = myTeam.MyTeamID;
                s.Updated = DateTime.Now;

                _context.Add(s);
                await _context.SaveChangesAsync();
                return RedirectToAction("AddTeamConfirm", "FantasyLeagues", new { id = myTeam.FantasyLeagueID });
            }
            return RedirectToAction("Index", "FantasyLeagues", new { myTeamID = myTeam.MyTeamID });
        }


        // POST: FantasyLeagueStandings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public FantasyLeagueStandings Edit(int id, [Bind("FantasyLeagueStandingsID,FantasyLeagueID,MyTeamID,Wins,Losses,Draws,FantasyPoints,FantasyPointsAgainst,GamesBack")] FantasyLeagueStandings fantasyLeagueStandings)
        {
            if (id != fantasyLeagueStandings.FantasyLeagueStandingsID)
            {
                return null;
            }

            if (ModelState.IsValid)
            {
                return fantasyLeagueStandings;
            }
            return null;
        }

        // GET: FantasyLeagueStandings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fantasyLeagueStandings = await _context.FantasyLeagueStandings
                .Include(f => f.FantasyLeagueNav)
                .Include(f => f.MyTeamNav)
                .FirstOrDefaultAsync(m => m.FantasyLeagueStandingsID == id);
            if (fantasyLeagueStandings == null)
            {
                return NotFound();
            }

            return View(fantasyLeagueStandings);
        }

        // POST: FantasyLeagueStandings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fantasyLeagueStandings = await _context.FantasyLeagueStandings.FindAsync(id);
            _context.FantasyLeagueStandings.Remove(fantasyLeagueStandings);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FantasyLeagueStandingsExists(int id)
        {
            return _context.FantasyLeagueStandings.Any(e => e.FantasyLeagueStandingsID == id);
        }
    }
}
