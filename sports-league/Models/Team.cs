using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsLeague.Models
{
    [Table("Teams")]
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public int DivisionId { get; set; }
        public int CaptainId { get; set; }
        public string Name { get; set; }
        public virtual Division Division { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
