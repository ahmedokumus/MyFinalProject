using Core.Extensions.ResultsExtensions.Abstract;

namespace Core.Extensions.ResultsExtensions.Concrete;

internal sealed class Ok : SuccessResult
{
    internal Ok(string message) : base(StatusCodes.OK, message)
    {
    }
    internal Ok() : base(StatusCodes.OK, default)
    {
    }
}