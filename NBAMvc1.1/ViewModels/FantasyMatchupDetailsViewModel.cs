using NBAMvc1._1.Models;
using System;
using System.Collections.Generic;

namespace NBAMvc1._1.ViewModels
{
    public class FantasyMatchupDetailsViewModel
    {
        public FantasyMatchup FantasyMatchup { get; set; }

        public MyTeam HomeTeam { get; set; }

        public MyTeam AwayTeam { get; set; }

        public IDictionary<string, Player> HomeRoster { get; set; }

        public IDictionary<string, Player> AwayRoster { get; set; }

        public Dictionary<string, string> HomeOpp { get; set; }

        public Dictionary<string, string> AwayOpp { get; set; }

        public Dictionary<string, PlayerGameStats> HomeStats { get; set; }

        public Dictionary<string, PlayerGameStats> AwayStats { get; set; }

        public decimal HomeScore
        {
            get
            {
                decimal count = 0;
                foreach(var s in HomeStats)
                {
                    count += (s.Value != null ? s.Value.FantasyPoints : 0);
                }
                return count;
            }
        }

        public decimal AwayScore
        {
            get
            {
                decimal count = 0;
                foreach (var s in AwayStats)
                {
                    count += (s.Value != null ? s.Value.FantasyPoints : 0);
                }
                return count;
            }
        }

        public DateTime Date { get; set; }

    }
}
