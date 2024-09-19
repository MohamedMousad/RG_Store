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
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<FavouriteItem> FavouriteItems { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

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
            // Configure one-to-one relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<Cart>(c => c.UserId);


            modelBuilder.Entity<User>()
                .HasOne(u => u.Favourite)
                .WithOne(c => c.User)
                .HasForeignKey<Favourite>(c => c.UserId);



            modelBuilder.Entity<Order>()
          .HasMany(o => o.OrderItems)
          .WithOne(oi => oi.Order)
          .HasForeignKey(oi => oi.OrderId);

            base.OnModelCreating(modelBuilder);
        }
    }
}