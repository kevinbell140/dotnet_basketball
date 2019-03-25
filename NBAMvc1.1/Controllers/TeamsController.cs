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
    public class TeamsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly DataService _service;

        public TeamsController(ApplicationDbContext context, DataService service)
        {
            _context = context;
            _service = service;
        }

        // GET: Teams
        public async Task<IActionResult> Index(string sortOrder)
        {
            //sort attributes
            ViewData["CitySortParam"] = String.IsNullOrEmpty(sortOrder) ? "city_desc" : " ";
            ViewData["NameSortParam"] = sortOrder == "Name" ? "name_desc" : "Name";
            ViewData["DivisionSortParam"] = sortOrder == "Divsion" ? "division_desc" : "Division";

            //LINQ for sorting
            var teams = from t in _context.Team
                        select t;

            switch (sortOrder)
            {
                case "city_desc":
                    teams = teams.OrderByDescending(t => t.City);
                    break;
                case "Name":
                    teams = teams.OrderBy(t => t.Name);
                    break;
                case "name_desc":
                    teams = teams.OrderByDescending(t => t.Name);
                    break;
                case "Division":
                    teams = teams.OrderBy(t => t.Division);
                    break;
                case "division_desc":
                    teams = teams.OrderByDescending(t => t.Division);
                    break;
                default:
                    teams = teams.OrderBy(t => t.City);
                    break;
            }

            return View(await teams.ToListAsync());

        }

        // GET: Teams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //get team
            var viewModel = new TeamDetailsViewModel();


            viewModel.Team = await _context.Team
                .Where(t => t.TeamID == id)
                .Include(t => t.Players).ThenInclude(p => p.StatsNav)
                .FirstOrDefaultAsync();
            
            viewModel.Last5 = _context.Game
                .Where(g => g.Status == "Final" && (g.HomeTeamID == id || g.AwayTeamID == id))
                .OrderBy(g => g.DateTime)
                .Take(5);



            return View(viewModel);
        }

        // GET: Teams/Create
        private IActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        private async Task<IActionResult> Create([Bind("TeamID,Key,City,Name,LeagueID,Conference,Division,PrimaryColor,SecondaryColor,TertiaryColor,WikipediaLogoUrl,WikipediaWordMarkUrl,GlobalTeamID")] Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeamID,Key,City,Name,LeagueID,Conference,Division,PrimaryColor,SecondaryColor,TertiaryColor,WikipediaLogoUrl,WikipediaWordMarkUrl,GlobalTeamID")] Team team)
        {
            if (id != team.TeamID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.TeamID))
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
            return View(team);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team
                .FirstOrDefaultAsync(m => m.TeamID == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Team.FindAsync(id);
            _context.Team.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamExists(int id)
        {
            return _context.Team.Any(e => e.TeamID == id);
        }


        //GET : Teams/Fetch()
        public async Task<IActionResult> Fetch()
        {
            List<Team> teams = await _service.FetchTeams();

            foreach (Team t in teams)
            {

                var exists = await _context.Team.AnyAsync(o => o.TeamID == t.TeamID);

                if (!exists)
                {
                    await Create(t);
                }
                else
                {
                    await Edit(t.TeamID, t);
                }
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
