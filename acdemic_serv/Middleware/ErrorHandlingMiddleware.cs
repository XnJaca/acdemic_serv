using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace acdemic_serv.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
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

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            // Loguea la excepción
            var loggerFactory = context.RequestServices.GetService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger<ErrorHandlingMiddleware>();
            logger.LogError(ex, "Unhandled exception occurred while processing the request.");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = new
            {
                StatusCode = context.Response.StatusCode,
                Status = false,
                Message = "An unexpected error occurred. Please try again later.",
                Detail = "Internal Server Error"
            };

            return context.Response.WriteAsJsonAsync(result);
        }
    }
}