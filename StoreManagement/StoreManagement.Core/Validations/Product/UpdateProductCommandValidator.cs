using StoreManagement.Core.Commands;
using StoreManagement.Infra;

namespace StoreManagement.Core.Validations.Product
{
    public class UpdateProductCommandValidator : CommandBaseValidator
    {
        private readonly UpdateProductCommand command;

        public UpdateProductCommandValidator(UpdateProductCommand command) : base(command)
        {
            this.command = command;
        }

        public ValidationResult Validate()
        {
            var result = ValidateBase();
            new IdValidator(result).Validate(command.Id);
            return result;
        }
    }
}
