using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace TaskApi.Filters
{
    public class TimeLoggingFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var stopWatch = context.HttpContext.Items["StopWatch"] as Stopwatch;
            if (stopWatch != null)
            {
                stopWatch.Stop();
                Debug.WriteLine($"Request Completed: {context.HttpContext.Request.Path} - Duration: {stopWatch.ElapsedMilliseconds} ms");
            }
            else
            {
                Debug.WriteLine($"Request Completed: {context.HttpContext.Request.Path} - No stopwatch found.");
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var stopWatch = Stopwatch.StartNew();
            context.HttpContext.Items["StopWatch"] = stopWatch;
            Debug.WriteLine($"Request Started: {context.HttpContext.Request.Path}");
        }
    }
}
