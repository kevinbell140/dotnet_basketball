using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBAMvc1._1.Areas.Identity;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using NBAMvc1._1.Services;
using NBAMvc1._1.ViewModels;

namespace NBAMvc1._1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthorizationService _auth;
        private readonly NewsService _newsService;
        private readonly GamesService _gamesService;
        private readonly MyTeamsService _myTeamsService;
        private readonly PlayerGameStatsService _playerGameStatsService;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IAuthorizationService auth,
            NewsService newsService, GamesService gamesService, MyTeamsService myTeamsService, PlayerGameStatsService playerGameStatsService)
        {
            _context = context;
            _userManager = userManager;
            _auth = auth;
            _newsService = newsService;
            _gamesService = gamesService;
            _myTeamsService = myTeamsService;
            _playerGameStatsService = playerGameStatsService;
        }

        public async Task<IActionResult> Index()
        {

            var viewModel = new HomeIndexViewModel()
            {
                Last4 = await _gamesService.GetLast(4),
                Next4 = await _gamesService.GetNext(4),
                News = await _newsService.GetNews(5),
                MyTeams = await _myTeamsService.GetMyTeamByUserID(_userManager.GetUserId(User)),
            };

            int count = 0;
            foreach(var g in viewModel.Last4)
            {
                List<PlayerGameStats> leaders = await _playerGameStatsService.GetGameLeaders(g.GameID);

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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
