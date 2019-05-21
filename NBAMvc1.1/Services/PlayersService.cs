using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using NBAMvc1._1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Services
{
    public class PlayersService : IPlayersService
    {
        private readonly ApplicationDbContext _context;
        private readonly IDataService _dataService;
        private readonly ILogger _logger;

        public PlayersService(ApplicationDbContext context, IDataService dataService, ILogger<PlayersService> logger)
        {
            _context = context;
            _dataService = dataService;
            _logger = logger;
        }

        public IQueryable<Player> GetPlayers(string searchString)
        {
            IQueryable<Player> players;
            if (searchString != null)
            {
                players = _context.Player
                    .Include(p => p.TeamNav)
                    .Include(p => p.StatsNav)
                    .Where(p => p.StatsNav != null && p.FullName.ToLower().Contains(searchString.ToLower()))
                    .Where(p => p.StatsNav.Games > 10);
            }
            else
            {
                players = _context.Player
                    .Include(p => p.TeamNav)
                    .Include(p => p.StatsNav)
                    .Where(p => p.StatsNav != null && p.StatsNav.Games > 10);
            }
            return players.AsNoTracking();
        }

        public IQueryable<Player> GetPlayers(string searchString, string posFilter)
        {
            IQueryable<Player> players;
            if (searchString != null)
            {
                players = _context.Player
                    .Include(p => p.TeamNav)
                    .Include(p => p.StatsNav)
                    .Where(p => p.StatsNav != null && p.FullName.ToLower().Contains(searchString.ToLower()))
                    .Where(p => p.StatsNav.Games > 10);
            }
            else if (posFilter != null)
            {
                players = _context.Player
                    .Include(p => p.TeamNav)
                    .Include(p => p.StatsNav)
                    .Where(p => p.StatsNav != null && p.Position == posFilter)
                    .Where(p => p.StatsNav.Games > 10);
            }
            else
            {
                players = _context.Player
                    .Include(p => p.TeamNav)
                    .Include(p => p.StatsNav)
                    .Where(p => p.StatsNav != null && p.StatsNav.Games > 10);
            }
            return players.AsNoTracking();
        }

        public IQueryable<Player> SortPLayers(IQueryable<Player> players, string sortParam)
        {
            switch (sortParam)
            {
                case "player_desc":
                    players = players.OrderBy(p => p.LastName);
                    break;

                case "FG":
                    players = players.OrderBy(p => p.StatsNav.FieldGoalsPercentage);
                    break;

                case "fg_desc":
                    players = players.OrderByDescending(p => p.StatsNav.FieldGoalsPercentage);
                    break;

                case "FT":
                    players = players.OrderBy(p => p.StatsNav.FreeThrowsPercentage);
                    break;

                case "ft_desc":
                    players = players.OrderByDescending(p => p.StatsNav.FreeThrowsPercentage);
                    break;

                case "3PT":
                    players = players.OrderBy(p => p.StatsNav.ThreePointersMade);
                    break;

                case "3pt_desc":
                    players = players.OrderByDescending(p => p.StatsNav.ThreePointersMade);
                    break;

                case "PPG":
                    players = players.OrderBy(p => p.StatsNav.PPG);
                    break;

                case "ppg_desc":
                    players = players.OrderByDescending(p => p.StatsNav.PPG);
                    break;

                case "APG":
                    players = players.OrderBy(p => p.StatsNav.APG);
                    break;

                case "apg_desc":
                    players = players.OrderByDescending(p => p.StatsNav.APG);
                    break;

                case "RPG":
                    players = players.OrderBy(p => p.StatsNav.RPG);
                    break;

                case "rpg_desc":
                    players = players.OrderByDescending(p => p.StatsNav.RPG);
                    break;

                case "SPG":
                    players = players.OrderBy(p => p.StatsNav.SPG);
                    break;

                case "spg_desc":
                    players = players.OrderByDescending(p => p.StatsNav.SPG);
                    break;

                case "BPG":
                    players = players.OrderBy(p => p.StatsNav.BPG);
                    break;

                case "bpg_desc":
                    players = players.OrderByDescending(p => p.StatsNav.BPG);
                    break;

                case "TO":
                    players = players.OrderBy(p => p.StatsNav.TPG);
                    break;

                case "to_desc":
                    players = players.OrderByDescending(p => p.StatsNav.TPG);
                    break;

                default:
                    players = players.OrderBy(p => p.LastName);
                    break;
            }
            return players.AsNoTracking();
        }

        public async Task<Player> GetPlayerAsync(int id)
        {
            var player = await _context.Player
                .Include(p => p.TeamNav).ThenInclude(p => p.HomeGamesNav)
                .Include(p => p.TeamNav).ThenInclude(p => p.AwayGamesNav)
                .Include(p => p.StatsNav)
                .Include(p => p.GameStatsNav)
                .Include(p => p.PlayerMyTeamNav)
                .FirstOrDefaultAsync(m => m.PlayerID == id);

            return player;
        }

        public async Task FetchAsync()
        {
            _logger.LogDebug("Fetching data");
            List<Player> players = await _dataService.FetchPlayersAsync();
            List<Player> created = new List<Player>();
            List<Player> updated = new List<Player>();
            _logger.LogDebug("Data size = {0}", players.Count);
            foreach (Player p in players)
            {
                if (!await PlayerExists(p.PlayerID))
                {
                    if (p != null)
                    {
                        created.Add(p);
                    }
                }
                else
                {
                    if (p != null)
                    {
                        updated.Add(p);
                    }
                }
            }
            try
            {
                _logger.LogDebug("Writing new players to the database!");
                await _context.AddRangeAsync(created);
                _logger.LogDebug("Updating players to the database!");
                _context.UpdateRange(updated);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                _logger.LogError("DbUpdateConcurrencyException");
                throw;
            }
        }

        private async Task<bool> PlayerExists(int id)
        {
            return await _context.Player.AnyAsync(x => x.PlayerID == id);
        }
    }
}
