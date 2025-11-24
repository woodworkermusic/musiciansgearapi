namespace MusiciansGearRegistry.Api.ExceptionHandling;

internal sealed class GlobalExceptionHandler(
    RequestDelegate next
    , ILogger<GlobalExceptionHandler> logger)
{

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Unhandled exception.");

            await context.Response.WriteAsync(e.Message);
        }
    }
}
