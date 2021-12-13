using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SportWebSite.Domain
{
    public class HandleExceptionsMiddleware
    {
        private readonly RequestDelegate _next;

        public HandleExceptionsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception e)
            {
                await HandleExceptionMessageAsync(context, e).ConfigureAwait(false);
            }
        }

        private static Task HandleExceptionMessageAsync(HttpContext context, Exception exception)
        {
            var logger = (ILogger<HandleExceptionsMiddleware>)context.RequestServices.GetService(typeof(ILogger<HandleExceptionsMiddleware>));

            context.Response.ContentType = "application/json";

            string error = $"Ошибка - {exception.Message}";
            logger.LogError(error);

            return context.Response.WriteAsync(error);
        }
    }
}