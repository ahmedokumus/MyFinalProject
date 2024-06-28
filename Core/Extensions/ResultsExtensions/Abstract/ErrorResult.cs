namespace Core.Extensions.ResultsExtensions.Abstract;

internal abstract class ErrorResult : ResultBase
{
    protected ErrorResult(StatusCodes statusCode, string message) : base(false, statusCode, message)
    {
    }
}