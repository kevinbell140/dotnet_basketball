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

        [ForeignKey("CommisionerNav")]
        public int CommissionerID { get; set; }




        public virtual IEnumerable<MyTeam> Teams { get; set; }


        public virtual ApplicationUser ComissionerNav { get; set; }
    }
}
