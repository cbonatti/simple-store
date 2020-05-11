using StoreManagement.Infra.Results;

namespace StoreManagement.Core.Responses
{
    public abstract class ProductResponseBase : StoreResponse
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
