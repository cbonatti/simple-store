using StoreManagement.Communication.Http.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Communication.Http
{
    public class HttpCommunication<T> : IHttpCommunication<T>
    {
        public HttpCommunication()
        {

        }

        public Task Post(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Put(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
