﻿using System;
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
        private readonly TeamsService _teamsService;
        private readonly GamesService _gamesService;
        private readonly StandingsService _standingsService;

        public TeamsController(ApplicationDbContext context, DataService service, TeamsService teamsService,
            GamesService gamesService, StandingsService standingsService)
        {
            _context = context;
            _service = service;
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
        public async Task<IActionResult> Details(int id, string sortOrder)
        {
            //get get view model data
            var viewModel = new TeamDetailsViewModel
            {
                Team = await _teamsService.GetTeam(id),
                Last5 = _gamesService.GetLast5(id),
                Next3 = _gamesService.GetNext3(id),
            };

            List<Standings> conferenceStandings = await _standingsService.GetStandings(viewModel.Team.Conference);

            viewModel.ConferenceRank = conferenceStandings.IndexOf(viewModel.Team.RecordNav)+1;

            viewModel.PPGLeader = _teamsService.GetPPGLeader(viewModel.Team.PlayersNav.ToList());

            viewModel.RPGLeader = _teamsService.GetRPGLeader(viewModel.Team.PlayersNav.ToList());

            viewModel.APGLeader = _teamsService.GetAPGLeader(viewModel.Team.PlayersNav.ToList());

            //sort attributes for players
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
