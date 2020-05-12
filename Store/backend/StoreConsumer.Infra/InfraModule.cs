using Microsoft.Extensions.DependencyInjection;
using StoreConsumer.Infra.Data;
using StoreConsumer.Infra.Data.Interfaces;
using StoreConsumer.Infra.Data.Repositories;
using StoreConsumer.Infra.Data.Repositories.Interfaces;

namespace StoreConsumer.Infra
{
    public static class InfraModule
    {
        public static void RegisterInfra(this IServiceCollection services)
        {
            // Base
            services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddScoped(typeof(IDomainRepository<>), typeof(DomainRepository<>));

            // Repositories
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
