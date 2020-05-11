using StoreManagement.Core.Commands;
using StoreManagement.Infra;

namespace StoreManagement.Core.Validations.Product
{
    public abstract class CommandBaseValidator
    {
        private readonly ProductCommandBase command;

        protected CommandBaseValidator(ProductCommandBase command)
        {
            this.command = command;
        }

        protected ValidationResult ValidateBase()
        {
            var result = new ValidationResult();
            if (!ValidateName())
                result.AddMessage(ProductValidationMessages.NAME);
            if (!ValidatePrice())
                result.AddMessage(ProductValidationMessages.PRICE);
            return result;
        }

        private bool ValidateName() => !string.IsNullOrEmpty(command.Name);
        private bool ValidatePrice() => command.Price > 0;
    }
}
