using System.Collections.Generic;
using System.Threading.Tasks;
using NBAMvc1._1.Models;

namespace NBAMvc1._1.Services.Interfaces
{
    public interface IFantasyLeagueStandingsService
    {
        Task Create(FantasyLeague fantasyLeague);
        Task<IEnumerable<FantasyLeagueStandings>> GetStandingsActiveAsync();
        Task<IEnumerable<FantasyLeagueStandings>> GetStandingsAsync();
        Task<List<FantasyMatchup>> UpdateStandingsAsync();
    }
}