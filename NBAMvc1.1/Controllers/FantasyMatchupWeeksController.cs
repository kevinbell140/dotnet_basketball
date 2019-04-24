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
    public class FantasyMatchupWeeksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FantasyMatchupWeeksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FantasyMatchupWeeks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FantasyMatchupWeeks.Include(f => f.FantasyLeagueNav);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FantasyMatchupWeeks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var fantasyMatchupWeeks = await _context.FantasyMatchupWeeks
                .Include(f => f.FantasyLeagueNav)
                .FirstOrDefaultAsync(m => m.FantasyMatchupWeeksID == id);
            if (fantasyMatchupWeeks == null)
            {
                return NotFound();
            }
            return View(fantasyMatchupWeeks);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? leagueID)
        {
            var league = await _context.FantasyLeague
                .Include(l => l.FantasyMatchupWeeksNav)
                .Include(l => l.TeamsNav)
                .Where(l => l.FantasyLeagueID == leagueID)
                .FirstOrDefaultAsync();
            if(league == null)
            {
                return NotFound();
            }

            var any = await _context.FantasyMatchupWeeks
                .Where(l => l.FantasyLeagueID == leagueID)
                .AnyAsync();

            if(!any)
            {
                DateTime startDate = DateTime.Today.AddDays(-1);
                int numWeeks = (league.TeamsNav.Count() - 1) * 2;
                List<FantasyMatchupWeeks> list = new List<FantasyMatchupWeeks>();

                for(int i = 0; i < numWeeks; i++)
                {
                    FantasyMatchupWeeks week = new FantasyMatchupWeeks
                    {
                        FantasyLeagueNav = league,
                        WeekNum = i,
                        Date = startDate.AddDays(i),
                    };
                    list.Add(week);
                }

                if (ModelState.IsValid)
                {
                    await _context.FantasyMatchupWeeks.AddRangeAsync(list);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Create", "FantasyMatchups", new { leagueID = leagueID });
                }
            }
            return RedirectToAction("Details", "FantasyLeagues", new { id = leagueID });
        }
        private bool FantasyMatchupWeeksExists(int id)
        {
            return _context.FantasyMatchupWeeks.Any(e => e.FantasyMatchupWeeksID == id);
        }
    }
}
