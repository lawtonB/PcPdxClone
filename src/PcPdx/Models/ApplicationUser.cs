using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace PcPdx.Models
{
    public class ApplicationUser : IdentityUser
    {

        public DbSet<SiteUser> SiteUsers { get; set; }
        public DbSet<Show> Shows { get; set; }
    }
}
