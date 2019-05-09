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
    public class GamesController : Controller
    {
        private readonly GamesService _gamesService;
        private readonly PlayerGameStatsService _playerGameStatsService;

        public GamesController(GamesService gamesService, PlayerGameStatsService playerGameStatsService)
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

            viewModel.Games = await _gamesService.GetGamesByDate(viewModel.dayOf.Value);

            int count = 0;

            foreach (var g in viewModel.Games)
            {
                List<PlayerGameStats> leaders = await _playerGameStatsService.GetGameLeaders(g.GameID);

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
            if (id == null)
            {
                return NotFound();
            }
            var game = await _gamesService.GetGame(id.Value);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }
    }
}
