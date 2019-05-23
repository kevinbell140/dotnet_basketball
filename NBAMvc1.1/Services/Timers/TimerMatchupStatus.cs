using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using NBAMvc1._1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NBAMvc1._1.Services.Timers
{
    public class TimerMatchupStatus : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer _timer;
        private readonly IServiceProvider _serviceProvider;


        public TimerMatchupStatus(ILogger<TimerMatchupStatus> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;

        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug("Update timer started");
            _timer = new Timer(Update, null, TimeSpan.FromSeconds(20), TimeSpan.FromHours(1));
            return Task.CompletedTask;
        }

        private async void Update(object state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                var _matchupService = services.GetRequiredService<IFantasyMatchupService>();
                var _scheudleService = services.GetRequiredService<IFantasyMatchupsWeeksService>();
                var _context = services.GetRequiredService<ApplicationDbContext>();

                var matchups = await _matchupService.GetMatchupsForUpdate();
                await _matchupService.UpdateCurrentWeek(matchups);
                _logger.LogDebug("Updated current matchup weeks");
            }
        }
        public FantasyMatchup SetStatus(FantasyMatchup matchup, string status)
        {
            matchup.Status = status;
            return matchup;
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
