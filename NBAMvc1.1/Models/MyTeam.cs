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
       
        public virtual ApplicationUser UserNav { get; set; }

        public virtual ICollection<PlayerMyTeam> PlayerMyTeamNav { get; set; }
      
    }
}
