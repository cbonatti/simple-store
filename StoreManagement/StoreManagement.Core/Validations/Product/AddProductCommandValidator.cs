using StoreManagement.Core.Commands;
using StoreManagement.Infra;

namespace StoreManagement.Core.Validations.Product
{
    public class AddProductCommandValidator : CommandBaseValidator
    {
        public AddProductCommandValidator(AddProductCommand command) : base(command)
        {
        }

        public ValidationResult Validate() => ValidateBase();
    }
}
