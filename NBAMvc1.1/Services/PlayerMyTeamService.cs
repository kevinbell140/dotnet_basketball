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
    public class PlayerMyTeamService
    {
        private readonly ApplicationDbContext _context;
        private readonly PlayersService _playersService;

        public PlayerMyTeamService(PlayersService playersService, ApplicationDbContext context)
        {
            _context = context;
            _playersService = playersService;
        }

        public async Task<IEnumerable<PlayerMyTeam>> GetPlayerMyTeams()
        {
            var players = await _context.PlayerMyTeam
                 .Include(p => p.MyTeamNav)
                 .Include(p => p.PlayerNav)
                 .AsNoTracking().ToListAsync();

            return players;
        }

        public async Task<PlayerMyTeam> GetPlayerMyTeamAsync(int playerID, int myTeamID)
        {
            var playerMyTeam = await _context.PlayerMyTeam
                .Include(p => p.MyTeamNav)
                .Include(p => p.PlayerNav)
                .Where(p => p.PlayerID == playerID && p.MyTeamID == myTeamID)
                .AsNoTracking().FirstOrDefaultAsync();

            return playerMyTeam;
        }

        public async Task<IEnumerable<PlayerMyTeam>> GetRosterAsync(int myTeamID)
        {
            var roster = await _context.PlayerMyTeam
                .Include(p => p.MyTeamNav)
                .Include(p => p.PlayerNav).ThenInclude(p => p.TeamNav)
                .Include(p => p.PlayerNav).ThenInclude(p => p.StatsNav)
                .Where(p => p.MyTeamID == myTeamID)
                .AsNoTracking().ToListAsync();

            return roster;
        }

        public IQueryable<PlayerMyTeam> GetRosterQueryable(int myTeamID)
        {
            IQueryable<PlayerMyTeam> roster;
            roster = _context.PlayerMyTeam
                .Include(p => p.MyTeamNav)
                .Include(p => p.PlayerNav).ThenInclude(p => p.TeamNav)
                .Include(p => p.PlayerNav).ThenInclude(p => p.StatsNav)
                .Where(p => p.MyTeamID == myTeamID)
                .AsNoTracking();

            return roster;
        }

        public async Task<IDictionary<string, Player>> GetRosterDictionaryAsync(int myTeamID)
        {
            var roster = await GetRosterAsync(myTeamID);
            Dictionary<string, Player> players = new Dictionary<string, Player>
            {
                { "PG1", null},
                { "PG2", null},
                { "SG1", null},
                { "SG2", null},
                { "SF1", null},
                { "SF2", null},
                { "PF1", null},
                { "PF2", null},
                { "C", null},
            };

            //int posCount = 1;
            foreach (var p in roster)
            {
                if (p.PlayerNav.Position == "C")
                {
                    players[p.PlayerNav.Position] = p.PlayerNav;
                }
                else
                {
                    if (players[p.PlayerNav.Position + 1] == null)
                    {
                        players[p.PlayerNav.Position + 1] = p.PlayerNav;
                    }
                    else
                    {
                        players[p.PlayerNav.Position + 2] = p.PlayerNav;
                    }
                }
            }
            return players;
        }

        private int GetRosterSpots(IEnumerable<PlayerMyTeam> roster, string pos)
        {
            int spots = 0;
            spots = roster.Where(p => p.PlayerNav.Position == pos).Count();
            return spots;
        }

        private async Task<bool> IsPlayerOnRoster(int myTeamID, int playerID)
        {
            var roster = GetRosterQueryable(myTeamID);
            return await roster.AnyAsync(x => x.PlayerID == playerID);
        }

        public async Task<bool> Create(PlayerMyTeam playerMyTeam)
        {
            Player player = null;
            IEnumerable<PlayerMyTeam> roster = null;
            var playerTask = _playersService.GetPlayerAsync(playerMyTeam.PlayerID);
            var rosterTask =  GetRosterAsync(playerMyTeam.MyTeamID);
            var tasks = new List<Task> { playerTask, rosterTask };
            while (tasks.Any())
            {
                Task finshed = await Task.WhenAny(tasks);
                if(finshed == playerTask)
                {
                    tasks.Remove(playerTask);
                    player = await playerTask;
                }else if(finshed == rosterTask)
                {
                    tasks.Remove(rosterTask);
                    roster = await rosterTask;
                }
                else
                {
                    tasks.Remove(finshed);
                }
            }

            int spots = GetRosterSpots(roster, player.Position);
            if (player.Position == "C" && spots > 0 || player.Position != "C" && spots > 1 || await IsPlayerOnRoster(playerMyTeam.MyTeamID, playerMyTeam.PlayerID))
            {
                return false;
            }
            try
            {
                await _context.AddAsync(playerMyTeam);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {          
                throw;
            }
        }

        public async Task Delete(PlayerMyTeam playerMyTeam)
        {
            try
            {
                _context.PlayerMyTeam.Remove(playerMyTeam);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
