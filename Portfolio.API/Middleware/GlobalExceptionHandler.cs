using AutoMapper;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Minio.Exceptions;
using Portfolio.Application.Exceptions;
using System.Diagnostics;
using System.Net;

namespace Portfolio.API.Middleware
{
    internal sealed class GlobalExceptionHandler(IProblemDetailsService problemDetailsService) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            httpContext.Response.StatusCode = exception switch
            {
                NotFoundByIdException => StatusCodes.Status404NotFound,
                AlreadyExistException _ => StatusCodes.Status400BadRequest,
                UnauthorizedAccessException _ => StatusCodes.Status401Unauthorized,
                AutoMapperMappingException _ => StatusCodes.Status500InternalServerError,
                HttpRequestException => StatusCodes.Status502BadGateway,
                MinioException => StatusCodes.Status502BadGateway,
                _ => StatusCodes.Status500InternalServerError
            };
            return await problemDetailsService.TryWriteAsync(new ProblemDetailsContext
            {
                HttpContext = httpContext,
                Exception = exception,
                ProblemDetails = new ProblemDetails
                {
                    Type = exception.GetType().Name,
                    Title = "An error occured",
                    Detail = exception.Message
                }
            });
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            ExceptionResponse response = exception switch
            {
                NotFoundByIdException _ => new ExceptionResponse(HttpStatusCode.NotFound, "Not Found By Id."),
                AlreadyExistException _ => new ExceptionResponse(HttpStatusCode.BadRequest, "Alredy Exist of Element"),
                UnauthorizedAccessException _ => new ExceptionResponse(HttpStatusCode.Unauthorized, "Unauthorized."),
                AutoMapperMappingException _ => new ExceptionResponse(HttpStatusCode.InternalServerError, "Automapper mapping error"),
                HttpRequestException => new ExceptionResponse(HttpStatusCode.BadGateway, "Storage is unavailable"),
                MinioException => new ExceptionResponse(HttpStatusCode.BadGateway, "MinIO error"),
                _ => new ExceptionResponse(HttpStatusCode.InternalServerError, "Internal server error. Please retry later.")
            };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)response.StatusCode;
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
