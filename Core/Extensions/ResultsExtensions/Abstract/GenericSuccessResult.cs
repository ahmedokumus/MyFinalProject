namespace Core.Extensions.ResultsExtensions.Abstract;

internal abstract class GenericSuccessResult<T> : GenericResult<T>
{
    protected GenericSuccessResult(StatusCodes statusCode, T data, string message) : base(true, statusCode, message, data)
    {
    }
}