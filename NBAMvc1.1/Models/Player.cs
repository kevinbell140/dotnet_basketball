using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Models
{
    public class Player
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PlayerID { get; set; }
               
        public string Status { get; set; }
        public int Jersey { get; set; } = 0;

        [DisplayName("Pos")]
        public string Position { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DisplayName("Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        
        public int? Height { get; set; }
        public int? Weight { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        public string UsaTodayHeadshotUrl { get; set; }

        public string PhotoUrl { get; set; }


        public int TeamID { get; set; }


        public virtual Team TeamNav { get; set; }

        public virtual PlayerSeasonStats StatsNav { get; set; }

        public virtual IEnumerable<PlayerGameStats> GameStatsNav { get; set; }

        public virtual IEnumerable<PlayerMyTeam> PlayerMyTeamNav { get; set; }
    }
}
