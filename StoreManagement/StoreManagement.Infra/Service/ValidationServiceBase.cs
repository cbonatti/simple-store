using StoreManagement.Infra.Data.Interfaces;
using StoreManagement.Infra.Results;
using System.Linq;

namespace StoreManagement.Infra.Service
{
    public class ValidationServiceBase<T> : IValidationServiceBase<T> where T : StoreResponse
    {
        public Result<T> Validate(ValidationResult validationResult)
        {
            if (!validationResult.Success)
                return new Result<T>(validationResult.Messages.FirstOrDefault());
            return new Result<T>();
        }
    }
}
