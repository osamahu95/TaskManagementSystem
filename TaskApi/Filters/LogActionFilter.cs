using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace TaskApi.Filters
{
    public class LogActionFilter : IActionFilter
    {
        // When the action is executed
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine($"Action Executed: {context.ActionDescriptor.DisplayName}");
        }

        // When the action is executing
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine($"Action Executing: {context.ActionDescriptor.DisplayName}");
        }
    }
}
