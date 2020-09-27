using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Schmidt.Softplan.TechnicalEvaluation.Application.Command.Responsaveis;
using Schmidt.Softplan.TechnicalEvaluation.Application.DomainEventHandler.Responsaveis;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Data.Repository;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEventsHandler.Processos;
using Schmidt.Softplan.TechnicalEvaluation.EmailSender.Interface;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Extensions;
using System;
using System.Linq;
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
                                                 typeof(ChangeResponsavelCPFValidationDomainEventHandler),
                                                 typeof(ProcessoChangedDataDistribuicaoValidationDomainEventHandler));

            var mockedDateTimeService = new Mock<IDateTimeService>();
            mockedDateTimeService
                .Setup(a => a.CurrentDateTime)
                .Returns(new DateTime(2020, 9, 27));

            var mockedEmailSender = new Mock<IMailSender>();
            mockedEmailSender
                .Setup(a => a.Send(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>()))
                .Callback((string title, string message, string[] emails) =>
                {
                    NumberEmailSended = emails.Count();
                });

            serviceCollection.AddScoped<IProcessoRepository, ProcessoRepository>();
            serviceCollection.AddScoped<IResponsavelRepository, ResponsavelRepository>();
            serviceCollection.AddScoped<ISituacaoRepository, SituacaoRepository>();
            serviceCollection.AddScoped((a) => mockedDateTimeService.Object);
            serviceCollection.AddScoped((a) => mockedEmailSender.Object);

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
