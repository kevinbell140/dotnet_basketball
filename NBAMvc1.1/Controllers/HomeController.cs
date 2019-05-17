using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NBAMvc1._1.Areas.Identity;
using NBAMvc1._1.Models;
using NBAMvc1._1.Services;
using NBAMvc1._1.ViewModels;

namespace NBAMvc1._1.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly NewsService _newsService;
        private readonly GamesService _gamesService;
        private readonly MyTeamsService _myTeamsService;
        private readonly PlayerGameStatsService _playerGameStatsService;

        public HomeController(UserManager<ApplicationUser> userManager, NewsService newsService, GamesService gamesService, 
            MyTeamsService myTeamsService, PlayerGameStatsService playerGameStatsService)
        {
            _userManager = userManager;
            _newsService = newsService;
            _gamesService = gamesService;
            _myTeamsService = myTeamsService;
            _playerGameStatsService = playerGameStatsService;
        }

        public async Task<IActionResult> Index()
        {

            var viewModel = new HomeIndexViewModel()
            {
                Last4 = await _gamesService.GetLastAsync(4),
                Next4 = await _gamesService.GetNextAsync(4),
                News = await _newsService.GetNewsAsync(5),
                MyTeams = await _myTeamsService.GetMyTeamsByUserID(_userManager.GetUserId(User)),
            };

            int count = 0;
            foreach(var g in viewModel.Last4)
            {
                List<PlayerGameStats> leaders = await _playerGameStatsService.GetGameLeadersAsync(g.GameID);

                if(leaders.Count() == 2)
                {
                    viewModel.Leaders[count++] = leaders[0];
                    viewModel.Leaders[count++] = leaders[1];
                }
            }
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var viewModel = new ErrorViewModel
            {
                Code = exceptionFeature.Error.HResult,
                Message = exceptionFeature.Error.Message,
                Path = exceptionFeature.Path,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}
