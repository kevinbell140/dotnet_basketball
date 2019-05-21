using System.Collections.Generic;
using System.Threading.Tasks;
using NBAMvc1._1.Models;

namespace NBAMvc1._1.Services.Interfaces
{
    public interface IStandingsService
    {
        Task FetchAsync();
        Task<List<Standings>> GetStandingsAsync(string conference);
    }
}