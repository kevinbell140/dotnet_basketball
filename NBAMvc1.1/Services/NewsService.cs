using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Services
{
    public class NewsService
    {
        private readonly ApplicationDbContext _context;
        private readonly DataService _dataService;

        public NewsService(ApplicationDbContext context, DataService dataService)
        {
            _context = context;
            _dataService = dataService;
        }

        public async Task<IEnumerable<News>> GetNews()
        {
            var news = await _context.News
                .Include(n => n.PlayerNav).ThenInclude(n => n.TeamNav)
                .OrderByDescending(n => n.Updated)
                .ToListAsync();

            return news;
        }

        public async Task<IEnumerable<News>> GetNews(int num)
        {
            var news = await _context.News
                .Include(n => n.PlayerNav).ThenInclude(n => n.TeamNav)
                .OrderByDescending(n => n.Updated)
                .Take(num).ToListAsync();

            return news;
        }

        public async Task<News> GetNewsByID(int id)
        {
            var news = await _context.News
                .Include(x => x.PlayerNav).ThenInclude(x => x.TeamNav)
                .Where(x => x.NewsID == id)
                .FirstOrDefaultAsync();

            return news;
        }

        public async Task<bool> Fetch()
        {
            List<News> news = await _dataService.FetchNews();
            List<News> created = new List<News>();
            List<News> updated = new List<News>();

            foreach (News n in news)
            {
                if (!await NewsExists(n.NewsID))
                {
                    var createdNews = Create(n);
                    if (createdNews != null)
                    {
                        created.Add(createdNews);
                    }
                }
                else
                {
                    var updatedNews = Edit(n.NewsID, n);
                    if (updatedNews != null)
                    {
                        updated.Add(updatedNews);
                    }
                }
            }
            try
            {
                await _context.AddRangeAsync(created);
                _context.UpdateRange(updated);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task<bool> NewsExists(int id)
        {
            return await _context.News.AnyAsync(x => x.NewsID == id);
        }

        private News Create([Bind("NewsID,Source,Updated,Title,Content,Url,Author,PlayerID")] News news)
        {
            return news;
        }

        private News Edit(int id, [Bind("NewsID,Source,Updated,Title,Content,Url,Author,PlayerID")] News news)
        {
            if (id != news.NewsID)
            {
                return null;
            }
            return news;
        }
    }
}
