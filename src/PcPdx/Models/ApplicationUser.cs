using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcPdx.Models
{
    [Table("Users")]
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Show> Shows { get; set; }
    }
}
