using StoreManagement.Domain.Entities;
using StoreManagement.Infra.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Infra.Data.Repositories
{
    public class ProductRepository : DomainRepository<Product>, IProductRepository
    {
        public ProductRepository(StoreManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var query = await GetAllAsync();
            return query.AsEnumerable();
        }

        public async Task<Product> Add(Product product) => await AddAsync(product);

        public async Task<Product> Update(Product product)
        {
            await UpdateAsync(product);
            return product;
        }

        public async Task<Product> Remove(Product product)
        {
            await RemoveAsync(product);
            return product;
        }
    }
}
