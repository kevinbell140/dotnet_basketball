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
    public class TeamsService
    {
        private readonly ApplicationDbContext _context;
        private readonly DataService _dataService;

        public TeamsService(ApplicationDbContext context, DataService dataService)
        {
            _context = context;
            _dataService = dataService;
        }

        public async Task<Team> GetTeamAsync(int id)
        {
            var team = await _context.Team
                .Include(t => t.PlayersNav).ThenInclude(p => p.StatsNav)
                .Include(t => t.RecordNav)
                .Where(t => t.TeamID == id)
                .FirstOrDefaultAsync();

            return team;
        }

        public async Task<IEnumerable<Team>> GetTeamsAsync(string sortOrder)
        {;
            var teams = _context.Team.AsNoTracking();
            if (teams != null && await teams.AnyAsync())
            {
                switch (sortOrder)
                {
                    case "city_desc":
                        teams = teams.OrderByDescending(t => t.City);
                        break;
                    case "Name":
                        teams = teams.OrderBy(t => t.Name);
                        break;
                    case "name_desc":
                        teams = teams.OrderByDescending(t => t.Name);
                        break;
                    case "Division":
                        teams = teams.OrderBy(t => t.Division);
                        break;
                    case "division_desc":
                        teams = teams.OrderByDescending(t => t.Division);
                        break;
                    default:
                        teams = teams.OrderBy(t => t.City);
                        break;
                }         
            }
            return teams;
        }

        public Player GetPPGLeader(List<Player> players)
        {
            Player leader = players.Where(p => p.StatsNav != null)
                .OrderByDescending(p => p.StatsNav.PPG)
                .FirstOrDefault();
            return leader;
        }

        public Player GetRPGLeader(List<Player> players)
        {
            Player leader = players.Where(p => p.StatsNav != null)
                .OrderByDescending(p => p.StatsNav.RPG)
                .FirstOrDefault();
            return leader;
        }

        public Player GetAPGLeader(List<Player> players)
        {
            Player leader = players.Where(p => p.StatsNav != null)
                .OrderByDescending(p => p.StatsNav.APG)
                .FirstOrDefault();
            return leader;
        }

        public IEnumerable<Player> SortRoster(List<Player> players, string sortOrder)
        {
            List<Player> roster = new List<Player>();
            switch (sortOrder)
            {
                case "pos_desc":
                    roster = players.Where(p => p.StatsNav != null).OrderByDescending(p => p.Position).ToList();
                    break;
                case "Player":
                    roster = players.Where(p => p.StatsNav != null).OrderBy(p => p.LastName).ToList();
                    break;
                case "player_desc":
                    roster = players.Where(p => p.StatsNav != null).OrderByDescending(p => p.LastName).ToList();
                    break;
                case "PPG":
                    roster = players.Where(p => p.StatsNav != null).OrderBy(p => p.StatsNav.PPG).ToList();
                    break;
                case "ppg_desc":
                    roster = players.Where(p => p.StatsNav != null).OrderByDescending(p => p.StatsNav.PPG).ToList();
                    break;
                case "RPG":
                    roster = players.Where(p => p.StatsNav != null).OrderBy(p => p.StatsNav.RPG).ToList();
                    break;
                case "rpg_desc":
                    roster = players.Where(p => p.StatsNav != null).OrderByDescending(p => p.StatsNav.RPG).ToList();
                    break;
                case "APG":
                    roster = players.Where(p => p.StatsNav != null).OrderBy(p => p.StatsNav.APG).ToList();
                    break;
                case "apg_desc":
                    roster = players.Where(p => p.StatsNav != null).OrderByDescending(p => p.StatsNav.APG).ToList();
                    break;
                default:
                    roster = players.Where(p => p.StatsNav != null).OrderBy(p => p.Position).ToList();
                    break;
            }
            return roster;
        }

        public async Task FetchAsync()
        {
            List<Team> teams = await _dataService.FetchTeamsAsync();
            List<Team> created = new List<Team>();
            List<Team> updated = new List<Team>();

            foreach (Team t in teams)
            {
                if (!await _context.Team.AnyAsync(o => o.TeamID == t.TeamID))
                {
                    created.Add(t);
                }
                else
                {
                    updated.Add(t);
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
    }
}
