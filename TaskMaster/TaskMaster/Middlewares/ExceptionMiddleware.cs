using System.ComponentModel.DataAnnotations;
using TaskMaster.Exceptions;

namespace TaskMaster.Middlewares;
public class ExceptionMiddleware
{
    private readonly RequestDelegate _requestDelegate;

    public ExceptionMiddleware(RequestDelegate requestDelegate)
    {
        _requestDelegate = requestDelegate;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _requestDelegate(context);
        }
        catch (Exception ex)
        {
            var statusCode = ex switch
            {
                TaskNotFoundException => StatusCodes.Status404NotFound,
                ValidationException => StatusCodes.Status400BadRequest,
                UserAlreadyExistsException => StatusCodes.Status409Conflict,
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };

            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsJsonAsync(new
            {
                status = statusCode,
                message = ex.Message
            });
        }
    }
}
