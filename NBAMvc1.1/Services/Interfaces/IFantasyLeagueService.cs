using System.Collections.Generic;
using System.Threading.Tasks;
using NBAMvc1._1.Models;

namespace NBAMvc1._1.Services.Interfaces
{
    public interface IFantasyLeagueService
    {
        Task AddTeamConfirm(int id);
        Task Create(FantasyLeague fantasyLeague);
        Task Delete(int id);
        Task Edit(FantasyLeague fantasyLeague);
        Task<bool> FantasyLeagueExists(int id);
        Task<FantasyLeague> GetLeagueAsync(int id);
        Task<IEnumerable<FantasyLeague>> GetLeaguesAsync();
        Task<Dictionary<int, MyTeam>> GetTeamsDictionaryAsync(int leagueID);
        Task IsActiveFalseAsync(FantasyLeague fantasyLeague);
        Task RemoveTeamConfirm(int id);
        Task UpdateCurrentWeekAsync(FantasyLeague fantasyLeague, int week);
        Task SetLeagueAsync(FantasyLeague fantasyLeague);
    }
}