using System.Collections.Generic;
using System.Threading.Tasks;
using NBAMvc1._1.Models;

namespace NBAMvc1._1.Services.Interfaces
{
    public interface INewsService
    {
        Task FetchAsync();
        Task<IEnumerable<News>> GetNewsAsync();
        Task<IEnumerable<News>> GetNewsAsync(int num);
        Task<News> GetNewsByIDAsync(int id);
    }
}