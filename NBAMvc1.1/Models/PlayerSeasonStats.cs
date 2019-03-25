using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Models
{
    public class PlayerSeasonStats
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StatID { get; set; }

        [ForeignKey("PlayerNav")]
        public int PlayerID { get; set; }

        public int Games { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal FieldGoalsPercentage { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal FreeThrowsPercentage { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal ThreePointersMade { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Points { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Assists { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Rebounds { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Steals { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal BlockedShots { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Turnovers { get; set; }

        
        public virtual Player PlayNav { get; set; }




    }
}
