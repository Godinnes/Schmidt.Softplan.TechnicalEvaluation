using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Schmidt.Softplan.TechnicalEvaluation.Application.Command.Responsaveis;
using Schmidt.Softplan.TechnicalEvaluation.Application.DomainEventHandler.Responsaveis;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Data.Repository;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEventsHandler.Processos;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;
using Schmidt.Softplan.TechnicalEvaluation.EmailSender.Interface;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Extensions;
using System;
using System.Collections.Generic;
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

            var hierarchyRepositoryMock = new Mock<IProcessoHierarchyRepository>();
            hierarchyRepositoryMock
                .Setup(a => a.ProcessosFamilyAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Guid id) =>
                {
                    var context = ServiceProvider.GetRequiredService<SchmidtContext>();
                    var processosEntity = context.Set<Processo>().ToList();
                    var processoEntity = SearchGrandfather(processosEntity.First(a => a.ID == id), processosEntity);
                    return SearchChildren(processoEntity, processosEntity);

                    IEnumerable<Guid> SearchChildren(Processo processo, IEnumerable<Processo> processos)
                    {
                        var processosIDs = new List<Guid>();
                        processosIDs.Add(processo.ID);
                        foreach (var child in processos.Where(a => a.ProcessoPaiID == processo.ID))
                        {
                            processosIDs.AddRange(SearchChildren(child, processos));
                        }
                        return processosIDs;
                    }
                    Processo SearchGrandfather(Processo processo, IEnumerable<Processo> processos)
                    {
                        if (!processo.ProcessoPaiID.HasValue)
                            return processo;
                        return SearchGrandfather(processos.First(a => a.ID == processo.ProcessoPaiID.Value), processos);
                    }
                });

            serviceCollection.AddScoped<IProcessoRepository, ProcessoRepository>();
            serviceCollection.AddScoped<IResponsavelRepository, ResponsavelRepository>();
            serviceCollection.AddScoped<ISituacaoRepository, SituacaoRepository>();
            serviceCollection.AddScoped((a) => mockedDateTimeService.Object);
            serviceCollection.AddScoped((a) => mockedEmailSender.Object);
            serviceCollection.AddScoped((a) => hierarchyRepositoryMock.Object);

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
