namespace StoreManagement.Core.Commands
{
    public abstract class ProductCommandBase
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
