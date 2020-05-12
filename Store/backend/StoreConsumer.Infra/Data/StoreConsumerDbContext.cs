using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StoreConsumer.Domain;

namespace StoreConsumer.Infra.Data
{
    public class StoreConsumerDbContext : DbContext
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

        public StoreConsumerDbContext(DbContextOptions<StoreConsumerDbContext> option) : base(option)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Product> Product { get; set; }
    }
}
