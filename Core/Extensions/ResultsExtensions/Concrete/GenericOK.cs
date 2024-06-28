using Core.Extensions.ResultsExtensions.Abstract;

namespace Core.Extensions.ResultsExtensions.Concrete;

internal sealed class GenericOK<T> : GenericSuccessResult<T>
{
    internal GenericOK(T data, string message) : base(StatusCodes.OK, data, message)
    {
    }
    internal GenericOK(T data) : base(StatusCodes.OK, data, default)
    {
    }
}