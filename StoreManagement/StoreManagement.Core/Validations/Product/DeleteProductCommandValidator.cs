using StoreManagement.Core.Commands;
using StoreManagement.Infra;

namespace StoreManagement.Core.Validations.Product
{
    public class DeleteProductCommandValidator
    {
        private readonly DeleteProductCommand command;

        public DeleteProductCommandValidator(DeleteProductCommand command)
        {
            this.command = command;
        }

        public ValidationResult Validate() => new IdValidator().Validate(command.Id);
    }
}