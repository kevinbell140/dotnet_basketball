using System.Collections.Generic;
using System.Threading.Tasks;
using NBAMvc1._1.Models;

namespace NBAMvc1._1.Services.Interfaces
{
    public interface IDataService
    {
        Task<List<Game>> FetchGamesAsync();
        Task<List<Game>> FetchGamesPostAsync();
        Task<List<PlayerGameStats>> FetchGameStatsAsync(string date);
        Task<List<News>> FetchNewsAsync();
        Task<List<Player>> FetchPlayersAsync();
        Task<List<PlayerSeasonStats>> FetchSeasonStatsAsync();
        Task<List<Standings>> FetchStandingsAsync();
        Task<List<Team>> FetchTeamsAsync();
    }
}