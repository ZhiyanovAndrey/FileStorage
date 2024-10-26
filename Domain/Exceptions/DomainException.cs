using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using System;

namespace FileStorage.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
        }
    }

    //private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    //{
    //    string result;

    //    if (ex is DomainException)
    //    {
    //        var problemDetails = new ValidationProblemDetails(new Dictionary<string, string[]> { { "Error", new[] { ex.Message } } })
    //        {
    //            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
    //            Title = "One or more validation errors occurred.",
    //            Status = (int)HttpStatusCode.BadRequest,
    //            Instance = context.Request.Path,
    //        };
    //        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    //        result = JsonSerializer.Serialize(problemDetails);
    //    }
        
    //else
    //    {
    //        _logger.LogError(ex, $"An unhandled exception has occurred, {ex.Message}");
    //        var problemDetails = new ProblemDetails
    //        {
    //            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
    //            Title = "Internal Server Error.",
    //            Status = (int)HttpStatusCode.InternalServerError,
    //            Instance = context.Request.Path,
    //            Detail = "Internal Server Error!"
    //        };
    //        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
    //        result = JsonSerializer.Serialize(problemDetails);
    //    }

    //    context.Response.ContentType = "application/json";
    //    await context.Response.WriteAsync(result);
    //}
}
