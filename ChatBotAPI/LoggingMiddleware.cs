namespace ChatBotAPI
{
    public class LoggingMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly string _logFilePath = "logs.txt";

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {


            context.Request.EnableBuffering();

            string body = string.Empty;
            using (var reader = new StreamReader(context.Request.Body, leaveOpen: true))
            {
                body = await reader.ReadToEndAsync();
                context.Request.Body.Position = 0;
            }

            var logEntry = $"Timestamp: {DateTime.UtcNow}\n" +
                           $"Schema: {context.Request.Scheme}\n" +
                           $"Host: {context.Request.Host}\n" +
                           $"Path: {context.Request.Path}\n" +
                           $"QueryString: {context.Request.QueryString}\n" +
                           $"RequestBody: {body}\n\n";

            await File.AppendAllTextAsync(_logFilePath, logEntry);

            Console.WriteLine("Logging Middleware: Schema: " + context.Request.Scheme);
            Console.WriteLine("Logging Middleware: Host: " + context.Request.Host);
            Console.WriteLine("Logging Middleware: Path: " + context.Request.Path);
            Console.WriteLine("Logging Middleware: QueryString: " + context.Request.QueryString);
            Console.WriteLine("Logging Middleware: RequestBody: " + body);

            await _next(context);
        }


    }


}