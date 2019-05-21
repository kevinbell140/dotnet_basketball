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
    public class TimerLeagueStandings : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer _timer;
        private readonly IServiceProvider _serviceProvider;

        public TimerLeagueStandings(ILogger<TimerLeagueStandings> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug("Standings update timer started");
            _timer = new Timer(Update, null, TimeSpan.FromSeconds(60), TimeSpan.FromDays(1));
            return Task.CompletedTask;
        }

        private async void Update(object state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                var _standingsService = services.GetRequiredService<IFantasyLeagueStandingsService>();
                var recordedMatchups = await _standingsService.UpdateStandingsAsync();
                var _matchupService = services.GetRequiredService<IFantasyMatchupService>();
                await _matchupService.SetRecordedAsync(recordedMatchups, true);
                _logger.LogDebug("Matchups set to recorded!");
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
