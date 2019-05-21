using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using NBAMvc1._1.Services;
using NBAMvc1._1.Services.Interfaces;

namespace NBAMvc1._1.Controllers
{
    public class StandingsController : Controller
    {
        private readonly IStandingsService _standingsService;

        public StandingsController(IStandingsService standingsService)
        {
            _standingsService = standingsService;
        }

        // GET: Standings
        public async Task<IActionResult> Index(string filter = "Eastern")
        {
            ViewData["filter"] = filter;
            List<Standings> standings = await _standingsService.GetStandingsAsync(filter); 
            return View(standings);
        }
    }
}
