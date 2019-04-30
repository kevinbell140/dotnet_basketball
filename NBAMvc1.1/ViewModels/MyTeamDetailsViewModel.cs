using NBAMvc1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.ViewModels
{
    public class MyTeamDetailsViewModel
    {

        public MyTeam MyTeam { get; set; }

        public IDictionary<string, Player> Roster { get; set; }
    }
}
