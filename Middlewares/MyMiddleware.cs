using Logging.Services;

namespace Logging.Middlewares
{
    public class MyMiddleware : IMiddleware
    {
        public ILogger Logger;
        public MyMiddleware(ILogger<MyMiddleware> logger)
        {
            Logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            //this.Logger.LogWarning(9999, "InvokeAsync warn {}{}", "Hel", "lo World");
            //this.Logger.LogError(100, "InvokeAsync fail {}{}", "Hel", "lo World");

            this.Logger.Log(LogLevel.Trace, "LogLevel.Trace");
            this.Logger.Log(LogLevel.Debug, "LogLevel.Debug");
            this.Logger.Log(LogLevel.Information, "LogLevel.Information");
            this.Logger.Log(LogLevel.Warning, "LogLevel.Warning");
            this.Logger.Log(LogLevel.Error, "LogLevel.Error");
            this.Logger.Log(LogLevel.Critical, "LogLevel.Critical");
            this.Logger.Log(LogLevel.None, "LogLevel.None");        // nothing logged in console; in file?

            await next(context);
        }
    }
}
