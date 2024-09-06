using Entities;
using Microsoft.EntityFrameworkCore;
namespace RG_Store.DAL.DB
{
        public class ApplicationDbContext : DbContext
        {
            public DbSet<Item> Items { get; set; }
            public DbSet<Order> Orders { get; set; }
            public DbSet<User> Users { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=RG_Store;Trusted_Connection=True;TrustServerCertificate=True;");
            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
            }
        }
}