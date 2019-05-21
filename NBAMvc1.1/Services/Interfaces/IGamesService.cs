using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NBAMvc1._1.Models;

namespace NBAMvc1._1.Services.Interfaces
{
    public interface IGamesService
    {
        Task FetchAsync();
        Task FetchAsync(string isPost);
        Task<IEnumerable<Game>> GetFinalGamesByTeamAsync(int id);
        Task<Game> GetGameAsync(int id);
        Task<IEnumerable<Game>> GetGamesByDateAsync(DateTime dayOf);
        Task<IEnumerable<Game>> GetLastAsync(int num);
        Task<IEnumerable<Game>> GetLastAsync(int teamID, int num);
        Task<IEnumerable<Game>> GetNextAsync(int num);
        Task<IEnumerable<Game>> GetNextAsync(int teamID, int num);
    }
}