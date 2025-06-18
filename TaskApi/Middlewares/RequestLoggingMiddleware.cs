using System.Diagnostics;

namespace TaskApi.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Debug.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
            await _next(context); // call the next middleware in queue in pipeline
        }
    }
}
