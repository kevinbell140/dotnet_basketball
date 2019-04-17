using NBAMvc1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.ViewModels
{
    public class FantasyMatchupsCreateViewModel
    {
        public FantasyLeague FantasyLeague { get; set; }

        public IEnumerable<MyTeam> HomeTeams { get; set; }

        public IEnumerable<MyTeam> AwayTeams { get; set; }
    }
}
