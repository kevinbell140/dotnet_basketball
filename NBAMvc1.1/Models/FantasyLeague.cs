using NBAMvc1._1.Areas.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Models
{
    public class FantasyLeague
    {
        public int FantasyLeagueID { get; set; }

        [ForeignKey("ComissionerNav")]
        public string CommissionerID { get; set; }

        public string Name { get; set; }

        public bool IsFull { get; set; }

        public bool IsSet { get; set; }

        public bool IsActive { get; set; }

        public virtual IEnumerable<FantasyMatchupWeeks> FantasyMatchupWeeksNav { get; set; }

        public virtual List<MyTeam> TeamsNav { get; set; }

        public virtual ApplicationUser ComissionerNav { get; set; }

        public virtual IEnumerable<FantasyLeagueStandings> FantasyLeagueStandingsNav { get; set; }
    }
}
