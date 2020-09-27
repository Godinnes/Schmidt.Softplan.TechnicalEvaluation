using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Schmidt.Softplan.TechnicalEvaluation.Application.Command.Responsaveis;
using Schmidt.Softplan.TechnicalEvaluation.Application.DomainEventHandler.Responsaveis;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Data.Repository;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Extensions;
using System;
using TechTalk.SpecFlow;

namespace Schmidt.Softplan.TechnicalEvaluation.SpecFlow.Drivers
{
    public class CommandBase : ContextBase
    {
        public CommandBase(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSchmidtMediator(typeof(CreateResponsavelCommandHandler),
                                                 typeof(ChangeResponsavelCPFValidationDomainEventHandler));

            var mockedDateTimeService = new Mock<IDateTimeService>();
            mockedDateTimeService
                .Setup(a => a.CurrentDateTime)
                .Returns(new DateTime(2020, 9, 27));

            serviceCollection.AddScoped<IProcessoRepository, ProcessoRepository>();
            serviceCollection.AddScoped<IResponsavelRepository, ResponsavelRepository>();
            serviceCollection.AddScoped<ISituacaoRepository, SituacaoRepository>();
            serviceCollection.AddScoped((a) => mockedDateTimeService.Object);

            var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();

            serviceCollection.AddDbContext<SchmidtContext>(options =>
            {
                options
                    .UseInMemoryDatabase("dbtest")
                    .UseInternalServiceProvider(serviceProvider);
            });

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
