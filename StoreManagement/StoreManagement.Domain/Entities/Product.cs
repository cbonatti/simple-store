using StoreManagement.Domain.Base;
using System;

namespace StoreManagement.Domain.Entities
{
    public class Product : EntityBase
    {
        public Product()
        {
        }

        public Product(string name, double price, int stock)
        {
            SetName(name);
            SetPrice(price);
            SetStock(stock);
        }

        public Product(Guid id, string name, double price, int stock)
            : this(name, price, stock)
        {
            SetId(id);
        }


        public double Price { get; private set; }
        public int Stock { get; private set; }

        public Product SetPrice(double price)
        {
            Price = price;
            return this;
        }

        public Product SetStock(int stock)
        {
            Stock = stock;
            return this;
        }
    }
}
