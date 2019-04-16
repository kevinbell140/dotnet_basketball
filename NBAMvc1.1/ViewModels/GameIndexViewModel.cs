using NBAMvc1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.ViewModels
{
    public class GameIndexViewModel
    {
        public IEnumerable<Game> Games { get; set; }

        public DateTime? dayOf { get; set; }
    }
}
