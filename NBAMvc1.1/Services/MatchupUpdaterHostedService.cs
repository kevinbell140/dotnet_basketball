//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using NBAMvc1._1.Data;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;

//namespace NBAMvc1._1.Services
//{
//    public class MatchupUpdaterHostedService : IHostedService, IDisposable
//    {
//        private readonly ILogger _logger;
//        private Timer _timer;
//        private readonly IServiceProvider _serviceProvider;


//        public MatchupUpdaterHostedService(ILogger<MatchupUpdaterHostedService> logger, IServiceProvider serviceProvider)
//        {
//            _logger = logger;
//            _serviceProvider = serviceProvider;

//        }
//        public Task StartAsync(CancellationToken cancellationToken)
//        {
//            _logger.LogDebug("Update timer started");
//            _timer = new Timer(Update, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
//        }

//        private async void Update(object state)
//        {
//            using(var scope = _serviceProvider.CreateScope())
//            {
//                var services = scope.ServiceProvider;
//                var conext = services.GetRequiredService<ApplicationDbContext>();
//            }
//            //all of the matchups prior to this week for updating purposes
//            //var matchupUpdates = await _fantasyMatchupService.GetMatchupsForUpdate(viewModel.FantasyLeague.FantasyLeagueID, viewModel.CurrentWeek);
//            //var test = await _fantasyLeagueService.UpdateMatchups(matchupUpdates, viewModel.CurrentWeek);

//            //int numWeeks = await _fantasyMatchupService.WeeksThatNeedRecording(viewModel.FantasyLeague.FantasyLeagueID);

//            //var test2 = await _fantasyLeagueStandingsService.UpdateStandings(matchupUpdates, currentWeek-1);

//            //var test3 = await _fantasyLeagueService.StandingsRecorded(matchupUpdates, currentWeek-1);
//        }

//        private async Task UpdateMatchupStatuses(IServiceProvider serviceProvider)
//        {
//            var fantasyLeagueService = _serviceProvider.GetRequiredService<FantasyLeagueService>();
//            var leagues = await fantasyLeagueService.GetLeagues();
//            foreach(var l in leagues)
//            {

//            }

//        }


//        private async Task GetMatchupsForUpdate(ApplicationDbContext _context)
//        {

//            var matchups = await _context.FantasyMatchup
//                    .Include(m => m.AwayTeamNav)
//                    .Include(m => m.HomeTeamNav)
//                    .Where(m => m.FantasyLeagueID == leagueID && m.Week <= currentWeek)
//                    .AsNoTracking().ToListAsync();

//            return matchups;
//        }

//        public Task StopAsync(CancellationToken cancellationToken)
//        {
//            throw new NotImplementedException();
//        }

//        public void Dispose()
//        {
//            throw new NotImplementedException();
//        }
//    }
 
//}
