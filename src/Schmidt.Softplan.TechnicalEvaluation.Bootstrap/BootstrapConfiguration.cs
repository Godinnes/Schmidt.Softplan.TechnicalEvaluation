using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Schmidt.Softplan.TechnicalEvaluation.Application.Command.Processos;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Data.Repository;
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
            services.AddSchmidtMediator(typeof(CreateProcessoCommandHandler),
                                        typeof(GetProcessosQueryHandler));

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
            services.AddScoped<IQueryRepository, QueryRepository>();
        }
        private static string GetConnectionString(this IConfiguration configuration) => configuration["Database:ConnectionString"];
    }
}
