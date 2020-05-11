using StoreManagement.Core.Validations.Product;
using StoreManagement.Infra;
using System;

namespace StoreManagement.Core.Validations
{
    public class IdValidator
    {
        private readonly ValidationResult result;

        public IdValidator()
        {
            this.result = new ValidationResult();
        }

        public IdValidator(ValidationResult result)
        {
            this.result = result;
        }

        public ValidationResult Validate(Guid id)
        {
            if (id.Equals(Guid.Empty))
                result.AddMessage(ProductValidationMessages.ID);
            return result;
        }
    }
}
