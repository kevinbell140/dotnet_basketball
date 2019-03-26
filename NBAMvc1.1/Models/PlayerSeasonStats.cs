using System;
using System.Collections.Generic;
using System.ComponentModel;
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


        [Column(TypeName = "decimal(18, 2)")]

        public decimal PPG
        {
            get
            {
                try
                {
                    return decimal.Round((Points / Games), 2);
                }catch(Exception)
                {
                    return 0;
                }
                
            }
        }

        [Column(TypeName = "decimal(3, 2)")]
        [DisplayName("3PG")]
        public decimal ThreesPG
        {
            get
            {
                try
                {
                    return decimal.Round((ThreePointersMade / Games), 2);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        [Column(TypeName = "decimal(3, 2)")]
        public decimal APG
        {
            get
            {
                try
                {
                    return decimal.Round((Assists / Games), 2);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        [Column(TypeName = "decimal(3, 2)")]
        public decimal RPG
        {
            get
            {
                try
                {
                    return decimal.Round((Rebounds / Games), 2);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        [Column(TypeName = "decimal(3, 2)")]
        public decimal BPG
        {
            get
            {
                try
                {
                    return decimal.Round((BlockedShots / Games), 2);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }


        [Column(TypeName = "decimal(3, 2)")]
        public decimal SPG
        {
            get
            {
                try
                {
                    return decimal.Round((Steals / Games), 2);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        [Column(TypeName = "decimal(3, 2)")]
        public decimal TPG
        {
            get
            {
                try
                {
                    return decimal.Round((Turnovers / Games), 2);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }




        public virtual Player PlayNav { get; set; }




    }
}
