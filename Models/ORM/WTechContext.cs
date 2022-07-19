using System;
using Microsoft.EntityFrameworkCore;

namespace WTechCoreSample.Models.ORM
{
    public class WTechContext : DbContext
    {




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=94.73.151.2; Database=u9338606_dbC3C; UID=u9338606_userC3C; PWD=WYlr77H1GEwq92J");

           //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=WTechConextSampleDB; Trusted_connection=true");
        }

        public DbSet<WebUser> WebUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<AdminActivity> AdminActivities { get; set; }

    }
}
