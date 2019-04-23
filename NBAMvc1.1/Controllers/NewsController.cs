using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using NBAMvc1._1.Services;

namespace NBAMvc1._1.Controllers
{


    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly DataService _service;

        public NewsController(ApplicationDbContext context, DataService service)
        {
            _context = context;
            _service = service;
        }

        // GET: News
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.News
                .Include(n => n.PlayerNav).ThenInclude(n => n.TeamNav)
                .OrderByDescending(n => n.Updated);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .Include(n => n.PlayerNav).ThenInclude(n => n.TeamNav)
                .FirstOrDefaultAsync(m => m.NewsID == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }


        // POST: News/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public News Create([Bind("NewsID,Source,Updated,Title,Content,Url,Author,PlayerID")] News news)
        {
            if (ModelState.IsValid)
            {
                return news;
            }
            return null;
        }

        // POST: News/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public News Edit(int id, [Bind("NewsID,Source,Updated,Title,Content,Url,Author,PlayerID")] News news)
        {
            if (id != news.NewsID)
            {
                return null;
            }

            if (ModelState.IsValid)
            {
                return news;
            }
            return null;
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.NewsID == id);
        }

        public async Task<IActionResult> Fetch()
        {
            List<News> news = await _service.FetchNews();
            List<News> created = new List<News>();
            List<News> updated = new List<News>();

            foreach (News n in news)
            {
                var exists = await _context.News.AnyAsync(a => a.NewsID == n.NewsID);

                if (!exists)
                {
                    var createdNews = Create(n);
                    if(createdNews != null)
                    {
                        created.Add(createdNews);
                    }
                }
                else
                {
                    var updatedNews = Edit(n.NewsID, n);
                    if(updatedNews != null)
                    {
                        updated.Add(updatedNews);
                    }
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.AddRangeAsync(created);
                    _context.UpdateRange(updated);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
