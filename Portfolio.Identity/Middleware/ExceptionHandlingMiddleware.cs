using Portfolio.Identity.Exceptions;
using System.Net;

namespace Portfolio.Identity.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
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
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "An unexpected error occurred.");
            ExceptionResponse response = exception switch
            {
                NotFoundByIdException _ => new ExceptionResponse(HttpStatusCode.NotFound, exception.Message ?? "Not Found By Id."),
                AlreadyExistException _ => new ExceptionResponse(HttpStatusCode.BadRequest, exception.Message ?? "Alredy Exist of Element"),
                CreateUserException _ => new ExceptionResponse(HttpStatusCode.BadRequest, exception.Message ?? "Couldn't create user"),
                SignInException _ => new ExceptionResponse(HttpStatusCode.BadRequest, exception.Message ?? "Couldn't log in check your username and password"),
                _ => new ExceptionResponse(HttpStatusCode.InternalServerError, exception.Message ?? "Internal server error. Please retry later.")
            };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)response.StatusCode;
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
