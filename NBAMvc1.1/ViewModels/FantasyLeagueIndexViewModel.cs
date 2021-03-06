﻿using NBAMvc1._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.ViewModels
{
    public class FantasyLeagueIndexViewModel
    {
        public IEnumerable<FantasyLeague> ClosedLeagues { get; set; }

        public IEnumerable<FantasyLeague> OpenLeagues { get; set; }
    }
}
