using Microsoft.Extensions.DependencyInjection;
using StoreManagement.Core.Services;
using StoreManagement.Core.Services.Interfaces;

namespace StoreManagement.Core
{
    public static class CoreModule
    {
        public static void RegisterCore(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
