using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBAMvc1._1.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NBAMvc1._1.Services;
using NBAMvc1._1.Areas.Identity;
using NBAMvc1._1.Areas.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace NBAMvc1._1
{
    public class Startup
    {
        private readonly ILogger _logger;
        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            _logger = logger;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            _logger.LogInformation("Added DB context ot services");

            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication().AddMicrosoftAccount(microsoftOptions =>
            {
                microsoftOptions.ClientId = Configuration["Authentication:Microsoft:ApplicationId"];
                microsoftOptions.ClientSecret = Configuration["Authentication:Microsoft:Password"];
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole(Constants.AdministratorRole));
            });

            services.AddHttpClient<DataService>();

            services.AddScoped<IAuthorizationHandler, MyTeamOwnerAuthHandler>();
            services.AddScoped<IAuthorizationHandler, PlayerMyTeamOwnerAuthHandler>();
            services.AddScoped<FantasyLeagueService>();
            services.AddScoped<FantasyLeagueStandingsService>();
            services.AddScoped<FantasyMatchupService>();
            services.AddScoped<FantasyMatchupsWeeksService>();
            services.AddScoped<GamesService>();
            services.AddScoped<MyTeamsService>();
            services.AddScoped<NewsService>();
            services.AddScoped<PlayerGameStatsService>();
            services.AddScoped<PlayerMyTeamService>();
            services.AddScoped<PlayerSeasonStatsService>();
            services.AddScoped<PlayersService>();
            services.AddScoped<StandingsService>();
            services.AddScoped<TeamsService>();

            services.AddHostedService<FetchTimer>();
            services.AddHostedService<CurrentWeekTimerService>();
            services.AddHostedService<MatchupStatusUpdateTimer>();
            services.AddHostedService<MatchupScoreUpdateTimer>();
            services.AddHostedService<StandingsUpdateTimer>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _logger.LogInformation("In development env");
                app.UseDeveloperExceptionPage();
                
                //app.UseExceptionHandler("/Home/Error");
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "fetchPostGames",
                    template: "games/fetch/{isPost?}",
                    defaults: new {controller = "Games", action = "fetch"});

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
