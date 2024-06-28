using Core.Extensions.ResultsExtensions.Abstract;

namespace Core.Extensions.ResultsExtensions.Concrete;

internal class InternalServerError : ErrorResult
{
    internal InternalServerError(string message) : base(StatusCodes.InternalServerError, message)
    {
    }
    internal InternalServerError() : base(StatusCodes.InternalServerError, default!)
    {
    }
}