using System.Linq;
using System.Threading.Tasks;
using NBAMvc1._1.Models;

namespace NBAMvc1._1.Services.Interfaces
{
    public interface IPlayersService
    {
        Task FetchAsync();
        Task<Player> GetPlayerAsync(int id);
        IQueryable<Player> GetPlayers(string searchString);
        IQueryable<Player> GetPlayers(string searchString, string posFilter);
        IQueryable<Player> SortPLayers(IQueryable<Player> players, string sortParam);
    }
}