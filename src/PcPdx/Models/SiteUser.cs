using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcPdx.Models
{
    [Table("SiteUsers")]
    public class SiteUser
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<Show> Shows { get; set; }
    }
}
