using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using StoreManagement.Core.Services;
using StoreManagement.Core.Services.Interfaces;
using StoreManagement.Infra.Data;
using System;
using System.Net.Http;

namespace StoreManagement.Core
{
    public static class CoreModule
    {
        public static void RegisterCore(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddHttpClient<IProductCommunicationService, ProductCommunicationService>(client =>
            {
                var url = DatabaseConnection.ConnectionConfiguration.GetSection("StoreConsumerUrl").Value;
                client.BaseAddress = new Uri(url);
            })
            .AddPolicyHandler(GetRetryPolicy());
        }

        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(10, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }
    }
}
