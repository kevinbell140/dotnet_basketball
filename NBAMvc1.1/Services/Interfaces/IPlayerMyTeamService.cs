using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBAMvc1._1.Models;

namespace NBAMvc1._1.Services.Interfaces
{
    public interface IPlayerMyTeamService
    {
        Task<bool> Create(PlayerMyTeam playerMyTeam);
        Task Delete(PlayerMyTeam playerMyTeam);
        Task<PlayerMyTeam> GetPlayerMyTeamAsync(int playerID, int myTeamID);
        Task<IEnumerable<PlayerMyTeam>> GetPlayerMyTeams();
        Task<IEnumerable<PlayerMyTeam>> GetRosterAsync(int myTeamID);
        Task<IDictionary<string, Player>> GetRosterDictionaryAsync(int myTeamID);
        IQueryable<PlayerMyTeam> GetRosterQueryable(int myTeamID);
    }
}