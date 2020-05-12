using Newtonsoft.Json;
using StoreManagement.Core.Services.Interfaces;
using StoreManagement.Domain.Entities;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Core.Services
{
    public class ProductCommunicationService : IProductCommunicationService
    {
        private readonly HttpClient _httpClient;
        private const string ServiceUrl = "product";

        public ProductCommunicationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Delete(Guid id)
        {
            using (var response = await _httpClient.DeleteAsync($"{ServiceUrl}/{id}"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
            }
        }

        public async Task Post(Product product)
        {
            using (var response = await _httpClient.PostAsync(ServiceUrl, SerializeProduct(product)))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
            }
        }

        public async Task Put(Product product)
        {
            using (var response = await _httpClient.PutAsync(ServiceUrl, SerializeProduct(product)))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
            }
        }

        private StringContent SerializeProduct(Product product) => new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
    }
}
