using System;
using System.Collections.Generic;
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
        public string Position { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public int TeamID { get; set; }


        public virtual Team TeamNav { get; set; }

        public virtual PlayerSeasonStats StatsNav { get; set; }
    }
}
