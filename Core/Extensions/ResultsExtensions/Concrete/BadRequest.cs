using Core.Extensions.ResultsExtensions.Abstract;

namespace Core.Extensions.ResultsExtensions.Concrete;

internal sealed class BadRequest : ErrorResult
{
    internal BadRequest(string message) : base(StatusCodes.BadRequest, message)
    {
    }
    internal BadRequest() : base(StatusCodes.BadRequest, default!)
    {
    }
}