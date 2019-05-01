using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NBAMvc1._1.Models;
using NBAMvc1._1.Services;
using NBAMvc1._1.ViewModels;

namespace NBAMvc1._1.Controllers
{
    public class TeamsController : Controller
    {
        private readonly TeamsService _teamsService;
        private readonly GamesService _gamesService;
        private readonly StandingsService _standingsService;

        public TeamsController(TeamsService teamsService, GamesService gamesService, StandingsService standingsService)
        {
            _teamsService = teamsService;
            _gamesService = gamesService;
            _standingsService = standingsService;
        }

        // GET: Teams
        public IActionResult Index(string sortOrder)
        {
            //sort attributes
            ViewData["CitySortParam"] = String.IsNullOrEmpty(sortOrder) ? "city_desc" : " ";
            ViewData["NameSortParam"] = sortOrder == "Name" ? "name_desc" : "Name";
            ViewData["DivisionSortParam"] = sortOrder == "Division" ? "division_desc" : "Division";

            var teams = _teamsService.GetTeams(sortOrder);

            return View(teams);
        }

        // GET: Teams/Details/5
        public async Task<IActionResult> Details(int? id, string sortOrder)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = new TeamDetailsViewModel
            {
                Team = await _teamsService.GetTeam(id.Value),
            };

            if(viewModel.Team == null)
            {
                return NotFound();
            }

            viewModel.Last5 = await _gamesService.GetLast(id.Value, 5);
            viewModel.Next3 = await _gamesService.GetNext(id.Value, 3);

            List<Standings> conferenceStandings = await _standingsService.GetStandings(viewModel.Team.Conference);

            viewModel.ConferenceRank = conferenceStandings.IndexOf(viewModel.Team.RecordNav)+1;
            viewModel.PPGLeader = _teamsService.GetPPGLeader(viewModel.Team.PlayersNav.ToList());
            viewModel.RPGLeader = _teamsService.GetRPGLeader(viewModel.Team.PlayersNav.ToList());
            viewModel.APGLeader = _teamsService.GetAPGLeader(viewModel.Team.PlayersNav.ToList());

            //for sorting
            ViewData["PosSortParam"] = String.IsNullOrEmpty(sortOrder) ? "pos_desc" : " ";
            ViewData["PlayerSortParam"] = sortOrder == "Player" ? "player_desc" : "Player";
            ViewData["PPGSortParam"] = sortOrder == "PPG" ? "ppg_desc" : "PPG";
            ViewData["RPGSortParam"] = sortOrder == "RPG" ? "rpg_desc" : "RPG";
            ViewData["APGSortParam"] = sortOrder == "APG" ? "apg_desc" : "APG";

            viewModel.Players = _teamsService.GetRoster(viewModel.Team.PlayersNav.ToList(), sortOrder);

            return View(viewModel);
        }

        //GET : Teams/Fetch()
        [Authorize(Policy ="AdminOnly")]
        public async Task<IActionResult> Fetch()
        {
            if(await _teamsService.Fetch())
            {
                return RedirectToAction("Index", "Teams");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
