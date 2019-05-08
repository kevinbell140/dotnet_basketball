﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Services
{
    public class GamesService
    {
        private readonly ApplicationDbContext _context;
        private readonly DataService _dataService;

        public GamesService(ApplicationDbContext context, DataService dataService)
        {
            _context = context;
            _dataService = dataService;
        }

        public async Task<Game> GetGame(int id)
        {
            var game = await _context.Game
                .Include(g => g.AwayTeamNav)
                .Include(g => g.HomeTeamNav)
                .Include(g => g.PlayerGameStatsNav).ThenInclude(g => g.PlayerNav)
                .Where(g => g.GameID == id)
                .FirstOrDefaultAsync();

            return game;
        }
        public async Task<IEnumerable<Game>> GetLast(int num)
        {
            var last5 = await _context.Game
                .Include(g => g.HomeTeamNav)
                .Include(g => g.AwayTeamNav)
                .Where(g => (g.Status == "Final" || g.Status == "F/OT"))
                .OrderByDescending(g => g.DateTime)
                .Take(num).ToListAsync();

            return last5;
        }

        public async Task<IEnumerable<Game>> GetNext(int num)
        {
            var next3 = await _context.Game
                .Include(g => g.HomeTeamNav)
                .Include(g => g.AwayTeamNav)
                .Where(g => g.Status == "Scheduled")
                .OrderBy(g => g.DateTime)
                .Take(num).ToListAsync();

            return next3;
        }

        public async Task<IEnumerable<Game>> GetLast(int teamID, int num)
        {
            var last5 = await _context.Game
                .Include(g => g.HomeTeamNav)
                .Include(g => g.AwayTeamNav)
                .Where(g => (g.Status == "Final" || g.Status == "F/OT") && (g.HomeTeamID == teamID || g.AwayTeamID == teamID))
                .OrderByDescending(g => g.DateTime)
                .Take(num).ToListAsync();

            return last5;
        }

        public async Task<IEnumerable<Game>> GetNext(int teamID, int num)
        {
            var next3 = await _context.Game
                .Include(g => g.HomeTeamNav)
                .Include(g => g.AwayTeamNav)
                .Where(g => g.Status == "Scheduled" && (g.HomeTeamID == teamID || g.AwayTeamID == teamID))
                .OrderBy(g => g.DateTime)
                .Take(num).ToListAsync();

            return next3;
        }

        public async Task<IEnumerable<Game>> GetFinalGamesByTeam(int id)
        {
            List<Game> games = new List<Game>();
            games = await _context.Game
                .Include(g => g.HomeTeamNav)
                .Include(g => g.AwayTeamNav)
                .Include(g => g.PlayerGameStatsNav)
                .Where(g => (g.Status == "Final" || g.Status == "F/OT") && (g.HomeTeamNav.TeamID == id || g.AwayTeamNav.TeamID == id))
                .OrderByDescending(g => g.DateTime)
                .ToListAsync();

            return games;
        }

        public async Task<IEnumerable<Game>> GetGamesByDate(DateTime dayOf)
        {
            var games = await _context.Game
                .Include(g => g.AwayTeamNav)
                .Include(g => g.HomeTeamNav)
                .Include(g => g.PlayerGameStatsNav)
                .Where(g => g.DateTime.Date == dayOf)
                .OrderBy(g => g.DateTime)
                .ToListAsync();

            return games;
        }

        public async Task<Game> HasGameTonight(FantasyMatchupWeeks matchupWeek, int teamID)
        {
            var gameTonight = await _context.Game
                    .Include(g => g.PlayerGameStatsNav)
                    .Include(g => g.HomeTeamNav)
                    .Include(g => g.AwayTeamNav)
                    .Where(g => g.DateTime.Date == matchupWeek.Date)
                    .Where(g => g.AwayTeamID == teamID || g.HomeTeamID == teamID)
                    .FirstOrDefaultAsync();
            return gameTonight;
        }

        public async Task FetchAsync()
        {
            List<Game> games = await _dataService.FetchGamesAsync();
            List<Game> created = new List<Game>();
            List<Game> updated = new List<Game>();

            foreach (var g in games)
            {
                if (!await GameExists(g.GameID))
                {
                    Game createdGame = Create(g);
                    if (createdGame != null)
                    {
                        created.Add(createdGame);
                    }
                }
                else
                {
                    Game updatedGame = Edit(g.GameID, g);
                    if (updatedGame != null)
                    {
                        updated.Add(updatedGame);
                    }
                }
            }
            try
            {
                await _context.AddRangeAsync(created);
                _context.UpdateRange(updated);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return;
            }
        }

        public async Task FetchAsync(string isPost)
        {
            List<Game> games;
            if (isPost != null && isPost.ToLower() == "post")
            {
                games = await _dataService.FetchGamesPostAsync();
            }
            else
            {
                games = await _dataService.FetchGamesAsync();
            }
            List<Game> created = new List<Game>();
            List<Game> updated = new List<Game>();

            foreach(var g in games)
            {
                if (!await GameExists(g.GameID))
                {
                    Game createdGame = Create(g);
                    if (createdGame != null)
                    {
                        created.Add(createdGame);
                    }
                }
                else
                {
                    Game updatedGame = Edit(g.GameID, g);
                    if (updatedGame != null)
                    {
                        updated.Add(updatedGame);
                    }                  
                }
            }
            try
            {
                await _context.AddRangeAsync(created);
                _context.UpdateRange(updated);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return;
            }
        }

        private async Task<bool> GameExists(int id)
        {
            return await _context.Game.AnyAsync(a => a.GameID == id);
        }

        private Game Create([Bind("GameID,Season,SeasonType,Status,DateTime,HomeTeamID,AwayTeamID,HomeTeamScore,AwayTeamScore,Updated,PointSpread,OverUnder,AwayTeamMoneyLine,HomeTeamMoneyLine")] Game game)
        {
            if (game.Status == "Canceled" || game.DateTime.Year != 2019)
            {
                return null;
            }
            return game;
        }

        private Game Edit(int id, [Bind("GameID,Season,SeasonType,Status,DateTime,HomeTeamID,AwayTeamID,HomeTeamScore,AwayTeamScore,Updated,PointSpread,OverUnder,AwayTeamMoneyLine,HomeTeamMoneyLine")] Game game)
        {
            if (id != game.GameID)
            {
                return null;
            }
            return game;
        }
    }
}
