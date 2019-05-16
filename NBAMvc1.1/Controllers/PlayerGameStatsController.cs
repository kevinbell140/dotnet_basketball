using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NBAMvc1._1.Data;
using NBAMvc1._1.Services;

namespace NBAMvc1._1.Models
{
    [Authorize(Policy = "AdminOnly")]
    public class PlayerGameStatsController : Controller
    {
        private readonly PlayerGameStatsService _playerGameStatsService;

        public PlayerGameStatsController(PlayerGameStatsService playerGameStatsService)
        {
            _playerGameStatsService = playerGameStatsService;
        }

        // GET: PlayerGameStats
        public async Task<IActionResult> Index()
        {
            var stats = await _playerGameStatsService.GetPlayerGameStats();
            return View(stats);
        }
    }
}
