using GoldenHour.Application.Core;
using System.Net;
using System.Text.Json;

namespace GoldenHour.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                await _next(context);
            }
            catch(Exception e)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = new AppException(context.Response.StatusCode, e.Message);

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
