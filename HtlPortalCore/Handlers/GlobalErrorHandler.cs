using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using HtlPortalCore.Models;

namespace HtlPortalCore.Handlers
{
    public class GlobalErrorHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalErrorHandler> _logger;

        public GlobalErrorHandler(RequestDelegate next, ILogger<GlobalErrorHandler> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception exception)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var statusCode = (int)HttpStatusCode.InternalServerError;

                switch (exception)
                {
                    case ArgumentException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    default:
                        statusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                _logger.LogError(exception, string.Empty);
                await SendError(response, $"{exception.GetType().Name}:{exception.Message}", statusCode);
            }
        }

        private static async Task SendError(HttpResponse response, string errorMessage, int statusCode)
        {
            response.StatusCode = statusCode;
            var errorJson = JsonSerializer.Serialize(new ResponseModel { StatusCode = statusCode, Message = errorMessage });
            await response.WriteAsync(errorJson);
        }
    }
}
