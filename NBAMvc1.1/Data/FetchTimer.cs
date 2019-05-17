using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NBAMvc1._1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NBAMvc1._1.Data
{
    internal class FetchTimer : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer _timer;
        private readonly IServiceProvider _serviceProvider;

        public FetchTimer(ILogger<FetchTimer> logger, IServiceProvider serviceProvider)
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
            using(var scope = _serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                //await FetchTeamsAsync(services);
                //await FetchPlayersAsync(services);
                //await FetchGamesAsync(services);
                //await FetchGamesPostAsync(services);
                //await FetchStandingsAsync(services);
                //await FetchPlayerSeasonStatsAsync(services);
                //await FetchPlayerGameStatsAsync(services);
                await FetchNewsAsync(services);
                _logger.LogDebug("Fetch complete");
            }
            return;
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
