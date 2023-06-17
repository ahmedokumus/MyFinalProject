using System.Globalization;

namespace Core.Extensions;

public class UnauthorizedException : Exception
{
    public UnauthorizedException() : base()
    {
        
    }
    public UnauthorizedException(string errorMessage) : base(errorMessage)
    {
        
    }

    public UnauthorizedException(string message, params object[] args)
        : base(String.Format(CultureInfo.CurrentCulture, message, args))
    {
    }
}