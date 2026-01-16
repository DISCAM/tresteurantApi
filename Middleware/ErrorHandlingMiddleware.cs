using Microsoft.AspNetCore.Http;
using restaurantAPI.Exceptions;

namespace restaurantAPI.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger )
        {
            _logger = logger;
        }


        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundExceptions notFoundExceptions)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundExceptions.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Unhandled exception. Path: {Path}", context.Request.Path);

                context.Response.StatusCode = 500;

                //if (context.RequestServices.GetRequiredService<IHostEnvironment>().IsDevelopment())
                //    await context.Response.WriteAsync(e.ToString());   // pełny stack trace
                //else
                await context.Response.WriteAsync("Coś jest nie tak");

            }

        }
    }
}
