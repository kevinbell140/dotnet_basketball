using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NBAMvc1._1.Models;
using NBAMvc1._1.Services;
using NBAMvc1._1.Services.Interfaces;
using NBAMvc1._1.ViewModels;

namespace NBAMvc1._1.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGamesService _gamesService;
        private readonly IPlayerGameStatsService _playerGameStatsService;

        public GamesController(IGamesService gamesService, IPlayerGameStatsService playerGameStatsService)
        {
            _gamesService = gamesService;
            _playerGameStatsService = playerGameStatsService;
        }

        // GET: Games
        public async Task<IActionResult> Index(DateTime? dayOf)
        {
            var viewModel = new GameIndexViewModel();

            if (dayOf != null)
            {
                viewModel.dayOf = dayOf;
            }
            else
            {
                viewModel.dayOf = DateTime.Today.Date;
            }

            viewModel.Games = await _gamesService.GetGamesByDateAsync(viewModel.dayOf.Value);

            int count = 0;
            foreach (var g in viewModel.Games)
            {
                List<PlayerGameStats> leaders = await _playerGameStatsService.GetGameLeadersAsync(g.GameID);

                if (leaders.Count() == 2)
                {
                    viewModel.Leaders[count++] = leaders[0];
                    viewModel.Leaders[count++] = leaders[1];
                }
            }
            return View(viewModel);
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var game = await _gamesService.GetGameAsync(id.Value);
            return View(game);
        }
    }
}
