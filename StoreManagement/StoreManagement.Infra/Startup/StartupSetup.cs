using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreManagement.Infra.Data;

namespace StoreManagement.Infra
{
    public static class StartupSetup
    {
        public static void AddDbContext(this IServiceCollection services) =>
            services.AddDbContext<StoreManagementDbContext>(options =>
                options.UseSqlite(DatabaseConnection.ConnectionConfiguration
                                                    .GetConnectionString("DefaultConnection")));
    }
}
