using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NBAMvc1._1.Models;
using NBAMvc1._1.Services;
using NBAMvc1._1.Utils;
using NBAMvc1._1.ViewModels;

namespace NBAMvc1._1.Controllers
{
    public class PlayersController : Controller
    {
        private readonly PlayersService _playersService;
        private readonly GamesService _gamesService;
        private readonly PlayerGameStatsService _playerGameStatsService;

        public PlayersController(PlayersService playersService, GamesService gamesService, PlayerGameStatsService playerGameStatsService)
        {
            _playersService = playersService;
            _gamesService = gamesService;
            _playerGameStatsService = playerGameStatsService;
        }
                     
        // GET: Players
        public async Task<IActionResult> Index(string sortParam, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["currentSort"] = sortParam;
            ViewData["playerSort"] = String.IsNullOrEmpty(sortParam) ? "player_desc" : " ";
            ViewData["fgSort"] = sortParam == "FG" ? "fg_desc" : "FG";
            ViewData["ftSort"] = sortParam == "FT" ? "ft_desc" : "FT";
            ViewData["3ptSort"] = sortParam == "3PT" ? "3pt_desc" : "3PT";
            ViewData["ppgSort"] = sortParam == "PPG" ? "ppg_desc" : "PPG";
            ViewData["apgSort"] = sortParam == "APG" ? "apg_desc" : "APG";
            ViewData["rpgSort"] = sortParam == "RPG" ? "rpg_desc" : "RPG";
            ViewData["spgSort"] = sortParam == "SPG" ? "spg_desc" : "SPG";
            ViewData["bpgSort"] = sortParam == "BPG" ? "bpg_desc" : "BPG";
            ViewData["toSort"] = sortParam == "TO" ? "to_desc" : "TO";

            //for paging 
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["currentFilter"] = searchString;
            IQueryable<Player> players = _playersService.GetPlayers(searchString);
            players = _playersService.SortPLayers(players, sortParam);
            int pageSize = 20;

            return View(await PaginatedList<Player>.Create(players, pageNumber ?? 1, pageSize));
        }

        // GET: Players/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = new PlayerDetailsViewModel()
            {
                Player = await _playersService.GetPlayerAsync(id.Value)              
            };

            if(viewModel.Player == null)
            {
                return NotFound();
            }

            viewModel.Games = await _gamesService.GetFinalGamesByTeamAsync(viewModel.Player.TeamID);
            viewModel.GameLogs = new List<PlayerGameStats>();

            foreach (Game g in viewModel.Games )
            {
                var log = _playerGameStatsService.GetPlayerGameStatsByGameAsync(viewModel.Player.PlayerID, g.GameID);;
                viewModel.GameLogs.Add(await log);               
            }
            return View(viewModel);
        }
    }
}