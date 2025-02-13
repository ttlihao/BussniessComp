using GuYou.Repositories.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace GuYou.Repositories.DbContext
{
    public class CoffeShopManagementContext : IdentityDbContext<User>
    {
        public CoffeShopManagementContext()
        {
        }

        public CoffeShopManagementContext(DbContextOptions<CoffeShopManagementContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<CoffeeMix> CoffeeMixes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ReviewLike> ReviewLikes { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public static string GetConnectionString(string connectionStringName)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = config.GetConnectionString(connectionStringName);
            return connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(GetConnectionString("DefaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure cascading delete behavior

            // Configuration for User entity relationships
            builder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<User>()
                .HasMany(u => u.Reviews)
                .WithOne(r => r.User)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuration for CoffeeMix entity relationships
            builder.Entity<CoffeeMix>()
                .HasMany(cm => cm.CoffeeMixDetails)
                .WithOne(cmd => cmd.CoffeeMix)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CoffeeMix>()
                .HasMany(cm => cm.Reviews)
                .WithOne(r => r.CoffeeMix)
                .HasForeignKey(r => r.CoffeeMixId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuration for CoffeeBean entity relationships
            builder.Entity<CoffeeBean>()
                .HasMany(cb => cb.CoffeeMixDetails)
                .WithOne(cmd => cmd.CoffeeBean)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CoffeeBean>()
                .HasOne(cb => cb.Inventory)
                .WithOne(i => i.CoffeeBean)
                .OnDelete(DeleteBehavior.NoAction);

            // Configuration for Packaging entity relationships
            builder.Entity<Packaging>()
                .HasOne(p => p.Inventory)
                .WithOne(i => i.Packaging)
                .OnDelete(DeleteBehavior.NoAction);

            // Configuration for Order entity relationships
            builder.Entity<Order>()
                .HasMany(o => o.OrderDetails)
                .WithOne(od => od.Order)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Order>()
                .HasMany(o => o.Payments)
                .WithOne(p => p.Order)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Order>()
                .HasOne(o => o.Packaging)
                .WithMany()
                .HasForeignKey(o => o.PackagingId)
                .OnDelete(DeleteBehavior.SetNull); // Optional: If you want to preserve the packaging even if deleted from the order

            builder.Entity<Order>()
                .HasOne(o => o.ShippingDetail)
                .WithOne(sd => sd.Order)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuration for Review entity relationships
            builder.Entity<Review>()
                .HasMany(r => r.ReviewLikes)
                .WithOne(rl => rl.Review)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Review>()
                .HasOne(r => r.CoffeeMix)
                .WithMany(cm => cm.Reviews)
                .HasForeignKey(r => r.CoffeeMixId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuration for ReviewLike entity relationships
            builder.Entity<ReviewLike>()
                .HasOne(rl => rl.Review)
                .WithMany(r => r.ReviewLikes)
                .HasForeignKey(rl => rl.ReviewId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ReviewLike>()
                .HasOne(rl => rl.User)
                .WithMany()
                .HasForeignKey(rl => rl.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configuration for Category entity relationships
            builder.Entity<Category>()
                .HasMany(c => c.CoffeeBeans)
                .WithOne(cb => cb.Category)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Category>()
                .HasMany(c => c.Packagings)
                .WithOne(p => p.Category)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuration for Supplier entity relationships
            builder.Entity<Supplier>()
                .HasMany(s => s.CoffeeBeans)
                .WithOne(cb => cb.Supplier)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure CustomMixConfiguration as a keyless entity
            builder.Entity<CustomMixConfiguration>().HasNoKey();

            // Specify precision and scale for decimal properties
            builder.Entity<CoffeeBean>()
                .Property(cb => cb.Price)
                .HasPrecision(18, 2);

            builder.Entity<CoffeeMix>()
                .Property(cm => cm.Price)
                .HasPrecision(18, 2);

            builder.Entity<Discount>()
                .Property(d => d.DiscountAmount)
                .HasPrecision(18, 2);

            builder.Entity<Discount>()
                .Property(d => d.DiscountPercentage)
                .HasPrecision(5, 2);

            builder.Entity<Order>()
                .Property(o => o.DiscountAmount)
                .HasPrecision(18, 2);

            builder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasPrecision(18, 2);

            builder.Entity<OrderDetail>()
                .Property(od => od.UnitPrice)
                .HasPrecision(18, 2);

            builder.Entity<Packaging>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            builder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);
        }
    }
}
