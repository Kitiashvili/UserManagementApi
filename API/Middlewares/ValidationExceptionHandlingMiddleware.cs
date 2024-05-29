using Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace API.Middlewares;

public sealed class ValidationExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ValidationExceptionHandlingMiddleware> _logger;
    
    public ValidationExceptionHandlingMiddleware(RequestDelegate next,
        ILogger<ValidationExceptionHandlingMiddleware> logger)
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
        catch (CustomValidationException exception)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "ValidationFailure",
            };

            if (exception.ValidationErrors is not null)
            {
                problemDetails.Extensions["errors"] = exception.ValidationErrors;
            }

            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            
            _logger.LogError(problemDetails.ToString());
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}