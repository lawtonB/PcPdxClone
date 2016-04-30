using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcPdx.Models
{
    [Table("Shows")]
    public class Show
    {
        [Key]
        public int ShowId { get; set; }
        public string ShowTitle { get; set; }
        public int UserId { get; set; }
        public virtual SiteUser User { get; set; }
    }
}
