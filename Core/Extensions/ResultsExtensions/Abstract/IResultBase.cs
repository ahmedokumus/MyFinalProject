using System.Text.Json.Serialization;

namespace Core.Extensions.ResultsExtensions.Abstract;

public interface IResultBase
{
    public bool Success { get; protected set; }
    [JsonIgnore]
    public StatusCodes StatusCode { get; protected set; }
    public object? Data { get; set; }
    public string Message { get; protected set; }
}