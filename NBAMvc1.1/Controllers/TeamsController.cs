using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Index(string sortOrder)
        {
            //sort attributes
            ViewData["CitySortParam"] = String.IsNullOrEmpty(sortOrder) ? "city_desc" : " ";
            ViewData["NameSortParam"] = sortOrder == "Name" ? "name_desc" : "Name";
            ViewData["DivisionSortParam"] = sortOrder == "Division" ? "division_desc" : "Division";

            var teams = await _teamsService.GetTeamsAsync(sortOrder);
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
                Team = await _teamsService.GetTeamAsync(id.Value),
            };

            if(viewModel.Team == null)
            {
                return NotFound();
            }

            Task<IEnumerable<Game>> last5Task  = _gamesService.GetLastAsync(id.Value, 5);
            Task<IEnumerable<Game>> next3Task = _gamesService.GetNextAsync(id.Value, 3);
            Task<List<Standings>> confStandingTask = _standingsService.GetStandingsAsync(viewModel.Team.Conference);
            var allTasks = new List<Task> { last5Task, next3Task, confStandingTask };
            while (allTasks.Any())
            {
                Task finished = await Task.WhenAny(allTasks);
                if(finished == last5Task)
                {
                    allTasks.Remove(last5Task);
                    viewModel.Last5 = await last5Task;
                }else if(finished == next3Task)
                {
                    allTasks.Remove(next3Task);
                    viewModel.Next3 = await next3Task;
                }else if(finished == confStandingTask)
                {
                    allTasks.Remove(confStandingTask);
                    var standings = await confStandingTask;
                    viewModel.ConferenceRank = standings.IndexOf(viewModel.Team.RecordNav) + 1;
                }
            }

            viewModel.PPGLeader = _teamsService.GetPPGLeader(viewModel.Team.PlayersNav.ToList());
            viewModel.RPGLeader = _teamsService.GetRPGLeader(viewModel.Team.PlayersNav.ToList());
            viewModel.APGLeader = _teamsService.GetAPGLeader(viewModel.Team.PlayersNav.ToList());
            viewModel.Players = _teamsService.SortRoster(viewModel.Team.PlayersNav.ToList(), sortOrder);

            //for sorting
            ViewData["PosSortParam"] = String.IsNullOrEmpty(sortOrder) ? "pos_desc" : " ";
            ViewData["PlayerSortParam"] = sortOrder == "Player" ? "player_desc" : "Player";
            ViewData["PPGSortParam"] = sortOrder == "PPG" ? "ppg_desc" : "PPG";
            ViewData["RPGSortParam"] = sortOrder == "RPG" ? "rpg_desc" : "RPG";
            ViewData["APGSortParam"] = sortOrder == "APG" ? "apg_desc" : "APG";

            return View(viewModel);
        }
    }
}
