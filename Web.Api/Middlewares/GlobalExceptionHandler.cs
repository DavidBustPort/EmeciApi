using Application.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Web.Api.Middlewares
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var (statusCode, message) = exception switch
            {
                ValidationException ex => (ex.StatusCode, ex.Message),
                UnauthorizedAccessException => (StatusCodes.Status401Unauthorized, "No autorizado"),
                _ => (StatusCodes.Status500InternalServerError, "Ocurrió un error interno en el servidor")
            };

            var response = new
            {
                StatusCode = statusCode,
                Message = message,
                Type = exception.GetType().Name
            };

            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            return true;
        }
    }
}
