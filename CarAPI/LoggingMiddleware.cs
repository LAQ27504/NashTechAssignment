namespace CarAPI
{
    public class LoggingMiddleware
    {

        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            context.Request.EnableBuffering();

            using var reader = new StreamReader(context.Request.Body, leaveOpen: true);
            var body = await reader.ReadToEndAsync();

            // Reset the stream position so it can be read again later
            context.Request.Body.Position = 0;

            if (!int.TryParse(body, out int number))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Invalid number trontron");
                return;
            }
            Console.WriteLine("Logging Middleware: Received number: " + number);
            Console.WriteLine("Logging Middleware: Received body: " + body);
            Console.WriteLine("Logging Middleware: Request Path: " + context);
            await _next(context);
        }

    }

    public static class RequestCultureMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestCulture(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }

}