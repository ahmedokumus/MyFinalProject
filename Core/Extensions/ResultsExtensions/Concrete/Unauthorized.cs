using Core.Extensions.ResultsExtensions.Abstract;
using Microsoft.AspNetCore.Http;

namespace Core.Extensions.ResultsExtensions.Concrete;

internal sealed class Unauthorized : ErrorResult
{
    internal Unauthorized(string message) : base(StatusCodes.Unauthorized, message)
    {

    }
    internal Unauthorized() : base(StatusCodes.Unauthorized, default!)
    {

    }
}