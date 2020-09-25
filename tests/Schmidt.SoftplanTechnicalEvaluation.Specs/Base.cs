using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Schmidt.Softplan.TechnicalEvaluation.Application.Command.Responsaveis;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Data.Repository;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Extensions;
using TechTalk.SpecFlow;

namespace Schmidt.SoftplanTechnicalEvaluation.Specs
{
    public class Base
    {
        protected readonly ScenarioContext ScenarioContext;
        public Base(ScenarioContext scenarioContext)
        {
            ScenarioContext = scenarioContext;

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSchmidtMediator(typeof(CreateResponsavelCommandHandler));

            serviceCollection.AddScoped<IProcessoRepository, ProcessoRepository>();
            serviceCollection.AddScoped<IResponsavelRepository, ResponsavelRepository>();
            serviceCollection.AddScoped<ISituacaoRepository, SituacaoRepository>();

            Connection = new SqliteConnection("Database=:memory:");
            var internalService = new ServiceCollection();
            internalService.AddEntityFrameworkSqlite();
            internalService.BuildServiceProvider();

            serviceCollection.AddDbContext<SchmidtContext>(options =>
            {
                options.UseSqlite(Connection);
                options.UseInternalServiceProvider(internalService.BuildServiceProvider());
            });
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
        public SqliteConnection Connection
        {
            get { return ScenarioContext.Get<SqliteConnection>(nameof(Connection)); }
            set { ScenarioContext.Set(value, nameof(Connection)); }
        }

        public ServiceProvider ServiceProvider
        {
            get { return ScenarioContext.Get<ServiceProvider>(nameof(ServiceProvider)); }
            set { ScenarioContext.Set(value, nameof(ServiceProvider)); }
        }

        public ISchmidtMediator Mediator => ServiceProvider.GetRequiredService<ISchmidtMediator>();

    }
}
