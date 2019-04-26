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

        public async Task<Team> GetTeam(int id)
        {
            var team = await _context.Team
                .Include(t => t.PlayersNav).ThenInclude(p => p.StatsNav)
                .Include(t => t.RecordNav)
                .Where(t => t.TeamID == id)
                .FirstOrDefaultAsync();

            return team;
        }

        public IEnumerable<Team> GetTeams(string sortOrder)
        {
            var teams = from t in _context.Team
                        select t;

            if (teams != null)
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
                return teams;
            }
            return null;
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

        public IEnumerable<Player> GetRoster(List<Player> players, string sortOrder)
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

        public async Task<Boolean> Fetch()
        {
            List<Team> teams = await _dataService.FetchTeams();

            List<Team> created = new List<Team>();
            List<Team> updated = new List<Team>();

            foreach (Team t in teams)
            {

                var exists = await _context.Team.AnyAsync(o => o.TeamID == t.TeamID);

                if (!exists)
                {
                    created.Add(Create(t));
                }
                else
                {
                    updated.Add(Edit(t.TeamID, t));
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

        private Team Create([Bind("TeamID,Key,City,Name,LeagueID,Conference,Division,PrimaryColor,SecondaryColor,TertiaryColor,WikipediaLogoUrl,WikipediaWordMarkUrl,GlobalTeamID")] Team team)
        {
            return team;
        }

        private Team Edit(int id, [Bind("TeamID,Key,City,Name,LeagueID,Conference,Division,PrimaryColor,SecondaryColor,TertiaryColor,WikipediaLogoUrl,WikipediaWordMarkUrl,GlobalTeamID")] Team team)
        {
            if( id != team.TeamID)
            {
                return null;
            }
            return team;
        }
    }
}
