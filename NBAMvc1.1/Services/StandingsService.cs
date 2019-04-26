using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Services
{
    public class StandingsService
    {
        private readonly ApplicationDbContext _context;
        private readonly DataService _dataService;

        public StandingsService(ApplicationDbContext context, DataService dataService)
        {
            _context = context;
            _dataService = dataService;
        }

        public async Task<List<Standings>> GetStandings(string conference)
        {
            List<Standings> standings = new List<Standings>();

            standings = await _context.Standings
                .Where(t => t.TeamNav.Conference == conference)
                .Include(t => t.TeamNav)
                .OrderBy(t => t.GamesBack)
                .ToListAsync();

            return standings;
        }

        public async Task<bool> Fetch()
        {
            var standings = await _dataService.FetchStandings();

            List<Standings> created = new List<Standings>();
            List<Standings> updated = new List<Standings>();

            foreach (Standings s in standings)
            {
                if (!await StandingsExist(s.TeamID))
                {
                    created.Add(Create(s));
                }
                else
                {
                    updated.Add(Edit(s.TeamID, s));
                }
            }
            try
            {
                await _context.AddRangeAsync(created);
                _context.UpdateRange(updated);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private async Task<bool> StandingsExist(int teamID)
        {
            return await _context.Standings.AnyAsync(a => a.TeamID == teamID);
        }

        private Standings Create([Bind("TeamID,Wins,Losses,Percentage,ConferenceWins,ConferenceLosses,DivisionWins,DivisionLosses,HomeWins,HomeLosses,AwayWins,AwayLosses,LastTenWins,LastTenLosses,Streak,GamesBack")] Standings standings)
        {
            return standings;
        }

        private Standings Edit(int id, [Bind("TeamID,Wins,Losses,Percentage,ConferenceWins,ConferenceLosses,DivisionWins,DivisionLosses,HomeWins,HomeLosses,AwayWins,AwayLosses,LastTenWins,LastTenLosses,Streak,GamesBack")] Standings standings)
        {
            if (id != standings.TeamID)
            {
                return null;
            }
            return standings;
        }
    }
}
