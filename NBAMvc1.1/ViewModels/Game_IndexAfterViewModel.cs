using NBAMvc1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.ViewModels
{
    public class Game_IndexAfterViewModel
    {
        public Game Game { get; set; }

        public IEnumerable<PlayerGameStats> Leaders { get; set; }
    }
}
