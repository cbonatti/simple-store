namespace StoreManagement.Domain.Base
{
    public abstract class EntityBase : IdentityEntity
    {
        public string Name { get; private set; }

        public void SetName(string name) => Name = name;
    }
}
