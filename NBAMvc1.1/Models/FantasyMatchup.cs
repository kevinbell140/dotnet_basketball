﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBAMvc1._1.Models
{
    public class FantasyMatchup
    {
        public int FantasyMatchupID { get; set; }

        [ForeignKey("FantasyLeagueNav")]
        public int FantasyLeagueID { get; set; }

        public int Week { get; set; }

        public bool Recorded { get; set; } = false;

        public string Status { get; set; }

        [ForeignKey("HomeTeamNav")]
        public int? HomeTeamID { get; set; }

        [ForeignKey("AwayTeamNav")]
        public int? AwayTeamID { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? HomeTeamScore { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? AwayTeamScore { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual MyTeam HomeTeamNav { get; set; }

        public virtual MyTeam AwayTeamNav { get; set; }

        public virtual FantasyLeague FantasyLeagueNav { get; set; }

    }
}
