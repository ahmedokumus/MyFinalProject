using Core.Extensions.ResultsExtensions.Abstract;

namespace Core.Extensions.ResultsExtensions.Concrete;

internal sealed class Error : ErrorResult
{
    internal Error() : base(StatusCodes.False, default)
    {
    }
}