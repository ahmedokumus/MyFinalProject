namespace Core.Extensions.ResultsExtensions.Abstract;

internal abstract class SuccessResult : ResultBase
{
    protected SuccessResult(StatusCodes statusCode, string message) : base(true, statusCode, message)
    {
    }
}