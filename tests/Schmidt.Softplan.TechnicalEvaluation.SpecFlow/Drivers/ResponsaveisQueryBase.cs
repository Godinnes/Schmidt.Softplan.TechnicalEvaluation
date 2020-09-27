using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Extensions;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.Query.Responsaveis;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.ViewModel;
using Schmidt.Softplan.TechnicalEvaluation.Query.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Query.Data.Repository;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Schmidt.Softplan.TechnicalEvaluation.SpecFlow.Drivers
{
    public class ResponsaveisQueryBase : ContextBase
    {
        public ResponsaveisQueryBase(ScenarioContext scenarioContext)
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
        public IEnumerable<ResponsavelQueryViewModel> Responsaveis
        {
            get { return ScenarioContext.Get<IEnumerable<ResponsavelQueryViewModel>>(nameof(Responsaveis)); }
            set { ScenarioContext.Set(value, nameof(Responsaveis)); }
        }
        public Guid ResponsavelID
        {
            get { return ScenarioContext.Get<Guid>(nameof(ResponsavelID)); }
            set { ScenarioContext.Set(value, nameof(ResponsavelID)); }
        }
    }
}
