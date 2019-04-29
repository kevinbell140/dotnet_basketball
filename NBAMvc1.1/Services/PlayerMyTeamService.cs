using Microsoft.EntityFrameworkCore;
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
        private readonly DataService _dataService;
        private readonly FantasyLeagueService _fantasyLeagueService;
        private readonly PlayersService _playersService;

        public PlayerMyTeamService(PlayersService playersService, ApplicationDbContext context, DataService dataService, FantasyLeagueService fantasyLeagueService)
        {
            _context = context;
            _dataService = dataService;
            _fantasyLeagueService = fantasyLeagueService;
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

        public async Task<PlayerMyTeam> GetPlayerMyTeam(int playerID, int myTeamID)
        {
            var playerMyTeam = await _context.PlayerMyTeam
                .Include(p => p.MyTeamNav)
                .Include(p => p.PlayerNav)
                .Where(p => p.PlayerID == playerID && p.MyTeamID == myTeamID)
                .AsNoTracking().FirstOrDefaultAsync();

            return playerMyTeam;
        }

        public IQueryable<PlayerMyTeam> GetRoster(int myTeamID)
        {
            IQueryable<PlayerMyTeam> roster;
            roster = _context.PlayerMyTeam
                .Include(p => p.MyTeamID)
                .Include(p => p.PlayerNav)
                .Where(p => p.MyTeamID == myTeamID)
                .AsNoTracking();

            return roster;
        }

        public int GetRosterSpots(IEnumerable<PlayerMyTeam> roster, string pos)
        {
            int spots = 0;
            spots = roster.Where(p => p.PlayerNav.Position == pos).Count();
            return spots;
        }

        public async Task<bool> IsPlayerOnRoster(int myTeamID, int playerID)
        {
            var roster = GetRoster(myTeamID);
            return await roster.AnyAsync(x => x.PlayerID == playerID);
        }

        public async Task<bool> Create(PlayerMyTeam playerMyTeam)
        {
            var player = await _playersService.GetPlayer(playerMyTeam.PlayerID);
            var roster = GetRoster(playerMyTeam.MyTeamID);
            //its broken here
            int spots = GetRosterSpots(roster, playerMyTeam.PlayerNav.Position);

            //need to create a custom exception for this
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
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(PlayerMyTeam playerMyTeam)
        {
            try
            {
                _context.PlayerMyTeam.Remove(playerMyTeam);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                throw;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
