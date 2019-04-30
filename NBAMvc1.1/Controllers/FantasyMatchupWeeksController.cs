using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NBAMvc1._1.Services;

namespace NBAMvc1._1.Controllers
{
    public class FantasyMatchupWeeksController : Controller
    {
        private readonly FantasyMatchupsWeeksService _fantasyMatchupWeeksService;
        private readonly FantasyLeagueService _fantasyLeagueService;

        public FantasyMatchupWeeksController(FantasyMatchupsWeeksService fantasyMatchupWeeksService, FantasyLeagueService fantasyLeagueService)
        {
            _fantasyMatchupWeeksService = fantasyMatchupWeeksService;
            _fantasyLeagueService = fantasyLeagueService;
        }

        // GET: FantasyMatchupWeeks
        public async Task<IActionResult> Index()
        {
            var weeks = await _fantasyMatchupWeeksService.GetWeeks();
            return View(weeks);
        }

        // GET: FantasyMatchupWeeks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var fantasyMatchupWeeks = await _fantasyMatchupWeeksService.GetFantasyMatchupWeeksByID(id.Value);

            if (fantasyMatchupWeeks == null)
            {
                return NotFound();
            }
            return View(fantasyMatchupWeeks);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? leagueID)
        {
            if(leagueID == null)
            {
                return NotFound();
            }

            var league = await _fantasyLeagueService.GetLeague(leagueID.Value);
            if(league == null)
            {
                return NotFound();
            }

            if (await _fantasyLeagueService.Create(league))
            {
                return RedirectToAction("Create", "FantasyMatchups", new { leagueID = leagueID });
            }
            return RedirectToAction("Details", "FantasyLeagues", new { id = leagueID });           
        }
    }
}
