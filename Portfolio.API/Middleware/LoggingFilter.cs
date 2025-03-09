using Microsoft.AspNetCore.Mvc.Filters;

namespace Portfolio.API.Middleware
{
    public class LoggingFilter(ILogger<LoggingFilter> logger) : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var request = context.HttpContext.Request;
            logger.LogInformation($"Received request: {request.Method} {request.Path}");
            await next();
        }
    }
}
