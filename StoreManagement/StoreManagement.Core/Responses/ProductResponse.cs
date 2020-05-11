using StoreManagement.Domain.Entities;

namespace StoreManagement.Core.Responses
{
    public class ProductResponse : ProductResponseBase
    {
        public static ProductResponse ToResponse(Product product)
        {
            if (product == null)
                return null;
            return new ProductResponse()
            {
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                Id = product.Id
            };
        }
    }
}
