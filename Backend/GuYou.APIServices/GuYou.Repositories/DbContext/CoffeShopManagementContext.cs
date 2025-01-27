using GuYou.Repositories.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GuYou.Repositories.DbContext
{
    public class CoffeShopManagementContext : IdentityDbContext
    {
        public CoffeShopManagementContext()
        {
        }

        public CoffeShopManagementContext(DbContextOptions<CoffeShopManagementContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

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

            // Configure any specific settings for the User model if needed
            // For example, setting up indexes, constraints, etc.
        }
    }
}
