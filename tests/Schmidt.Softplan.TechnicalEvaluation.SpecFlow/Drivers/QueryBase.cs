﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Extensions;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.Query.Responsaveis;
using Schmidt.Softplan.TechnicalEvaluation.Query.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Query.Data.Repository;
using Schmidt.Softplan.TechnicalEvaluation.Query.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Schmidt.Softplan.TechnicalEvaluation.SpecFlow.Drivers
{
    public class QueryBase : ContextBase
    {
        public QueryBase(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            var hierarchyRepositoryMock = new Mock<IProcessoHierarchyQueryRepository>();
            hierarchyRepositoryMock
                .Setup(a => a.ProcessosFamilyAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Guid id) =>
                {
                    var context = ServiceProvider.GetRequiredService<SchmidtQueryContext>();
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

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSchmidtMediator(typeof(GetResponsaveisQueryHandler));
            serviceCollection.AddScoped((a) => hierarchyRepositoryMock.Object);
            serviceCollection.AddScoped<IQueryRepository, QueryRepository>();

            var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();

            serviceCollection.AddDbContext<SchmidtQueryContext>(options =>
            {
                options
                    .UseInMemoryDatabase("dbteste")
                    .UseInternalServiceProvider(serviceProvider);
            });

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
