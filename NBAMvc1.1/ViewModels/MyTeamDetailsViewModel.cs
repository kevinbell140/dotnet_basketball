using NBAMvc1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.ViewModels
{
    public class MyTeamDetailsViewModel
    {

        public MyTeam MyTeam { get; set; }

        public IDictionary<string, Player> Roster { get; set; }

        public MyTeamDetailsViewModel()
        {
            Roster = new Dictionary<string, Player>()
            {
                { "PG1", null},
                { "PG2", null},
                { "SG1", null},
                { "SG2", null},
                { "SF1", null},
                { "SF2", null},
                { "PF1", null},
                { "PF2", null},
                { "C", null},
            };
        }
    }
}
