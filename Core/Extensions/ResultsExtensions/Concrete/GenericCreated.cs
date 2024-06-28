using Core.Extensions.ResultsExtensions.Abstract;

namespace Core.Extensions.ResultsExtensions.Concrete;

internal sealed class GenericCreated<T> : GenericSuccessResult<T>
{
    internal GenericCreated(T data, string message) : base(StatusCodes.Created, data, message)
    {
    }
    internal GenericCreated(T data) : base(StatusCodes.Created, data, default)
    {
    }
}