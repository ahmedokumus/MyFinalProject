using Newtonsoft.Json;

namespace Core.Extensions.ExceptionExtension.Model;

public class UnauthorizedErrorDetails
{
    public string? UnauthorizedError { get; set; }
    public int StatusCode { get; set; }
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}