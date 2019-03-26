using NBAMvc1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.ViewModels
{
    public class TeamDetailsViewModel
    {
        public Team Team { get; set; }

        public IEnumerable<Player> Players { get; set; }

        public IEnumerable<Game> Last5 { get; set; }

        public IEnumerable<Game> Next3 { get; set; }

        public Player PPGLeader { get; set; }

        public Player RPGLeader { get; set; }

        public Player APGLeader { get; set; }

        public int ConferenceRank { get; set; }

        
    }
}
