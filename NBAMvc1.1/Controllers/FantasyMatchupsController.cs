﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBAMvc1._1.Data;
using NBAMvc1._1.Models;
using NBAMvc1._1.ViewModels;

namespace NBAMvc1._1.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class FantasyMatchupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FantasyMatchupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FantasyMatchups
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FantasyMatchup.Include(f => f.AwayTeamNav).Include(f => f.FantasyLeagueNav).Include(f => f.HomeTeamNav);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FantasyMatchups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = new FantasyMatchupDetailsViewModel
            {
                FantasyMatchup = await _context.FantasyMatchup
                .Include(f => f.AwayTeamNav).ThenInclude(f => f.UserNav)
                .Include(f => f.FantasyLeagueNav)
                .Include(f => f.HomeTeamNav).ThenInclude(f => f.UserNav)
                .FirstOrDefaultAsync(m => m.FantasyMatchupID == id)
            };

           var home = await _context.PlayerMyTeam
                .Where(p => p.MyTeamNav.MyTeamID == viewModel.FantasyMatchup.HomeTeamID)
                .Include(p => p.PlayerNav).ThenInclude(p => p.StatsNav)
                .Include(p => p.PlayerNav).ThenInclude(p => p.TeamNav)
                .OrderBy(p => p.PlayerNav.Position)
                .AsNoTracking().ToListAsync();

            var away = await _context.PlayerMyTeam
                .Where(p => p.MyTeamNav.MyTeamID == viewModel.FantasyMatchup.AwayTeamID)
                .Include(p => p.PlayerNav).ThenInclude(p => p.StatsNav)
                .Include(p => p.PlayerNav).ThenInclude(p => p.TeamNav)
                .OrderBy(p => p.PlayerNav.Position)
                .AsNoTracking().ToListAsync();

            Dictionary<string, Player> homePlayers = new Dictionary<string, Player>();
            Dictionary<string, Player> awayPlayers = new Dictionary<string, Player>();

            int posCount = 1;

            foreach (var p in home)
            {
                if (p.PlayerNav.Position == "C")
                {
                    homePlayers.Add(p.PlayerNav.Position, p.PlayerNav);
                }
                else
                {
                    homePlayers.Add(p.PlayerNav.Position + posCount, p.PlayerNav);
                    posCount = (posCount == 1 ? 2 : 1);
                }                    
            }

            foreach (var p in away)
            {
                if (p.PlayerNav.Position == "C")
                {
                    awayPlayers.Add(p.PlayerNav.Position, p.PlayerNav);
                }
                else
                {
                    awayPlayers.Add(p.PlayerNav.Position + posCount, p.PlayerNav);
                    posCount = (posCount == 1 ? 2 : 1);
                }
            }

            foreach (KeyValuePair<string, Player> entry in homePlayers)
            {
                viewModel.HomeRoster[entry.Key] = entry.Value;
            }
            foreach (KeyValuePair<string, Player> entry in awayPlayers)
            {
                viewModel.AwayRoster[entry.Key] = entry.Value;
            }


            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int leagueID)
        {
            var fantasyLeague = await _context.FantasyLeague
                .Where(l => l.FantasyLeagueID == leagueID)
                .FirstOrDefaultAsync();

            if(fantasyLeague == null)
            {
                return NotFound();
            }

            if (!fantasyLeague.IsFull)
            {
                return RedirectToAction("Details", "FantasyLeagues", new { id = leagueID });
            }

            List<MyTeam> teams = await _context.MyTeam
                .Where(t => t.FantasyLeagueID == fantasyLeague.FantasyLeagueID)
                .Include(t => t.HomeMatchupNav)
                .Include(t => t.AwayMatchupNav)
                .ToListAsync(); 

            if(teams == null)
            {
                return NotFound();
            }
            var any = await _context.FantasyMatchup.Where(m => m.FantasyLeagueID == leagueID).AnyAsync();
            if(!any)
            {
                int numWeeks = (teams.Count() - 1) * 2;
                int halfSize = teams.Count() / 2;
                int teamCounter = 0; //for removing teams from the list

                List<MyTeam> listTeams = new List<MyTeam>();

                listTeams.AddRange(teams);
                listTeams.RemoveAt(0);

                int teamSize = listTeams.Count();

                List<FantasyMatchup> matchups = new List<FantasyMatchup>();

                for (int week = 0; week < numWeeks; week++)
                {
                    var matchup = new FantasyMatchup();
                    matchup.Week = week + 1;
                    matchup.FantasyLeagueID = leagueID;
                    matchup.Status = "Scheduled";

                    int teamIdx = week % teamSize;

                    matchup.AwayTeamNav = listTeams[teamIdx];
                    matchup.HomeTeamNav = teams[0];
                    matchup.HomeTeamScore = 0;
                    matchup.AwayTeamScore = 0;

                    matchups.Add(matchup);

                    for (int i = 1; i < halfSize; i++)
                    {
                        var nextMatchup = new FantasyMatchup();
                        nextMatchup.Week = week+1;
                        nextMatchup.FantasyLeagueID = leagueID;
                        nextMatchup.Status = "Scheduled";

                        nextMatchup.AwayTeamNav = listTeams[(week + i) % teamSize];
                        nextMatchup.HomeTeamNav = listTeams[(week + teamSize - i) % teamSize];
                        nextMatchup.AwayTeamScore = 0;
                        nextMatchup.HomeTeamScore = 0;

                        matchups.Add(nextMatchup);
                    }
                }

                if (ModelState.IsValid)
                {
                    _context.FantasyMatchup.AddRange(matchups);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("IsSetConfrim", "FantasyLeagues", new { id = leagueID });
                }
            }


            return RedirectToAction("Details", "FantasyLeagues", new { id = leagueID });
        }


        // GET: FantasyMatchups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fantasyMatchup = await _context.FantasyMatchup.FindAsync(id);
            if (fantasyMatchup == null)
            {
                return NotFound();
            }
            ViewData["AwayTeamID"] = new SelectList(_context.MyTeam, "MyTeamID", "MyTeamID", fantasyMatchup.AwayTeamID);
            ViewData["FantasyLeagueID"] = new SelectList(_context.FantasyLeague, "FantasyLeagueID", "FantasyLeagueID", fantasyMatchup.FantasyLeagueID);
            ViewData["HomeTeamID"] = new SelectList(_context.MyTeam, "MyTeamID", "MyTeamID", fantasyMatchup.HomeTeamID);
            return View(fantasyMatchup);
        }

        // POST: FantasyMatchups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FantasyMatchupID,FantasyLeagueID,Week,Status,HomeTeamID,AwayTeamID,HomeTeamScore,AwayTeamScore")] FantasyMatchup fantasyMatchup)
        {
            if (id != fantasyMatchup.FantasyMatchupID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fantasyMatchup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FantasyMatchupExists(fantasyMatchup.FantasyMatchupID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AwayTeamID"] = new SelectList(_context.MyTeam, "MyTeamID", "MyTeamID", fantasyMatchup.AwayTeamID);
            ViewData["FantasyLeagueID"] = new SelectList(_context.FantasyLeague, "FantasyLeagueID", "FantasyLeagueID", fantasyMatchup.FantasyLeagueID);
            ViewData["HomeTeamID"] = new SelectList(_context.MyTeam, "MyTeamID", "MyTeamID", fantasyMatchup.HomeTeamID);
            return View(fantasyMatchup);
        }

        // GET: FantasyMatchups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fantasyMatchup = await _context.FantasyMatchup
                .Include(f => f.AwayTeamNav)
                .Include(f => f.FantasyLeagueNav)
                .Include(f => f.HomeTeamNav)
                .FirstOrDefaultAsync(m => m.FantasyMatchupID == id);
            if (fantasyMatchup == null)
            {
                return NotFound();
            }

            return View(fantasyMatchup);
        }

        // POST: FantasyMatchups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fantasyMatchup = await _context.FantasyMatchup.FindAsync(id);
            _context.FantasyMatchup.Remove(fantasyMatchup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FantasyMatchupExists(int id)
        {
            return _context.FantasyMatchup.Any(e => e.FantasyMatchupID == id);
        }
    }
}
