using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NBAMvc1._1.Services
{
    public class MatchupStatusUpdateTimer : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer _timer;
        private readonly IServiceProvider _serviceProvider;
    

        public MatchupStatusUpdateTimer(ILogger<MatchupStatusUpdateTimer> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;

        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug("Update timer started");
            _timer = new Timer(Update, null, TimeSpan.FromSeconds(30), TimeSpan.FromDays(1));
            return Task.CompletedTask;
        }

        private async void Update(object state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                var _leagueService = services.GetRequiredService<FantasyLeagueService>();
                var leagues = await _leagueService.GetLeagues();

                var _scheudleService = services.GetRequiredService<FantasyMatchupsWeeksService>();
                var _matchupService = services.GetRequiredService<FantasyMatchupService>();

                foreach (var l in leagues)
                {
                    var week = await _scheudleService.GetFantasyMatchupWeekByLeagueByDate(l.FantasyLeagueID, DateTime.Today);
                    if (week != null)
                    {
                        var matchups = await _matchupService.GetMatchupsForUpdate(l.FantasyLeagueID, week.WeekNum);
                        foreach (var m in matchups)
                        {
                            if (week.Date == DateTime.Today)
                            {
                                await _matchupService.SetStatus(m, "In Progress");
                            }
                            else
                            {
                                await _matchupService.SetStatus(m, "Final");
                                _logger.LogDebug("Set status of match {0}", m.FantasyMatchupID);
                            }

                        }
                    }
                    else
                    {
                        var matchups = await _matchupService.GetMatchupsForUpdate(l.FantasyLeagueID, 14); //14 is the max week number
                        foreach(var m in matchups)
                        {
                            await _matchupService.SetStatus(m, "Final");
                            _logger.LogDebug("Set status of match {0}", m.FantasyMatchupID);
                        }
                    }
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug("Fetch timer stopped");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
