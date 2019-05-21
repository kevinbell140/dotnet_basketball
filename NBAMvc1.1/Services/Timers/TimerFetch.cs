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
    public class TimerFetch : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer _timer;
        private readonly IServiceProvider _serviceProvider;

        public TimerFetch(ILogger<TimerFetch> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug("Fetch timer started");
            _timer = new Timer(Fetch, null, TimeSpan.Zero, TimeSpan.FromDays(1));

            return Task.CompletedTask;
        }

        private async void Fetch(object state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                //await FetchTeamsAsync(services);
                //await FetchPlayersAsync(services);
                //await FetchGamesAsync(services);
                await FetchGamesPostAsync(services);
                //await FetchStandingsAsync(services);
                //await FetchPlayerSeasonStatsAsync(services);
                await FetchPlayerGameStatsAsync(services);
                await FetchNewsAsync(services);
                _logger.LogDebug("Fetch complete");
            }
            return;
        }

        private static async Task FetchTeamsAsync(IServiceProvider serviceProvider)
        {
            var _teamsService = serviceProvider.GetRequiredService<ITeamsService>();
            await _teamsService.FetchAsync();
            return;
        }

        private static async Task FetchPlayersAsync(IServiceProvider serviceProvider)
        {
            var _playersService = serviceProvider.GetRequiredService<IPlayersService>();
            await _playersService.FetchAsync();
            return;
        }

        private static async Task FetchGamesAsync(IServiceProvider serviceProvider)
        {
            var _gamesService = serviceProvider.GetRequiredService<IGamesService>();
            await _gamesService.FetchAsync();
            return;
        }

        private static async Task FetchGamesPostAsync(IServiceProvider serviceProvider)
        {
            var _gamesService = serviceProvider.GetRequiredService<IGamesService>();
            await _gamesService.FetchAsync("post");
            return;
        }

        private static async Task FetchStandingsAsync(IServiceProvider serviceProvider)
        {
            var _standingsService = serviceProvider.GetRequiredService<IStandingsService>();
            await _standingsService.FetchAsync();
            return;
        }

        private static async Task FetchPlayerSeasonStatsAsync(IServiceProvider serviceProvider)
        {
            var _service = serviceProvider.GetRequiredService<IPlayerSeasonStatsService>();
            await _service.FetchAsync();
            return;
        }
        private static async Task FetchPlayerGameStatsAsync(IServiceProvider serviceProvider)
        {
            var _service = serviceProvider.GetRequiredService<IPlayerGameStatsService>();
            await _service.FetchAsync();
            return;
        }

        private static async Task FetchNewsAsync(IServiceProvider serviceProvider)
        {
            var _service = serviceProvider.GetRequiredService<INewsService>();
            await _service.FetchAsync();
            return;
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
