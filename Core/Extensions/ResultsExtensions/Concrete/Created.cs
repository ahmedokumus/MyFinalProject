using Core.Extensions.ResultsExtensions.Abstract;

namespace Core.Extensions.ResultsExtensions.Concrete;

sealed class Created : SuccessResult
{
    internal Created(string message) : base(StatusCodes.Created, message)
    {
    }

    internal Created() : base(StatusCodes.Created, default!)
    {
    }
}