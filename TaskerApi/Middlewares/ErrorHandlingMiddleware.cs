using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TaskerApi.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = Text.Plain;

            var message = "Internal Server error";
            var statusCode = StatusCodes.Status500InternalServerError;

            if (exception is BadHttpRequestException)
            {
                statusCode = StatusCodes.Status400BadRequest;
                message = exception.Message;
            }
            // other exception handling

            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsync(message);
        }

    }
}
