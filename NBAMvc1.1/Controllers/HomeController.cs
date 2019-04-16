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
using NBAMvc1._1.ViewModels;

namespace NBAMvc1._1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthorizationService _auth;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IAuthorizationService auth)
        {
            _context = context;
            _userManager = userManager;
            _auth = auth;
        }

        public async Task<IActionResult> Index()
        {

            var viewModel = new HomeIndexViewModel()
            {
                Last4 = _context.Game
                .Where(g => (g.Status == "Final" || g.Status == "F/OT"))
                .Include(g => g.HomeTeamNav)
                .Include(g => g.AwayTeamNav)
                .OrderByDescending(g => g.DateTime)
                .Take(4),


                Next4 = _context.Game
                .Where(g => g.Status == "Scheduled")
                .Include(g => g.HomeTeamNav)
                .Include(g => g.AwayTeamNav)
                .OrderBy(g => g.DateTime)
                .Take(4),

                News = _context.News
                .Include(n => n.PlayerNav)
                .OrderByDescending(n => n.Updated)
                .Take(5),


                MyTeams = await  _context.MyTeam
                .Include(t => t.FantasyLeagueNav)
                .Include(t => t.PlayerMyTeamNav)
                .Where(t => t.UserID == _userManager.GetUserId(User))
                .ToListAsync()
            };

            int count = 0;
            

            foreach(var g in viewModel.Last4)
            {
                List<PlayerGameStats> leaders = await _context.PlayerGameStats
               .Include(p => p.GameNav)
               .Include(p => p.PlayerNav)
               .Where(p => p.GameID == g.GameID)
               .OrderByDescending(p => p.Points)
               .Take(2).ToListAsync();

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
