using Newtonsoft.Json;

namespace Core.Extensions.ExceptionExtension.Model;

public class ErrorDetails
{
    public string? Message { get; set; }
    public int StatusCode { get; set; }
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}