using System.Threading.Tasks;

namespace NBAMvc1._1.Services.Interfaces
{
    public interface IPlayerSeasonStatsService
    {
        Task FetchAsync();
    }
}