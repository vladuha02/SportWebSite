using Microsoft.AspNetCore.Builder;
using SportWebSite.Domain;

namespace SportWebSite.Extensions
{
    public static class HandleExceptionsMiddlewareExtension
    {
        public static void UseHandleExceptionsMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<HandleExceptionsMiddleware>();
        }
    }
}