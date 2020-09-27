using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Implementations;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Interfaces;
using System;

namespace Schmidt.Softplan.TechnicalEvaluation.Mediator.Extensions
{
    public static class MediatorExtensions
    {
        public static IServiceCollection AddSchmidtMediator(this IServiceCollection serviceCollection,
                                                            params Type[] types)
        {
            serviceCollection.AddMediatR(types);
            serviceCollection.AddTransient<ISchmidtMediator, SchmidtMediator>();

            return serviceCollection;
        }
    }
}
