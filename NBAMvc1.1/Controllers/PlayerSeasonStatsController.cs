using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        //[Authorize(Policy = "AdminOnly")]
        //public async Task<IActionResult> Fetch()
        //{
        //    if (await _playerSeasonStatsService.Fetch())
        //    {
        //        return RedirectToAction("Index", "PlayerSeasonStats");
        //    }
        //    return RedirectToAction("Index", "Home");
        //}
    }
}
