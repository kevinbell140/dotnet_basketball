using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NBAMvc1._1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NBAMvc1._1.Services.Timers
{
    public class TimerCurrentWeek : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer _timer;
        private readonly IServiceProvider _serviceProvider;

        public TimerCurrentWeek(ILogger<TimerCurrentWeek> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(UpdateWeeks, null, TimeSpan.FromSeconds(10), TimeSpan.FromDays(1));

            return Task.CompletedTask;
        }

        private async void UpdateWeeks(object state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                var _leagueService = services.GetRequiredService<IFantasyLeagueService>();
                var leagues = await _leagueService.GetLeaguesAsync();

                var _scheudleService = services.GetRequiredService<IFantasyMatchupsWeeksService>();

                foreach (var l in leagues)
                {
                    var week = await _scheudleService.GetFantasyMatchupWeekByLeagueByDateAsync(l.FantasyLeagueID, DateTime.Today);
                    if (week != null)
                    {
                        try
                        {
                            await _leagueService.UpdateCurrentWeekAsync(l, week.WeekNum);
                        }
                        catch (Exception)
                        {
                            _logger.LogError("Could not update league {0}", l);
                            throw;
                        }
                    }
                    else
                    {
                        try
                        {
                            await _leagueService.IsActiveFalseAsync(l);
                        }
                        catch (Exception)
                        {
                            _logger.LogError("Could not set league to inactive");
                            throw;
                        }
                    }
                }
                return;
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

