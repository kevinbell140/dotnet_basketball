using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Models
{
    public class FantasyLeagueStandings
    {
        public int FantasyLeagueStandingsID { get; set; }


        [ForeignKey("FantasyLeagueNav")]
        public int FantasyLeagueID { get; set; }

        [ForeignKey("MyTeamNav")]
        public int? MyTeamID { get; set; }

        public int Wins { get; set; } = 0;

        public int Losses { get; set; } = 0;

        public int Draws { get; set; } = 0;

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "FPS")]
        public decimal FantasyPoints { get; set; } = 0;


        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "FPA")]
        public decimal FantasyPointsAgainst { get; set; } = 0;

        public int GamesBack { get; set; } = 0;

        public DateTime Updated { get; set; }

        public virtual MyTeam MyTeamNav { get; set; }

        public virtual FantasyLeague FantasyLeagueNav { get; set; }
    }
}
