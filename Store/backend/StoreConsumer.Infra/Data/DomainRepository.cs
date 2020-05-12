using StoreConsumer.Infra.Data.Interfaces;

namespace StoreConsumer.Infra.Data
{
    public class DomainRepository<TEntity> : RepositoryAsync<TEntity>,
                                            IDomainRepository<TEntity> where TEntity : class
    {
        protected DomainRepository(StoreConsumerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
