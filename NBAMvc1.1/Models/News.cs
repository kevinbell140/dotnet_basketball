using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBAMvc1._1.Models
{
    public class News
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NewsID { get; set; }

        public string Source { get; set; }

        public DateTime Updated { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Url { get; set; }

        public string Author { get; set; }

        [ForeignKey("PlayerNav")]
        public int PlayerID { get; set; }


        public virtual Player PlayerNav { get; set; }
    }
}
