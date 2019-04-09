using NBAMvc1._1.Models;
using NBAMvc1._1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.ViewModels
{
    public class PlayerMyTeamCreateViewModel
    {
        public MyTeam MyTeam { get; set; }

        public PaginatedList<Player> Players { get; set; }

        public PlayerMyTeam PlayerMyTeam { get; set; }

    }
}
