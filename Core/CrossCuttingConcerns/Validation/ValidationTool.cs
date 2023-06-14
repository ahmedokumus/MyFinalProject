using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation;

public static class ValidationTool
{
    public static void Validate(IValidator validator, object entity)
    {
        var context = new ValidationContext<object>(entity); //1
        var result = validator.Validate(context); //2 numarada ki kuralları doğrulamak için 1 numaradaki contexti kullan
        if (!result.IsValid) //result geçerli değilse hata fırlat
        {
            throw new FluentValidation.ValidationException(result.Errors.ToList());
        }
    }
}