using Microsoft.Extensions.DependencyInjection;
using StoreManagement.Infra.Data;
using StoreManagement.Infra.Data.Interfaces;
using StoreManagement.Infra.Data.Repositories;
using StoreManagement.Infra.Data.Repositories.Interfaces;
using StoreManagement.Infra.Service;

namespace StoreManagement.Infra
{
    public static class InfraModule
    {
        public static void RegisterInfra(this IServiceCollection services)
        {
            // Base
            services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<,>));
            services.AddScoped(typeof(IValidationServiceBase<>), typeof(ValidationServiceBase<>));
            services.AddScoped(typeof(IDomainRepository<>), typeof(DomainRepository<>));

            // Repositories
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
