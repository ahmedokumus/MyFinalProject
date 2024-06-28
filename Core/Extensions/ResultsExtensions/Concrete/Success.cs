using Core.Extensions.ResultsExtensions.Abstract;

namespace Core.Extensions.ResultsExtensions.Concrete;

internal sealed class Success : SuccessResult
{
    internal Success() : base(StatusCodes.True, default)
    {
    }
}