using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RG_Store.DAL.Entities;
using System.Reflection;
namespace RG_Store.DAL.DB
{
        public class ApplicationDbContext : IdentityDbContext<User>
        {
             /*      public DbSet<Item> Items { get; set; }
                    public DbSet<Order> Orders { get; set; }*/
          public DbSet<User> Users { get; set; } 
          public DbSet<Item> Items { get; set; } 
          public DbSet<Order> Orders { get; set; } 
          public DbSet<Cart> Carts { get; set; }            
          public DbSet<Category> Categories { get; set; }            
          public DbSet<Favourite> Favourites { get; set; }            

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {           
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}