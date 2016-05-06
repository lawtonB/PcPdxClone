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

        public virtual ApplicationUser User { get; set; }
        [ForeignKey("ApplicationUserId")]
        public string ApplicationUserId {get; set;}

        public Show(string showTitle, string applicationUserId, int showId)
        {
            ShowTitle = showTitle;
            ApplicationUserId = applicationUserId;
            ShowId = showId;
        }
    }
}
