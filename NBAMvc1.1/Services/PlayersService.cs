﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Services
{
    public class PlayersService
    {
        private readonly ApplicationDbContext _context;
        private readonly DataService _dataService;
        private readonly ILogger _logger;

        public PlayersService(ApplicationDbContext context, DataService dataService, ILogger<PlayersService> logger)
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
            }else if(posFilter != null)
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

        public IQueryable<Player>SortPLayers(IQueryable<Player> players, string sortParam)
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

        public async Task<Player> GetPlayer(int id)
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
            _logger.LogDebug("Data size = {0}", players.Count();
            foreach (Player p in players)
            {
                if (!await PlayerExists(p.PlayerID))
                {
                    _logger.LogDebug("Creating a new player!");
                    var createdPlayer = Create(p);
                    if (createdPlayer != null)
                    {
                        _logger.LogDebug("Adding new player to list!");
                        created.Add(createdPlayer);
                    }
                }
                else
                {
                    _logger.LogDebug("Updating a player!");
                    var editedPlayer = Edit(p.PlayerID, p);
                    if (editedPlayer != null)
                    {
                        _logger.LogDebug("Adding updated player to list!");
                        updated.Add(editedPlayer);
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
            catch (Exception)
            {
                _logger.LogError("Crashed writing players to the database!");
                return;
            }
        }

        private async Task<bool> PlayerExists(int id)
        {
            return await _context.Player.AnyAsync(x => x.PlayerID == id);
        }

        private Player Create([Bind(include: "PlayerID,Status,Jersey,Position,FirstName,LastName,Height,Weight,BirthDate,TeamID")] Player player)
        {
            return player;
        }

        private Player Edit(int id, [Bind("PlayerID,Status,Jersey,Position,FirstName,LastName,Height,Weight,BirthDate,TeamID")] Player player)
        {
            if (id != player.PlayerID)
            {
                return null;
            }
            return player;
        }
    }
}
