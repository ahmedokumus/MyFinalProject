using Core.Extensions.ResultsExtensions.Abstract;

namespace Core.Extensions.ResultsExtensions.Concrete;

internal sealed class NoContent : SuccessResult
{
    internal NoContent(string message) : base(StatusCodes.NoContent, message)
    {
    }
    internal NoContent() : base(StatusCodes.NoContent, default!)
    {
    }
}