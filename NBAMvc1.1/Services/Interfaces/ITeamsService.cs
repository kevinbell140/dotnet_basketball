using System.Collections.Generic;
using System.Threading.Tasks;
using NBAMvc1._1.Models;

namespace NBAMvc1._1.Services.Interfaces
{
    public interface ITeamsService
    {
        Task FetchAsync();
        Player GetAPGLeader(List<Player> players);
        Player GetPPGLeader(List<Player> players);
        Player GetRPGLeader(List<Player> players);
        Task<Team> GetTeamAsync(int id);
        Task<IEnumerable<Team>> GetTeamsAsync(string sortOrder);
        IEnumerable<Player> SortRoster(List<Player> players, string sortOrder);
    }
}