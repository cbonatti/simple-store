using StoreManagement.Domain.Entities;

namespace StoreManagement.Core.Commands
{
    public class AddProductCommand : ProductCommandBase
    {
        public Product ToEntity() => new Product(Name, Price, Stock);
    }
}
