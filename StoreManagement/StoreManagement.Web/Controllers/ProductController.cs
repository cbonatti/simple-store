using Microsoft.AspNetCore.Mvc;
using StoreManagement.Core.Commands;
using StoreManagement.Core.Responses;
using StoreManagement.Core.Services.Interfaces;
using StoreManagement.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet, Route("{id}")]
        public async Task<Result<ProductResponse>> Get(Guid id) => await _service.Get(id);

        [HttpGet]
        public async Task<Result<IEnumerable<ProductResponse>>> GetAll() => await _service.GetAll();

        [HttpPost]
        public async Task<Result<ProductResponse>> Post([FromBody]AddProductCommand fornecedor) => await _service.Add(fornecedor);

        [HttpPut]
        public async Task<Result<ProductResponse>> Put([FromBody]UpdateProductCommand fornecedor) => await _service.Update(fornecedor);

        [HttpDelete, Route("{id}")]
        public async Task<Result<ProductResponse>> Delete(Guid id) => await _service.Delete(new DeleteProductCommand() { Id = id });
    }
}
