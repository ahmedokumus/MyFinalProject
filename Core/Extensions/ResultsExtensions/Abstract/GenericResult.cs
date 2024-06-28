namespace Core.Extensions.ResultsExtensions.Abstract;

public class GenericResult<T> : ResultBase
{
    public new T Data { get; set; }
    public GenericResult(bool success, StatusCodes statusCode, string message, T data) : base(success, statusCode, message)
    {
        Data = data;
    }
}