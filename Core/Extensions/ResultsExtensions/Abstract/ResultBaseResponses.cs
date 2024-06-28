using Core.Extensions.ResultsExtensions.Concrete;

namespace Core.Extensions.ResultsExtensions.Abstract;

public class ResultBaseResponses
{
    public static ResultBase Ok() => new Ok();
    public static ResultBase Ok(string message) => new Ok(message);
    public static ResultBase Ok<T>(T data) => new GenericOK<T>(data);
    public static ResultBase Ok<T>(T data, string message) => new GenericOK<T>(data, message);
    public static ResultBase Created() => new Created();
    public static ResultBase Created(string message) => new Created(message);
    public static ResultBase Created<T>(T data) => new GenericCreated<T>(data);
    public static ResultBase Created<T>(T data, string message) => new GenericCreated<T>(data, message);
    public static ResultBase NoContent() => new NoContent();
    public static ResultBase NoContent(string message) => new NoContent(message);
    public static ResultBase BadRequest() => new BadRequest();
    public static ResultBase BadRequest(string message) => new BadRequest(message);
    public static ResultBase NotFound() => new NotFound();
    public static ResultBase NotFound(string message) => new NotFound(message);
    public static ResultBase Unauthorized() => new Unauthorized();
    public static ResultBase Unauthorized(string message) => new Unauthorized(message);
    internal static ResultBase InternalServerError() => new InternalServerError();
    internal static ResultBase InternalServerError(string message) => new InternalServerError(message);
}