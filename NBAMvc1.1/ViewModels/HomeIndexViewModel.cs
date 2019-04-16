using NBAMvc1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Game> Last4 { get; set; }

        public IDictionary<int, PlayerGameStats> Leaders { get; set; }

        public IEnumerable<Game> Next4 { get; set; }

        public IEnumerable<News> News { get; set; }

        public IEnumerable<MyTeam> MyTeams { get; set; }

        public IEnumerable<FantasyLeague> FantasyLeagues { get; set; }


        public HomeIndexViewModel()
        {
            Leaders = new Dictionary<int, PlayerGameStats>()
            {
                {0, null},
                {1, null },
                {2, null },
                {3, null },
                {4, null },
                {5, null },
                {6, null },
                {7, null },
            };
        }
    }
}
