using Microsoft.AspNetCore.Identity;
using NBAMvc1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Areas.Identity
{
    public class ApplicationUser : IdentityUser
    {


        public virtual IEnumerable<MyTeam> MyTeamNav { get; set; }
    }
}
