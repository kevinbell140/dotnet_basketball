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

        [Display(Name = "W")]
        public int Wins { get; set; }

        [Display(Name = "L")]
        public int Losses { get; set; }

        [Display(Name = "Win%")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Percentage { get; set; }

        [Display(Name = "ConfW")]
        public int ConferenceWins { get; set; }

        [Display(Name = "ConfL")]
        public int ConferenceLosses { get; set; }

        [Display(Name = "Conf")]
        public string ConferenceRecord
        {
            get
            {
                return ConferenceWins + " - " + ConferenceLosses;
            }
        }

        [Display(Name = "DivW")]
        public int DivisionWins { get; set; }

        [Display(Name = "DivL")]
        public int DivisionLosses { get; set; }

        [Display(Name = "Div")]
        public string DivisionRecord
        {
            get
            {
                return DivisionWins + " - " + DivisionLosses;
            }
        }

        [Display(Name = "HomeW")]
        public int HomeWins { get; set; }

        [Display(Name = "HomeL")]
        public int HomeLosses { get; set; }

        [Display(Name = "Home")]
        public string HomeRecord
        {
            get
            {
                return HomeWins + " - " + HomeLosses;
            }
        }

        [Display(Name = "AwayW")]
        public int AwayWins { get; set; }

        [Display(Name = "AwayL")]
        public int AwayLosses { get; set; }


        [Display(Name = "Away")]
        public string AwayRecord
        {
            get
            {
                return AwayWins + " - " + AwayLosses;
            }
        }



        [Display(Name = "L10W")]
        public int LastTenWins { get; set; }

        [Display(Name = "L10L")]
        public int LastTenLosses { get; set; }

        [Display(Name = "L10")]
        public string LastTen
        {
            get
            {
                return LastTenWins + " - " + LastTenLosses;
            }
        }


        [Display(Name = "Stk")]
        public int Streak { get; set; }

        [Display(Name = "GB")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal GamesBack { get; set; }

        public DateTime TimeStamp { get; set; } = DateTime.Now;

        public virtual Team TeamNav { get; set; }
    }
}
