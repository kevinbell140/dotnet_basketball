using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using NBAMvc1._1.Services;

namespace NBAMvc1._1.Controllers
{
    [Authorize(Policy="AdminOnly")]
    public class PlayerSeasonStatsController : Controller
    {
        private readonly PlayerSeasonStatsService _playerSeasonStatsService;

        public PlayerSeasonStatsController(PlayerSeasonStatsService playerSeasonStatsService)
        {
            _playerSeasonStatsService = playerSeasonStatsService;
        }

        // GET: PlayerSeasonStats
        public async Task<IActionResult> Index()
        {
            var stats = await _playerSeasonStatsService.GetPlayerSeasonStats();
            return View(stats);
        }

        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Fetch()
        {
            if (await _playerSeasonStatsService.Fetch())
            {
                return RedirectToAction("Index", "PlayerSeasonStats");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
