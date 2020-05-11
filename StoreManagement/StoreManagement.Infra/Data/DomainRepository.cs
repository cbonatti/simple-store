using StoreManagement.Infra.Data;
using StoreManagement.Infra.Data.Interfaces;

namespace StoreManagement.Infra
{
    public class DomainRepository<TEntity> : RepositoryAsync<TEntity>,
                                             IDomainRepository<TEntity> where TEntity : class
    {
        protected DomainRepository(StoreManagementDbContext dbContext) : base(dbContext)
        {
        }
    }
}
