using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApplication1_feb16
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public CustomMiddleware(RequestDelegate next, LoggerFactory loggerfactory)
        {
            _next = next;
            _logger = loggerfactory.CreateLogger("my middleware");
        }

        public async Task Invoke(HttpContext httpContext)
        {
            // _logger.CreateLogger<CustomMiddleware>();
           // await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}
