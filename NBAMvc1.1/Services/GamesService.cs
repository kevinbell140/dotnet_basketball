using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using NBAMvc1._1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Services
{
    public class GamesService : IGamesService
    {
        private readonly ApplicationDbContext _context;
        private readonly IDataService _dataService;

        public GamesService(ApplicationDbContext context, IDataService dataService)
        {
            _context = context;
            _dataService = dataService;
        }

        public async Task<Game> GetGameAsync(int id)
        {
            var game = await _context.Game
                .Include(g => g.AwayTeamNav)
                .Include(g => g.HomeTeamNav)
                .Include(g => g.PlayerGameStatsNav).ThenInclude(g => g.PlayerNav)
                .Where(g => g.GameID == id)
                .FirstOrDefaultAsync();

            return game;
        }
        public async Task<IEnumerable<Game>> GetLastAsync(int num)
        {
            var last5 = await _context.Game
                .Include(g => g.HomeTeamNav)
                .Include(g => g.AwayTeamNav)
                .Where(g => (g.Status == "Final" || g.Status == "F/OT"))
                .OrderByDescending(g => g.DateTime)
                .Take(num).ToListAsync();

            return last5;
        }

        public async Task<IEnumerable<Game>> GetLastAsync(int teamID, int num)
        {
            var last5 = await _context.Game
                .Include(g => g.HomeTeamNav)
                .Include(g => g.AwayTeamNav)
                .Where(g => (g.Status == "Final" || g.Status == "F/OT") && (g.HomeTeamID == teamID || g.AwayTeamID == teamID))
                .OrderByDescending(g => g.DateTime)
                .Take(num).ToListAsync();

            return last5;
        }

        public async Task<IEnumerable<Game>> GetNextAsync(int num)
        {
            var next3 = await _context.Game
                .Include(g => g.HomeTeamNav)
                .Include(g => g.AwayTeamNav)
                .Where(g => g.Status == "Scheduled")
                .OrderBy(g => g.DateTime)
                .Take(num).ToListAsync();

            return next3;
        }

        public async Task<IEnumerable<Game>> GetNextAsync(int teamID, int num)
        {
            var next3 = await _context.Game
                .Include(g => g.HomeTeamNav)
                .Include(g => g.AwayTeamNav)
                .Where(g => g.Status == "Scheduled" && (g.HomeTeamID == teamID || g.AwayTeamID == teamID))
                .OrderBy(g => g.DateTime)
                .Take(num).ToListAsync();

            return next3;
        }

        public async Task<IEnumerable<Game>> GetFinalGamesByTeamAsync(int id)
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

        public async Task<IEnumerable<Game>> GetGamesByDateAsync(DateTime dayOf)
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

        public async Task FetchAsync()
        {
            List<Game> games = await _dataService.FetchGamesAsync();
            List<Game> created = new List<Game>();
            List<Game> updated = new List<Game>();

            foreach (var g in games)
            {
                if (!await GameExists(g.GameID))
                {
                    if (g != null)
                    {
                        created.Add(g);
                    }
                }
                else
                {
                    if (g != null)
                    {
                        updated.Add(g);
                    }
                }
            }
            try
            {
                await _context.AddRangeAsync(created);
                _context.UpdateRange(updated);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
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

            foreach (var g in games)
            {
                if (!await GameExists(g.GameID))
                {
                    if (g != null)
                    {
                        created.Add(g);
                    }
                }
                else
                {
                    if (g != null)
                    {
                        updated.Add(g);
                    }
                }
            }
            try
            {
                await _context.AddRangeAsync(created);
                _context.UpdateRange(updated);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        private async Task<bool> GameExists(int id)
        {
            return await _context.Game.AnyAsync(a => a.GameID == id);
        }
    }
}
