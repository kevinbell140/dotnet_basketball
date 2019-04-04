using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Models
{
    public class PlayerMyTeam
    {
        public int PlayerID { get; set; }

        public int MyTeamID { get; set; }

        public virtual Player PlayerNav { get; set; }

        public virtual MyTeam MyTeamNav { get; set; }
    }
}
