using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Web.Miratech.Models
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=DefaultConnection")
        {

        }

        public DbSet<MenuModels> Menu { get; set; }
        public DbSet<CategoryModels> Category { get; set; }
        public DbSet<ArticleModels> Article { get; set; }
        public DbSet<SlideModels> Slide { get; set; }
        public DbSet<UserModels> User { get; set; }
        public DbSet<RoleModels> Role { get; set; }
        public DbSet<ClientModels> Client { get; set; }
        public DbSet<LogModels> Log { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<UserProfile> UserProfiles { get; set; }
        //public DbSet<Categories> Category { get; set; }
        //public DbSet<Article> Articles { get; set; }

        //public DbSet<OurClients> OurClients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}