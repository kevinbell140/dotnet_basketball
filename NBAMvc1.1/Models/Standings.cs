using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Models
{
    public class Standings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("TeamNav")]
        public int TeamID { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Percentage { get; set; }

        public int ConferenceWins { get; set; }

        public int ConferenceLosses { get; set; }

        public int DivisionWins { get; set; }

        public int DivisionLosses { get; set; }

        public int HomeWins { get; set; }

        public int HomeLosses { get; set; }

        public int AwayWins { get; set; }

        public int AwayLosses { get; set; }

        public int LastTenWins { get; set; }

        public int LastTenLosses { get; set; }

        public int Streak { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal GamesBack { get; set; }

        public virtual Team TeamNav { get; set; }
    }
}
