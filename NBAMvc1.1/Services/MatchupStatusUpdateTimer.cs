using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            _timer = new Timer(Update, null, TimeSpan.FromSeconds(10), TimeSpan.FromDays(1));
            return Task.CompletedTask;
        }

        private async void Update(object state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                var _matchupService = services.GetRequiredService<FantasyMatchupService>();
                var _scheudleService = services.GetRequiredService<FantasyMatchupsWeeksService>();
                var _context = services.GetRequiredService<ApplicationDbContext>();

                //var matchups = await _matchupService.GetMatchupsForUpdate();
                var matchups = await _matchupService.GetMatchups();
                List<FantasyMatchup> updatedMatchups = new List<FantasyMatchup>();

                foreach (var m in matchups)
                {
                    var weeks = await _scheudleService.GetFantasyMatchupWeeksByLeague(m.FantasyLeagueID);
                    if (weeks != null && weeks.Any())
                    {
                        var currentWeek = weeks.Where(x => x.Date.Date == DateTime.Today.Date).FirstOrDefault();
                        int currentWeekNum = (currentWeek == null ? 15 : currentWeek.WeekNum);
                        if (m.Week == currentWeekNum)
                        {
                            m.Status = "In Progress";
                            m.UpdatedAt = DateTime.Now;
                            updatedMatchups.Add(m);
                        }
                        else if (m.Week < currentWeekNum)
                        {
                            m.Status = "Final";
                            m.UpdatedAt = DateTime.Now;
                            updatedMatchups.Add(m);
                        }
                        else
                        {
                            m.Status = "Scheduled";
                            m.UpdatedAt = DateTime.Now;
                            updatedMatchups.Add(m);
                        }
                    }
                }
                try
                {
                    _context.UpdateRange(updatedMatchups);
                    await _context.SaveChangesAsync();
                    _logger.LogDebug("updated status of matches");
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                catch (Exception)
                {
                    _logger.LogError("error updating status of matches");
                    throw;
                }
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
