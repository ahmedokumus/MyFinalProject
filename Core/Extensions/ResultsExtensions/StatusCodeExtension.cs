namespace Core.Extensions.ResultsExtensions;

public static class StatusCodeExtension
{
    public static bool IsSuccess(this StatusCodes statusCode) => (int)statusCode / 100 == 2 || (int)statusCode == 1;
}