//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.Data.Entity;
//using Microsoft.AspNet.Identity.EntityFramework;



//namespace PcPdx.Models
//{
//    public class PcPdxContext : IdentityDbContext<ApplicationUser>
//    {
//        protected override void OnModelCreating(ModelBuilder builder)
//        {
//            base.OnModelCreating(builder);

//        }
//        public DbSet<SiteUser> SiteUsers { get; set; }
//        public DbSet<Show> Shows { get; set; }
//        protected override void OnConfiguring(DbContextOptionsBuilder options)
//        {
//            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PcPdx;integrated security = True");
//        }

//    }
//}
