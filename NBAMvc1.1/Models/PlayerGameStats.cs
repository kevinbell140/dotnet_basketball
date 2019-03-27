using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Models
{
    public class PlayerGameStats
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StatID { get; set; }
        
        [ForeignKey("PlayerNav")]
        public int PlayerID { get; set; }

        [ForeignKey("GameNav")]
        public int GameID { get; set; }

        public DateTime Updated { get; set; }
        
        [Display(Name = "Min")]
        public int Minutes { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "FG")]
        public decimal FieldGoalsMade { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "FGA")]
        public decimal FieldGoalsAttempted { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "FG%")]
        public decimal FieldGoalsPercentage { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "3PT")]
        public decimal ThreePointersMade { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "3PA")]
        public decimal ThreePointersAttempted { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "3P%")]
        public decimal ThreePointersPercentage { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "FT")]
        public decimal FreeThrowsMade { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "FTA")]
        public decimal FreeThrowsAttempted { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "FT%")]
        public decimal FreeThrowsPercentage { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "ORB")]
        public decimal OffensiveRebounds { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "DRB")]
        public decimal DefensiveRebounds { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "TRB")]
        public decimal Rebounds { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "AST")]
        public decimal Assists { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "STL")]
        public decimal Steals { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "BLK")]
        public decimal BlockedShots { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "TO")]
        public decimal Turnovers { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "PF")]
        public decimal PersonalFouls { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "PTS")]
        public decimal Points { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "+/-")]
        public decimal PlusMinus { get; set; }

        public virtual Player PlayerNav { get; set; }

        public virtual Game GameNav { get; set; }
    }
}
