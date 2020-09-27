using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Schmidt.Softplan.TechnicalEvaluation.Application.Command.Processos;
using Schmidt.Softplan.TechnicalEvaluation.Application.DomainEventHandler.Responsaveis;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Data.Repository;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Services;
using Schmidt.Softplan.TechnicalEvaluation.ExceptionHandler.Extensions;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Extensions;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.Query.Processos;
using Schmidt.Softplan.TechnicalEvaluation.Query.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Query.Data.Repository;

namespace Schmidt.Softplan.TechnicalEvaluation.Bootstrap
{
    public static class BootstrapConfiguration
    {
        public static void AddApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddExceptionHandlerMiddleware();

            services.AddSchmidtMediator(typeof(CreateProcessoCommandHandler),
                                        typeof(GetProcessosQueryHandler),
                                        typeof(CreateResponsavelValidateCPFDomainEventHandler));

            var serviceColletion = new ServiceCollection()
                .AddEntityFrameworkSqlite()
                .BuildServiceProvider();
            services.AddDbContext<SchmidtContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString());
                options.UseInternalServiceProvider(serviceColletion);
            });
            services.AddDbContext<SchmidtQueryContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString());
                options.UseInternalServiceProvider(serviceColletion);
            });

            services.AddScoped<IProcessoRepository, ProcessoRepository>();
            services.AddScoped<IResponsavelRepository, ResponsavelRepository>();
            services.AddScoped<ISituacaoRepository, SituacaoRepository>();
            services.AddScoped<IQueryRepository, QueryRepository>();
            services.AddScoped<IDateTimeService, DateTimeService>();
        }
        private static string GetConnectionString(this IConfiguration configuration) => configuration["Database:ConnectionString"];
        public static void UseApi(this IApplicationBuilder app)
        {
            app.UseExceptionHandlerMiddleware();
        }
    }
}
