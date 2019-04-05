using Microsoft.AspNetCore.Identity;
using NBAMvc1._1.Areas.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Models
{
    public class MyTeam
    {
        public int MyTeamID { get; set; }

        [ForeignKey("UserNav")]
        public string UserID { get; set; }


        [ForeignKey("PG1Nav")]
        public string PG1 { get; set; }

        public virtual ApplicationUser PG1Nav { get; set; }
        
        [ForeignKey("PG2Nav")]
        public string PG2 { get; set; }
        
        public virtual ApplicationUser PG2Nav { get; set; }



        [ForeignKey("SG1Nav")]
        public string SG1 { get; set; }

        public virtual ApplicationUser SG1Nav { get; set; }

        [ForeignKey("SG2Nav")]
        public string SG2 { get; set; }

        public virtual ApplicationUser SG2Nav { get; set; }



        [ForeignKey("SF1Nav")]
        public string SF1 { get; set; }

        public virtual ApplicationUser SF1Nav { get; set; }

        [ForeignKey("SF2Nav")]
        public string SF2 { get; set; }

        public virtual ApplicationUser SF2Nav { get; set; }



        [ForeignKey("PF1Nav")]
        public string PF1 { get; set; }

        public virtual ApplicationUser PF1Nav { get; set; }

        [ForeignKey("PF2Nav")]
        public string PF2 { get; set; }

        public virtual ApplicationUser PF2Nav { get; set; }



        [ForeignKey("CNav")]
        public string C { get; set; }

        public virtual ApplicationUser CNav { get; set; }




        public virtual ApplicationUser UserNav { get; set; }



        public virtual ICollection<PlayerMyTeam> PlayerMyTeamNav { get; set; }
      
    }
}
