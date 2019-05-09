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
//            _timer = new Timer(Update, null, TimeSpan.FromMinutes(1), TimeSpan.FromDays(1));
//            return Task.CompletedTask;
//        }

//        private async void Update(object state)
//        {
//            using (var scope = _serviceProvider.CreateScope())
//            {
//                var services = scope.ServiceProvider;
//                var _leagueService = services.GetRequiredService<FantasyLeagueService>();
//                var leagues = await _leagueService.GetLeagues();

//                var _scheudleService = services.GetRequiredService<FantasyMatchupsWeeksService>();
//                var _matchupService = services.GetRequiredService<FantasyMatchupService>();

//                foreach (var l in leagues)
//                {
//                    var week = await _scheudleService.GetFantasyMatchupWeekByLeagueByDate(l.FantasyLeagueID, DateTime.Today);
//                    if(week != null)
//                    {
//                        var matchups = await _matchupService.GetMatchupsForUpdate(l.FantasyLeagueID, week.WeekNum);
//                        foreach(var m in matchups)
//                        {
//                            if(week.Date == DateTime.Today)
//                            {
//                                await _matchupService.SetStatus(m, "Final");
//                            }
//                            else
//                            {
//                                await _matchupService.SetStatus(m, "In Progress");
//                            }
                            
//                        }
//                    }
//                }
//            }

//            //all of the matchups prior to this week for updating purposes
//            //var matchupUpdates = await _fantasyMatchupService.GetMatchupsForUpdate(viewModel.FantasyLeague.FantasyLeagueID, viewModel.CurrentWeek);
//            //var test = await _fantasyLeagueService.UpdateMatchups(matchupUpdates, viewModel.CurrentWeek);

//            //int numWeeks = await _fantasyMatchupService.WeeksThatNeedRecording(viewModel.FantasyLeague.FantasyLeagueID);

//            //var test2 = await _fantasyLeagueStandingsService.UpdateStandings(matchupUpdates, currentWeek-1);

//            //var test3 = await _fantasyLeagueService.StandingsRecorded(matchupUpdates, currentWeek-1);
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
