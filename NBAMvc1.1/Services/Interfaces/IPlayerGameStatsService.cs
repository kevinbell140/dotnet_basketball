using System.Collections.Generic;
using System.Threading.Tasks;
using NBAMvc1._1.Models;

namespace NBAMvc1._1.Services.Interfaces
{
    public interface IPlayerGameStatsService
    {
        Task FetchAsync();
        Task<List<PlayerGameStats>> GetGameLeadersAsync(int gameID);
        Task<IEnumerable<PlayerGameStats>> GetPlayerGameStats();
        Task<PlayerGameStats> GetPlayerGameStatsByGameAsync(int playerID, int gameID);
    }
}