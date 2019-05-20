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

            var viewModel = new HomeIndexViewModel();
            var last4Task = _gamesService.GetLastAsync(4);
            var next4Task = _gamesService.GetNextAsync(4);
            var newsTask = _newsService.GetNewsAsync(5);
            var myTeamsTask = _myTeamsService.GetMyTeamsByUserID(_userManager.GetUserId(User));
            var viewTasks = new List<Task> { last4Task, next4Task, newsTask, myTeamsTask };

            while (viewTasks.Any())
            {
                Task finshed = await Task.WhenAny(viewTasks);
                if(finshed == last4Task)
                {
                    viewTasks.Remove(last4Task);
                    viewModel.Last4 = await last4Task;
                }
                else if(finshed == next4Task)
                {
                    viewTasks.Remove(next4Task);
                    viewModel.Next4 = await next4Task;
                }
                else if(finshed == newsTask)
                {
                    viewTasks.Remove(newsTask);
                    viewModel.News = await newsTask;
                }
                else if(finshed == myTeamsTask)
                {
                    viewTasks.Remove(myTeamsTask);
                    viewModel.MyTeams = await myTeamsTask;
                }
                else
                {
                    viewTasks.Remove(finshed);
                }
            }

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
