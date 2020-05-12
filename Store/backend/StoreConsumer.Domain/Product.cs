using System;

namespace StoreConsumer.Domain
{
    public class Product
    {
        public Product(Guid id, string name, double price, int stock)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
        public int Stock { get; private set; }

        public Product SetName(string name)
        {
            Name = name;
            return this;
        }

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
