using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NBAMvc1._1.Data;
using NBAMvc1._1.Services;
using NBAMvc1._1.Services.Interfaces;

namespace NBAMvc1._1.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(ApplicationDbContext context, INewsService newsService)
        {
            _newsService = newsService;
        }

        // GET: News
        public async Task<IActionResult> Index()
        {
            var news = await _newsService.GetNewsAsync();
            return View(news);
        }

        // GET: News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var news = await _newsService.GetNewsByIDAsync(id.Value);
            return View(news);
        }
    }
}
