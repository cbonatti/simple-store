namespace StoreManagement.Infra.Data.Interfaces
{
    public interface IValidationServiceBase<T> where T : class
    {
        Result<T> Validate(ValidationResult validationResult);
    }
}
