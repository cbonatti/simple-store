using Microsoft.AspNetCore.Mvc;
using StoreConsumer.Domain;
using StoreConsumer.DTOs;
using StoreConsumer.Infra.Data.Interfaces;
using System;
using System.Threading.Tasks;

namespace StoreConsumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepositoryAsync<Product> repository;

        public ProductController(IRepositoryAsync<Product> repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public async Task<bool> Post([FromBody]ProductDTO dto)
        {
            var product = new Product(dto.Id, dto.Name, dto.Price, dto.Stock);
            await repository.AddAsync(product);
            return true;
        }

        [HttpPut]
        public async Task<bool> Put([FromBody]ProductDTO dto)
        {
            var product = await repository.GetByIdAsync(dto.Id);
            product
                .SetName(dto.Name)
                .SetPrice(dto.Price)
                .SetStock(dto.Stock);
            await repository.UpdateAsync(product);
            return true;
        }

        [HttpDelete, Route("{id}")]
        public async Task<bool> Delete(Guid id) => await repository.RemoveAsync(id);
    }
}
