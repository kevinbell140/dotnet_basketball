using System.Collections.Generic;
using System.Threading.Tasks;
using NBAMvc1._1.Models;

namespace NBAMvc1._1.Services.Interfaces
{
    public interface IMyTeamsService
    {
        Task<bool> Create(MyTeam myTeam);
        Task Delete(MyTeam myTeam);
        Task Edit(MyTeam myTeam);
        Task<MyTeam> GetMyTeamByIDAsync(int myTeamID);
        Task<List<MyTeam>> GetMyTeamsByLeague(int leagueID);
        Task<IEnumerable<MyTeam>> GetMyTeamsByUserID(string id);
    }
}