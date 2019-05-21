﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NBAMvc1._1.Data;
using NBAMvc1._1.Services;
using NBAMvc1._1.ViewModels;

namespace NBAMvc1._1.Controllers
{
    public class FantasyMatchupsController : Controller
    {
        private readonly FantasyMatchupService _fantasyMatchupService;
        private readonly FantasyLeagueService _fantasyLeagueService;
        private readonly FantasyMatchupsWeeksService _fantasyMatchupsWeeksService;
        private readonly PlayerMyTeamService _playerMyTeamService;

        public FantasyMatchupsController(FantasyMatchupService fantasyMatchupService, FantasyLeagueService fantasyLeagueService,
            FantasyMatchupsWeeksService fantasyMatchupsWeeksService, PlayerMyTeamService playerMyTeamService)
        {
            _fantasyMatchupService = fantasyMatchupService;
            _fantasyLeagueService = fantasyLeagueService;
            _fantasyMatchupsWeeksService = fantasyMatchupsWeeksService;
            _playerMyTeamService = playerMyTeamService;
        }

        // GET: FantasyMatchups
        public async Task<IActionResult> Index()
        {
            var matchups = await _fantasyMatchupService.GetMatchups();
            return View(matchups);
        }

        // GET: FantasyMatchups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = new FantasyMatchupDetailsViewModel
            {
                FantasyMatchup = await _fantasyMatchupService.GetMatchupByIDAsync(id.Value)
            };

            var matchupWeek = await _fantasyMatchupsWeeksService.GetFantasyMatchupWeekByLeagueAsync(viewModel.FantasyMatchup.FantasyLeagueID, viewModel.FantasyMatchup.Week);
            viewModel.Date = matchupWeek.Date;

            var homeRosterTask = _playerMyTeamService.GetRosterDictionaryAsync(viewModel.FantasyMatchup.HomeTeamID.Value);
            var awayRosterTask = _playerMyTeamService.GetRosterDictionaryAsync(viewModel.FantasyMatchup.AwayTeamID.Value);
            var rosterTasks = new List<Task> { homeRosterTask, awayRosterTask };
            while (rosterTasks.Any())
            {
                Task finsihed = await Task.WhenAny(rosterTasks);
                if (finsihed == homeRosterTask)
                {
                    rosterTasks.Remove(homeRosterTask);
                    viewModel.HomeRoster = await homeRosterTask;
                }
                else if (finsihed == awayRosterTask)
                {
                    rosterTasks.Remove(awayRosterTask);
                    viewModel.AwayRoster = await awayRosterTask;
                }
                else
                {
                    rosterTasks.Remove(finsihed);
                }
            }
            
            var homeOppTask = _fantasyMatchupService.GetOpponentLogoDictionaryAsync(viewModel.HomeRoster, matchupWeek);
            var homeStatsTask = _fantasyMatchupService.GetGameStatsDictionaryAsync(viewModel.HomeRoster, matchupWeek);
            var awayOppTask = _fantasyMatchupService.GetOpponentLogoDictionaryAsync(viewModel.AwayRoster, matchupWeek);
            var awayStatsTask = _fantasyMatchupService.GetGameStatsDictionaryAsync(viewModel.AwayRoster, matchupWeek);
            var viewTasks = new List<Task> { homeStatsTask, homeOppTask, awayOppTask, awayStatsTask };
            while (viewTasks.Any())
            {
                Task finished = await Task.WhenAny(viewTasks);
                if(finished == homeOppTask)
                {
                    viewTasks.Remove(homeOppTask);
                    viewModel.HomeOpp = await homeOppTask;
                }
                else if(finished == homeStatsTask)
                {
                    viewTasks.Remove(homeStatsTask);
                    viewModel.HomeStats = await homeStatsTask;
                }
                else if(finished == awayOppTask)
                {
                    viewTasks.Remove(awayOppTask);
                    viewModel.AwayOpp = await awayOppTask;
                }
                else if(finished == awayStatsTask)
                {
                    viewTasks.Remove(awayStatsTask);
                    viewModel.AwayStats = await awayStatsTask;
                }
                else {
                    viewTasks.Remove(finished);
                }
            }
            return View(viewModel);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet]
        public async Task<IActionResult> Create(int leagueID)
        {
            var fantasyLeague = await _fantasyLeagueService.GetLeagueAsync(leagueID);
            if(fantasyLeague == null)
            {
                return NotFound();
            }
            if (!fantasyLeague.IsFull)
            {
                TempData["NotSet"] = "League needs to be set first boss...";
                return RedirectToAction("Details", "FantasyLeagues", new { id = leagueID });
            }
            await _fantasyMatchupService.Create(fantasyLeague);
            return RedirectToAction("Details", "FantasyLeagues", new { id = leagueID });
        }
    }
}
