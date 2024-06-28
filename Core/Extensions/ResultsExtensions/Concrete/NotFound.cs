using Core.Extensions.ResultsExtensions.Abstract;

namespace Core.Extensions.ResultsExtensions.Concrete;

internal sealed class NotFound : ErrorResult
{
    internal NotFound(string message) : base(StatusCodes.NotFound, message)
    {

    }
    internal NotFound() : base(StatusCodes.NotFound, default!)
    {

    }
}