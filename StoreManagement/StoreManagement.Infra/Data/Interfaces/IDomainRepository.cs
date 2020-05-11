namespace StoreManagement.Infra.Data.Interfaces
{
    public interface IDomainRepository<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {
    }
}
