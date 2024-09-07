using Entities;
using Microsoft.EntityFrameworkCore;
namespace RG_Store.DAL.DB
{
        public class ApplicationDbContext : DbContext
        {
        /*            public DbSet<Item> Items { get; set; }
                    public DbSet<Order> Orders { get; set; }
                    public DbSet<User> Users { get; set; } */
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}