using System;
using System.Threading.Tasks;

namespace StoreManagement.Communication.Http.Interfaces
{
    public interface IHttpCommunication<T>
    {
        Task Post(T entity);
        Task Put(T entity);
        Task Delete(Guid id);
    }
}
