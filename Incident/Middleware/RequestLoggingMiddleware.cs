using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace Incident.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _logFilePath = "logs/requests.log";

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            await _next(context);

            stopwatch.Stop();

            var log = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | " +
                      $"Method: {context.Request.Method} | " +
                      $"Path: {context.Request.Path} | " +
                      $"Status: {context.Response.StatusCode} | " +
                      $"Time: {stopwatch.ElapsedMilliseconds} ms";

            Directory.CreateDirectory("logs");
            await File.AppendAllTextAsync(_logFilePath, log + Environment.NewLine);
        }
    }
}

