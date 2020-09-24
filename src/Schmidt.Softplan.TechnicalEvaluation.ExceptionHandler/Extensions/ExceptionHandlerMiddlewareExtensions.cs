using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Schmidt.Softplan.TechnicalEvaluation.ExceptionHandler.Implementation;

namespace Schmidt.Softplan.TechnicalEvaluation.ExceptionHandler.Extensions
{
    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IServiceCollection AddExceptionHandlerMiddleware(this IServiceCollection services)
        {
            return services.AddTransient<ExceptionHandlerMiddleware>();
        }

        public static void UseExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
