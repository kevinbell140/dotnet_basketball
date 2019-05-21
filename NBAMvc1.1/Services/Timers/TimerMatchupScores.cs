using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NBAMvc1._1.Services.Timers
{
    public class TimerMatchupScores : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer _timer;
        private readonly IServiceProvider _serviceProvider;

        public TimerMatchupScores(ILogger<TimerMatchupScores> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug("Update timer started");
            _timer = new Timer(Update, null, TimeSpan.FromSeconds(30), TimeSpan.FromMinutes(10));
            return Task.CompletedTask;
        }

        private async void Update(object state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                var _matchupService = services.GetRequiredService<FantasyMatchupService>();
                var matchups = await _matchupService.GetMatchupsForScoringAsync();
                try
                {
                    _logger.LogDebug("Updating scores");
                    await _matchupService.UpdateScoresAsync(matchups);
                }
                catch (Exception)
                {
                    _logger.LogError("Error updating scores");
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
