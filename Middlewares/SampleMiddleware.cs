namespace Logging.Middlewares
{
    public class SampleMiddleware: IMiddleware
    {
        public ILogger Logger { get; set; }
        public SampleMiddleware(ILogger<SampleMiddleware> logger)
        {
            Logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            this.Logger.LogInformation("InvokeAsync SampleMiddleware");
            await next(context);
        }
    }
}
