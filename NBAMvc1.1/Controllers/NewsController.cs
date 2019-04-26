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
        private readonly NewsService _newsService;

        public NewsController(ApplicationDbContext context, NewsService newsService)
        {
            _newsService = newsService;
        }

        // GET: News
        public async Task<IActionResult> Index()
        {
            var news = await _newsService.GetNews();
            return View(news);
        }

        // GET: News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _newsService.GetNewsByID(id.Value);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        public async Task<IActionResult> Fetch()
        {
            if (await _newsService.Fetch())
            {
                return RedirectToAction("Index", "News");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
