using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Extensions;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.Query.Responsaveis;
using Schmidt.Softplan.TechnicalEvaluation.Query.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Query.Data.Repository;
using TechTalk.SpecFlow;

namespace Schmidt.Softplan.TechnicalEvaluation.SpecFlow.Drivers
{
    public class QueryBase : ContextBase
    {
        public QueryBase(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSchmidtMediator(typeof(GetResponsaveisQueryHandler));

            serviceCollection.AddScoped<IQueryRepository, QueryRepository>();

            var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();

            serviceCollection.AddDbContext<SchmidtQueryContext>(options =>
            {
                options
                    .UseInMemoryDatabase("dbtest")
                    .UseInternalServiceProvider(serviceProvider);
            });

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
