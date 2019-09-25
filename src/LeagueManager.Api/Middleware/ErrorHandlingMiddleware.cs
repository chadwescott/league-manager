using System;
using System.Threading.Tasks;

using LeagueManager.Business.Exceptions;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace LeagueManager.Api.Middleware
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
                await _next(httpContext).ConfigureAwait(false);
            }
            catch(Exception ex)
            {
                httpContext.Response.Clear();
                httpContext.Response.ContentType = "text/plain";

                if (ex is ArgumentException || ex is ArgumentNullException)
                {
                    httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                }
                else if (ex is ModelNotFoundException)
                {
                    httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                }
                else
                {
                    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                }
                await httpContext.Response.WriteAsync(ex.Message).ConfigureAwait(false);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
