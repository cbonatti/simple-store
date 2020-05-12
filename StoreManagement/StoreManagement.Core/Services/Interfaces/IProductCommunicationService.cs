using StoreManagement.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace StoreManagement.Core.Services.Interfaces
{
    public interface IProductCommunicationService
    {
        Task Post(Product product);
        Task Put(Product product);
        Task Delete(Guid id);
    }
}
