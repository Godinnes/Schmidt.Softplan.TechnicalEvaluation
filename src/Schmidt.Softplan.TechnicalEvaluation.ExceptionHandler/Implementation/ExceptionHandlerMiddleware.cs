using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Schmidt.Softplan.TechnicalEvaluation.ExceptionHandler.Abstraction;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.ExceptionHandler.Implementation
{
    internal class ExceptionHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (FriendlyException ex)
            {
                _logger.LogError($"Unexpected error: {ex.Message}");
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error: {ex.Message}");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var json = new
            {
                context.Response.StatusCode,
                Message = "An error occurred whilst processing your request",
                Detailed = exception
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(json));
        }
    }
}