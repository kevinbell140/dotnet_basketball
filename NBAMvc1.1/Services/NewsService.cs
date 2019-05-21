using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using NBAMvc1._1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Services
{
    public class NewsService : INewsService
    {
        private readonly ApplicationDbContext _context;
        private readonly IDataService _dataService;

        public NewsService(ApplicationDbContext context, IDataService dataService)
        {
            _context = context;
            _dataService = dataService;
        }

        public async Task<IEnumerable<News>> GetNewsAsync()
        {
            var news = await _context.News
                .Include(n => n.PlayerNav).ThenInclude(n => n.TeamNav)
                .OrderByDescending(n => n.Updated)
                .ToListAsync();

            return news;
        }

        public async Task<IEnumerable<News>> GetNewsAsync(int num)
        {
            var news = await _context.News
                .Include(n => n.PlayerNav).ThenInclude(n => n.TeamNav)
                .OrderByDescending(n => n.Updated)
                .Take(num).ToListAsync();

            return news;
        }

        public async Task<News> GetNewsByIDAsync(int id)
        {
            var news = await _context.News
                .Include(x => x.PlayerNav).ThenInclude(x => x.TeamNav)
                .Where(x => x.NewsID == id)
                .FirstOrDefaultAsync();

            return news;
        }

        public async Task FetchAsync()
        {
            List<News> news = await _dataService.FetchNewsAsync();
            List<News> created = new List<News>();
            List<News> updated = new List<News>();

            foreach (News n in news)
            {
                if (!await NewsExistsAsync(n.NewsID))
                {
                    if (n != null)
                    {
                        created.Add(n);
                    }
                }
                else
                {
                    if (n != null)
                    {
                        updated.Add(n);
                    }
                }
            }
            try
            {
                await _context.AddRangeAsync(created);
                _context.UpdateRange(updated);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<bool> NewsExistsAsync(int id)
        {
            return await _context.News.AnyAsync(x => x.NewsID == id);
        }
    }
}
