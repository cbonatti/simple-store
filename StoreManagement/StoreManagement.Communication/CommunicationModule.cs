using Microsoft.Extensions.DependencyInjection;

namespace StoreManagement.Communication
{
    public static class InfraModule
    {
        public static void RegisterICommunication(this IServiceCollection services)
        {
            // services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
        }
    }
}
