﻿using FileStorage.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace FileStorage.Infrastructure.Middlewares
{
    public class ApiExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ApiExceptionHandlingMiddleware> _logger;

        public ApiExceptionHandlingMiddleware(RequestDelegate next, ILogger<ApiExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        // усли Domane

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            string result;

            if (ex is DomainException)
            {
                var problemDetails = new ValidationProblemDetails(new Dictionary<string, string[]> { { "Error", new[] { ex.Message } } })
                {
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                    Title = "One or more validation errors occurred.",
                    Status = (int)HttpStatusCode.BadRequest,
                    Instance = context.Request.Path,
                };
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(problemDetails);
            }
            
    else
            {
                _logger.LogError(ex, $"An unhandled exception has occurred, {ex.Message}");
                var problemDetails = new ProblemDetails
                {
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                    Title = "Internal Server Error.",
                    Status = (int)HttpStatusCode.InternalServerError,
                    Instance = context.Request.Path,
                    Detail = "Internal Server Error!!!!!!!"
                };
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                result = JsonSerializer.Serialize(problemDetails);
            }

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);
        }




        //private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        //{
        //    _logger.LogError(ex, $"An unhandled exception has occurred, {ex.Message}");

        //    var problemDetails = new ProblemDetails
        //    {
        //        Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
        //        Title = "Internal Server Error",
        //        Status = (int)HttpStatusCode.InternalServerError,
        //        Instance = context.Request.Path,
        //        Detail = "Internal server error occured!"
        //    };

        //    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        //    var result = JsonSerializer.Serialize(problemDetails);

        //    context.Response.ContentType = "application/json";
        //    await context.Response.WriteAsync(result);
        //}

        /*Помимо установки кода состояния ответа 500 context.Response.StatusCode = (int)HttpStatusCode.InternalServerError 
         * в теле ответа существует сообщение в формате ProblemDetails.*/

    }

}
