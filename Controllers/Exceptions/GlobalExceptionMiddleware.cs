namespace Usuario.Exceptions;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    
    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(httpContext, e);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception e)
    {
        context.Response.ContentType = "application/json";

        context.Response.StatusCode = e switch
        {
            UserNotFoundException => StatusCodes.Status404NotFound
            
        };
        
        return context.Response.WriteAsJsonAsync(e.Message);
    }
}