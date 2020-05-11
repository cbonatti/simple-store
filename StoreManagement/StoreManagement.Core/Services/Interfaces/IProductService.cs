using StoreManagement.Core.Commands;
using StoreManagement.Core.Responses;
using StoreManagement.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreManagement.Core.Services.Interfaces
{
    public interface IProductService
    {
        Task<Result<ProductResponse>> Get(Guid id);
        Task<Result<IEnumerable<ProductResponse>>> GetAll();
        Task<Result<ProductResponse>> Add(AddProductCommand command);
        Task<Result<ProductResponse>> Update(UpdateProductCommand command);
        Task<Result<ProductResponse>> Delete(DeleteProductCommand command);
    }
}
