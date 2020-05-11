using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StoreManagement.Domain.Entities;

namespace StoreManagement.Infra.Data
{
    public class StoreManagementDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlite(DatabaseConnection.ConnectionConfiguration
                                                    .GetConnectionString("DefaultConnection"));
            }

            dbContextOptionsBuilder.UseLazyLoadingProxies();
        }

        public StoreManagementDbContext(DbContextOptions<StoreManagementDbContext> option) : base(option)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Product> Product { get; set; }
    }
}
