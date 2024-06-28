using Core.Extensions.ResultsExtensions.Concrete;

namespace Core.Extensions.ResultsExtensions.Abstract;

public abstract class ResultBase : IResultBase
{
    public bool Success { get; set; }
    public StatusCodes StatusCode { get; set; }
    public object? Data { get; set; }
    public string Message { get; set; }

    protected ResultBase(bool success, StatusCodes statusCode, string message)
    {
        if (statusCode.IsSuccess() != success)
            throw new Exception("Wrong status code");
        Success = success;
        StatusCode = statusCode;
        Message = message;
    }

    public static implicit operator bool(ResultBase result) => result.Success;
    public static bool operator true(ResultBase result) => result;
    public static bool operator false(ResultBase result) => !result;
    public static ResultBase operator &(ResultBase left, ResultBase right) => right ? new Success() : right;
    public static ResultBase operator |(ResultBase left, ResultBase right) => right ? right : new Error();

    public override string ToString()
    {
        return $"{Success}({StatusCode}): {Message}";
    }
}