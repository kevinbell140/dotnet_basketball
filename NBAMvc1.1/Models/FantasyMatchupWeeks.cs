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

        public int WeekNum { get; set; }

        public DateTime Date { get; set; }

        public virtual FantasyLeague FantasyLeagueNav { get; set; }

        public virtual IEnumerable<FantasyMatchup> FantasyMatchupsNav { get; set; }
    }
}
