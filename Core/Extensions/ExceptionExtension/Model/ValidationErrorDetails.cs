using FluentValidation.Results;

namespace Core.Extensions.ExceptionExtension.Model;

public class ValidationErrorDetails : ErrorDetails
{
    public IEnumerable<ValidationFailure>? ValidationErrors { get; set; }
}