using System;

namespace StoreManagement.Core.Commands
{
    public class UpdateProductCommand : ProductCommandBase
    {
        public Guid Id { get; set; }
    }
}
