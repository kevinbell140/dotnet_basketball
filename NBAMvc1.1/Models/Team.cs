using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Models
{
    public class Team
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TeamID { get; set; }

        [Required]
        [Display(Name = "Abbreviation")]
        public string Key { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string LeagueID { get; set; }
        public string Conference { get; set; }
        public string Division { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public string TertiaryColor { get; set; }
        public string WikipediaLogoUrl { get; set; }


        public virtual ICollection<Player> Players { get; set; }

    }
}
