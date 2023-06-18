using Microsoft.AspNetCore.Http;
using System.Net;
using FluentValidation;
using FluentValidation.Results;
using Core.Extensions.ExceptionExtension.Model;

namespace Core.Extensions.ExceptionExtension;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(httpContext, exception);
        }
    }

    private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        string message = "Internal Server Error";

        switch (exception)
        {
            case ValidationException ex:

                message = exception.Message;
                IEnumerable<ValidationFailure> errors = ex.Errors;
                httpContext.Response.StatusCode = 400;
                return httpContext.Response.WriteAsync(new ValidationErrorDetails
                {
                    StatusCode = 400,
                    Message = message,
                    ValidationErrors = errors
                }.ToString());

            case UnauthorizedException:

                message = exception.Message;
                httpContext.Response.StatusCode = 401;
                return httpContext.Response.WriteAsync(new UnauthorizedErrorDetails
                {
                    StatusCode = 401,
                    UnauthorizedError = message,
                }.ToString());

            default:

                return httpContext.Response.WriteAsync(new ErrorDetails
                {
                    StatusCode = httpContext.Response.StatusCode,
                    Message = message
                }.ToString());
        }

        //if (e.GetType() == typeof(UnauthorizedException))
        //{
        //    message = e.Message;
        //    httpContext.Response.StatusCode = 401;

        //    return httpContext.Response.WriteAsync(new UnauthorizedErrorDetails
        //    {
        //        StatusCode = 401,
        //        Message = message,
        //    }.ToString());
        //}

        //if (e.GetType() == typeof(ValidationException))
        //{
        //    message = e.Message;
        //    IEnumerable<ValidationFailure> errors = ((ValidationException)e).Errors;
        //    httpContext.Response.StatusCode = 400;

        //    return httpContext.Response.WriteAsync(new ValidationErrorDetails
        //    {
        //        StatusCode = 400,
        //        Message = message,
        //        validationErrors = errors
        //    }.ToString());
        //}

        //return httpContext.Response.WriteAsync(new ErrorDetails
        //{
        //    StatusCode = httpContext.Response.StatusCode,
        //    Message = message
        //}.ToString());
    }
}