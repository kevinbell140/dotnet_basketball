using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using NBAMvc1._1.Areas.Auth;
using NBAMvc1._1.Areas.Identity;
using NBAMvc1._1.Services;

namespace NBAMvc1._1.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                //create admin account
                var adminID = await EnsureUser(serviceProvider, "Password12#", "admin@fbbm.com");
                await EnsureRole(serviceProvider, adminID, Constants.AdministratorRole);
                
                //fill database
                //await FetchTeamsAsync(serviceProvider);
                //await FetchPlayersAsync(serviceProvider);
                //await FetchGamesPostAsync(serviceProvider);
                //await FetchStandingsAsync(serviceProvider);
                //await FetchPlayerSeasonStatsAsync(serviceProvider);
                //await FetchPlayerGameStatsAsync(serviceProvider);
                //await FetchNewsAsync(serviceProvider);
            }
        }

        private static async Task FetchTeamsAsync(IServiceProvider serviceProvider)
        {
            var _teamsService = serviceProvider.GetRequiredService<TeamsService>();
            await _teamsService.FetchAsync();
            return;
        }
        
        private static async Task FetchPlayersAsync(IServiceProvider serviceProvider)
        {
            var _playersService = serviceProvider.GetRequiredService<PlayersService>();
            await _playersService.FetchAsync();
            return;
        }

        private static async Task FetchGamesAsync(IServiceProvider serviceProvider)
        {
            var _gamesService = serviceProvider.GetRequiredService<GamesService>();
            await _gamesService.FetchAsync();
            return;
        }

        private static async Task FetchGamesPostAsync(IServiceProvider serviceProvider)
        {
            var _gamesService = serviceProvider.GetRequiredService<GamesService>();
            await _gamesService.FetchAsync("post");
            return;
        }

        private static async Task FetchStandingsAsync(IServiceProvider serviceProvider)
        {
            var _standingsService = serviceProvider.GetRequiredService<StandingsService>();
            await _standingsService.FetchAsync();
            return;
        }

        private static async Task FetchPlayerSeasonStatsAsync(IServiceProvider serviceProvider)
        {
            var _service = serviceProvider.GetRequiredService<PlayerSeasonStatsService>();
            await _service.FetchAsync();
            return;
        }
        private static async Task FetchPlayerGameStatsAsync(IServiceProvider serviceProvider)
        {
            var _service = serviceProvider.GetRequiredService<PlayerGameStatsService>();
            await _service.FetchAsync();
            return;
        }

        private static async Task FetchNewsAsync(IServiceProvider serviceProvider)
        {
            var _service = serviceProvider.GetRequiredService<NewsService>();
            await _service.FetchAsync();
            return;
        }


        private static async Task<string> EnsureUser(IServiceProvider serviceProvider, string pw, string userName)
        {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByNameAsync(userName);
            if(user == null)
            {
                user = new ApplicationUser { UserName = userName };
                await userManager.CreateAsync(user, pw);
            }
            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider, string uid, string role)
        {
            IdentityResult IR = null;

            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
            if(roleManager == null)
            {
                throw new Exception("roleManager null");
            }
            if(!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            var user = await userManager.FindByIdAsync(uid);

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }

    }
}
