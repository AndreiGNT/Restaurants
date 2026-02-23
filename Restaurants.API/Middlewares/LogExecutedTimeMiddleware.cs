using System.Diagnostics;

namespace Restaurants.API.Middlewares;

public class LogExecutedTimeMiddleware(ILogger<LogExecutedTimeMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var stopwatch = Stopwatch.StartNew();

        await next.Invoke(context);

        stopwatch.Stop();

        if (stopwatch.ElapsedMilliseconds / 1000 >= 0.5)
        {
            var verb = context.Request.Method;
            var path = context.Request.Path;

            var messageWarning = $"Warning Request: {verb} {path} took {stopwatch.Elapsed.TotalSeconds} seconds.";
            logger.LogWarning(messageWarning);
        }
    }
}
