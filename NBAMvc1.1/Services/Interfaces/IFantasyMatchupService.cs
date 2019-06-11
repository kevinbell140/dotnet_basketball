using System.Collections.Generic;
using System.Threading.Tasks;
using NBAMvc1._1.Models;

namespace NBAMvc1._1.Services.Interfaces
{
    public interface IFantasyMatchupService
    {
        Task Create(FantasyLeague fantasyLeague);
        Task<Dictionary<string, PlayerGameStats>> GetGameStatsDictionaryAsync(IDictionary<string, Player> roster, FantasyMatchupWeeks matchupWeek);
        Task<List<PlayerGameStats>> GetGameStatsListAsync(IEnumerable<PlayerMyTeam> roster, FantasyMatchupWeeks matchupWeek);
        Task<FantasyMatchup> GetMatchupByIDAsync(int id);
        Task<IEnumerable<FantasyMatchup>> GetMatchups();
        Task<IEnumerable<FantasyMatchup>> GetMatchupsByWeekAsync(int leagueID, int selectedWeek);
        Task<IEnumerable<FantasyMatchup>> GetMatchupsForScoringAsync();
        Task<IEnumerable<FantasyMatchup>> GetMatchupsForUpdate();
        Task<Dictionary<string, string>> GetOpponentLogoDictionaryAsync(IDictionary<string, Player> roster, FantasyMatchupWeeks matchupWeek);
        Task SetRecordedAsync(List<FantasyMatchup> matchups, bool status);
        Task UpdateCurrentWeek(IEnumerable<FantasyMatchup> matchups);
        Task UpdateScoresAsync(IEnumerable<FantasyMatchup> matchups);
        Task<decimal[]> CalculateScoreAsync(FantasyMatchup matchup);
    }
}