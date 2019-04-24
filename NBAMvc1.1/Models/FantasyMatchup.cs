using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Models
{
    public class FantasyMatchup
    {
        public int FantasyMatchupID { get; set; }

        [ForeignKey("FantasyLeagueNav")]
        public int FantasyLeagueID { get; set; }

        public int Week { get; set; }

        public string Status { get; set; }

        [ForeignKey("HomeTeamNav")]
        public int? HomeTeamID { get; set; }

        [ForeignKey("AwayTeamNav")]
        public int? AwayTeamID { get; set; }

        public int? HomeTeamScore { get; set; }

        public int? AwayTeamScore { get; set; }


        public virtual MyTeam HomeTeamNav { get; set; }

        public virtual MyTeam AwayTeamNav { get; set; }

        public virtual FantasyLeague FantasyLeagueNav { get; set; }

    }
}
