using StoreManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreManagement.Infra.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> Add(Product product);
        Task<Product> Update(Product product);
        Task<Product> Remove(Product product);
    }
}
