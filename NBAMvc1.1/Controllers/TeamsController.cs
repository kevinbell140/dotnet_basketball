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
            ViewData["DivisionSortParam"] = sortOrder == "Division" ? "division_desc" : "Division";

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
        public async Task<IActionResult> Details(int? id, string sortOrder)
        {
            if (id == null)
            {
                return NotFound();
            }

            //get get view model data
            var viewModel = new TeamDetailsViewModel
            {
                Team = await _context.Team
                .Include(t => t.PlayersNav).ThenInclude(p => p.StatsNav)
                .Include(t => t.RecordNav)
                .Where(t => t.TeamID == id)
                .FirstOrDefaultAsync(),

                Last5 = _context.Game
                .Where(g => (g.Status == "Final" || g.Status == "F/OT") && (g.HomeTeamID == id || g.AwayTeamID == id))
                .Include(g => g.HomeTeamNav)
                .Include(g => g.AwayTeamNav)
                .OrderByDescending(g => g.DateTime)
                .Take(5),


                Next3 = _context.Game
                .Where(g => g.Status == "Scheduled" && (g.HomeTeamID == id || g.AwayTeamID == id))
                .Include(g => g.HomeTeamNav)
                .Include(g => g.AwayTeamNav)
                .OrderBy(g => g.DateTime)
                .Take(3),

            };

            string conference = viewModel.Team.Conference;

            List<Standings> conferenceStandings = _context.Standings
                .Where(t => t.TeamNav.Conference == conference)
                .Include(t => t.TeamNav)
                .OrderBy(t => t.GamesBack)
                .ToList();

            viewModel.ConferenceRank = conferenceStandings.IndexOf(viewModel.Team.RecordNav)+1;

            viewModel.PPGLeader = viewModel.Team.PlayersNav
                .Where(p => p.StatsNav != null)
                .OrderByDescending(p => p.StatsNav.PPG)
                .First();

            viewModel.RPGLeader = viewModel.Team.PlayersNav
                .Where(p => p.StatsNav != null)
                .OrderByDescending(p => p.StatsNav.RPG)
                .First();

            viewModel.APGLeader = viewModel.Team.PlayersNav
                .Where(p => p.StatsNav != null)
                .OrderByDescending(p => p.StatsNav.APG)
                .First();

            


            //sort attributes for players
            ViewData["PosSortParam"] = String.IsNullOrEmpty(sortOrder) ? "pos_desc" : " ";
            ViewData["PlayerSortParam"] = sortOrder == "Player" ? "player_desc" : "Player";
            ViewData["PPGSortParam"] = sortOrder == "PPG" ? "ppg_desc" : "PPG";
            ViewData["RPGSortParam"] = sortOrder == "RPG" ? "rpg_desc" : "RPG";
            ViewData["APGSortParam"] = sortOrder == "APG" ? "apg_desc" : "APG";

            switch (sortOrder)
            {
                case "pos_desc":
                    viewModel.Players = viewModel.Team.PlayersNav.Where(p => p.StatsNav != null).OrderByDescending(p => p.Position).ToList();
                    break;
                case "Player":
                    viewModel.Players = viewModel.Team.PlayersNav.Where(p => p.StatsNav != null).OrderBy(p => p.LastName).ToList();
                    break;
                case "player_desc":
                    viewModel.Players = viewModel.Team.PlayersNav.Where(p => p.StatsNav != null).OrderByDescending(p => p.LastName).ToList();
                    break;
                case "PPG":
                    viewModel.Players = viewModel.Team.PlayersNav.Where(p => p.StatsNav != null).OrderBy(p => p.StatsNav.PPG).ToList();
                    break;
                case "ppg_desc":
                    viewModel.Players = viewModel.Team.PlayersNav.Where(p => p.StatsNav != null).OrderByDescending(p => p.StatsNav.PPG).ToList();
                    break;
                case "RPG":
                    viewModel.Players = viewModel.Team.PlayersNav.Where(p => p.StatsNav != null).OrderBy(p => p.StatsNav.RPG).ToList();
                    break;
                case "rpg_desc":
                    viewModel.Players = viewModel.Team.PlayersNav.Where(p => p.StatsNav != null).OrderByDescending(p => p.StatsNav.RPG).ToList();
                    break;
                case "APG":
                    viewModel.Players = viewModel.Team.PlayersNav.Where(p => p.StatsNav != null).OrderBy(p => p.StatsNav.APG).ToList();
                    break;
                case "apg_desc":
                    viewModel.Players = viewModel.Team.PlayersNav.Where(p => p.StatsNav != null).OrderByDescending(p => p.StatsNav.APG).ToList();
                    break;
                default:
                    viewModel.Players = viewModel.Team.PlayersNav.Where(p => p.StatsNav != null).OrderBy(p => p.Position).ToList();
                    break;
            }

            return View(viewModel);
        }


        // POST: Teams/Create
        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Team Create([Bind("TeamID,Key,City,Name,LeagueID,Conference,Division,PrimaryColor,SecondaryColor,TertiaryColor,WikipediaLogoUrl,WikipediaWordMarkUrl,GlobalTeamID")] Team team)
        {
            if (ModelState.IsValid)
            {
                return team;
            }
            return null;
        }

        // POST: Teams/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        private Team Edit(int id, [Bind("TeamID,Key,City,Name,LeagueID,Conference,Division,PrimaryColor,SecondaryColor,TertiaryColor,WikipediaLogoUrl,WikipediaWordMarkUrl,GlobalTeamID")] Team team)
        {
            if (id != team.TeamID)
            {
                return null;
            }

            if (ModelState.IsValid)
            {
                return team;
            }
            return null;
        }

        private bool TeamExists(int id)
        {
            return _context.Team.Any(e => e.TeamID == id);
        }


        //GET : Teams/Fetch()
        [Authorize(Policy ="AdminOnly")]
        public async Task<IActionResult> Fetch()
        {
            List<Team> teams = await _service.FetchTeams();

            List<Team> created = new List<Team>();
            List<Team> updated = new List<Team>();
            foreach (Team t in teams)
            {

                var exists = await _context.Team.AnyAsync(o => o.TeamID == t.TeamID);

                if (!exists)
                {
                    created.Add(Create(t));
                }
                else
                {
                    updated.Add(Edit(t.TeamID, t));
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
