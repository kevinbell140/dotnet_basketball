using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NBAMvc1._1.Models;

namespace NBAMvc1._1.Services.Interfaces
{
    public interface IFantasyMatchupsWeeksService
    {
        Task Create(FantasyLeague fantasyLeague);
        Task<FantasyMatchupWeeks> GetFantasyMatchupWeekByLeagueAsync(int leagueID, int weekNum);
        Task<FantasyMatchupWeeks> GetFantasyMatchupWeekByLeagueByDateAsync(int leagueID, DateTime date);
        Task<IEnumerable<FantasyMatchupWeeks>> GetFantasyMatchupWeeksByLeague(int leagueID);
        Task<IEnumerable<FantasyMatchupWeeks>> GetWeeks();
        Task<bool> WeeksExist(int leagueID);
    }
}