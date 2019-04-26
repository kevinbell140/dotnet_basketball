using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using NBAMvc1._1.Services;

namespace NBAMvc1._1.Controllers
{
    public class StandingsController : Controller
    {
        private readonly StandingsService _standingsService;

        public StandingsController(StandingsService standingsService)
        {
            _standingsService = standingsService;
        }

        // GET: Standings
        public async Task<IActionResult> Index(string filter = "Eastern")
        {
            ViewData["filter"] = filter;
            List<Standings> standings = await _standingsService.GetStandings(filter); 

            return View(standings);
        }

        //GET : Teams/Fetch()
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Fetch()
        {
            if (await _standingsService.Fetch())
            {
                return RedirectToAction("Index", "Standings");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
