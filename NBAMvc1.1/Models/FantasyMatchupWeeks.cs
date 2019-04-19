using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Models
{
    public class FantasyMatchupWeeks
    {
        public int FantasyMatchupWeeksID { get; set; }


        [ForeignKey("FantasyLeagueNav")]
        public int FantasyLeagueID { get; set; }


        public DateTime Week1 { get; set; }
        public DateTime Week2 { get; set; }
        public DateTime Week3 { get; set; }
        public DateTime Week4 { get; set; }
        public DateTime Week5 { get; set; }
        public DateTime Week6 { get; set; }
        public DateTime Week7 { get; set; }
        public DateTime Week8 { get; set; }

        public virtual FantasyLeague FantasyLeagueNav { get; set; }

        public virtual IEnumerable<FantasyMatchup> FantasyMatchupsNav { get; set; }
    }
}
