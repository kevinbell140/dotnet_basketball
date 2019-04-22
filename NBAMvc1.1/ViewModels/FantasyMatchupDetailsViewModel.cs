using NBAMvc1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.ViewModels
{
    public class FantasyMatchupDetailsViewModel
    {
        public FantasyMatchup FantasyMatchup { get; set; }

        public MyTeam HomeTeam { get; set; }

        public MyTeam AwayTeam { get; set; }

        public Dictionary<string, Player> HomeRoster { get; set; }

        public Dictionary<string, Player> AwayRoster { get; set; }

        public Dictionary<string, string> HomeOpp { get; set; }

        public Dictionary<string, string> AwayOpp { get; set; }



        public DateTime Date { get; set; }

        public FantasyMatchupDetailsViewModel()
        {
            HomeRoster = new Dictionary<string, Player>
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

            AwayRoster = new Dictionary<string, Player>
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

            HomeOpp = new Dictionary<string, string>
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

            AwayOpp = new Dictionary<string, string>
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
