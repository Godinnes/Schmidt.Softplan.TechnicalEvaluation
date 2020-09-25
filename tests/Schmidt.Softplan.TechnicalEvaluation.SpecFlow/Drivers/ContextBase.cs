using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Schmidt.Softplan.TechnicalEvaluation.Application.Command.Responsaveis;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Data.Repository;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Extensions;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.Query.Responsaveis;
using Schmidt.Softplan.TechnicalEvaluation.Query.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Query.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Schmidt.Softplan.TechnicalEvaluation.SpecFlow.Drivers
{
    public class ContextBase
    {
        protected readonly ScenarioContext ScenarioContext;
        public ContextBase(ScenarioContext scenarioContext)
        {
            ScenarioContext = scenarioContext;

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSchmidtMediator(typeof(CreateResponsavelCommandHandler),
                                                 typeof(GetResponsaveisQueryHandler));

            serviceCollection.AddScoped<IProcessoRepository, ProcessoRepository>();
            serviceCollection.AddScoped<IResponsavelRepository, ResponsavelRepository>();
            serviceCollection.AddScoped<ISituacaoRepository, SituacaoRepository>();
            serviceCollection.AddScoped<IQueryRepository, QueryRepository>();

            MemoryRoot = new InMemoryDatabaseRoot();

            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            serviceCollection.AddDbContext<SchmidtContext>(options =>
            {
                options.UseInMemoryDatabase("memory", MemoryRoot);
                options.UseInternalServiceProvider(serviceProvider);
            });
            serviceCollection.AddDbContext<SchmidtQueryContext>(options =>
            {
                options.UseInMemoryDatabase("memory", MemoryRoot);
                options.UseInternalServiceProvider(serviceProvider);
            });
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider
        {
            get { return ScenarioContext.Get<ServiceProvider>(nameof(ServiceProvider)); }
            set { ScenarioContext.Set(value, nameof(ServiceProvider)); }
        }
        public ISchmidtMediator Mediator => ServiceProvider.GetRequiredService<ISchmidtMediator>();
        public IEnumerable<Exception> ExpectedExceptions
        {
            get
            {
                if (ScenarioContext.TryGetValue<IEnumerable<Exception>>(nameof(ExpectedExceptions), out var expectedExceptions))
                    return expectedExceptions;
                return new List<Exception>();
            }
            set { ScenarioContext.Set(value, nameof(ExpectedExceptions)); }
        }
        public void AddException(Exception ex)
        {
            var exceptions = ExpectedExceptions.ToList();
            exceptions.Add(ex);
            ExpectedExceptions = exceptions;
        }
        public InMemoryDatabaseRoot MemoryRoot
        {
            get { return ScenarioContext.Get<InMemoryDatabaseRoot>(nameof(MemoryRoot)); }
            set { ScenarioContext.Set(value, nameof(MemoryRoot)); }
        }
    }
}
