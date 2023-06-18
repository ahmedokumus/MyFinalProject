using System.Globalization;

namespace Core.Extensions.ExceptionExtension;

public class UnauthorizedException : Exception
{
    public UnauthorizedException() { }
    public UnauthorizedException(string errorMessage) : base(errorMessage) { }

    public UnauthorizedException(string message, params object[] args)
        : base(string.Format(CultureInfo.CurrentCulture, message, args))
    {
        HelpLink = "https://www.hataYardim.com";
        Source = "Business_BusinessAspects_Autofac_SecuredOperation";
    }
}