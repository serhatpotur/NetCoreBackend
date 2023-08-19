using FluentValidation;

namespace NetCoreBackend.Core.CrossCuttingConcerns.Validation;

public static class ValidationTool
{
    // IValidator : AbstractValidatordan gelir
    public static void Validate(IValidator validator, object entity)
    {
        var context = new ValidationContext<object>(entity);
        var result = validator.Validate(context);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }
    }
}
