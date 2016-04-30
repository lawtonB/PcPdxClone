using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;



namespace PcPdx.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)

        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PcPdx;integrated security = True");
        }

        public DbSet<SiteUser> SiteUsers { get; set; }
        public DbSet<Show> Shows { get; set; }
    }
}
