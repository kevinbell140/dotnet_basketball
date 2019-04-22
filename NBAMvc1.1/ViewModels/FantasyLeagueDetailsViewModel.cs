using NBAMvc1._1.Models;
using NBAMvc1._1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.ViewModels
{
    public class FantasyLeagueDetailsViewModel
    {
        public FantasyLeague FantasyLeague { get; set; }

        public IDictionary<int, MyTeam> Teams { get; set; }

        public IEnumerable<FantasyMatchup> Matchups { get; set; }

        public int SelectedWeek { get; set; }

        public int CurrentWeek { get; set; }

        public FantasyLeagueDetailsViewModel()
        {
            Teams = new Dictionary<int, MyTeam>()
            {
                {1, null },
                {2, null },
                {3, null },
                {4, null },
                {5, null },
                {6, null },
                {7, null },
                {8, null },
            };
        }
    }
}
 