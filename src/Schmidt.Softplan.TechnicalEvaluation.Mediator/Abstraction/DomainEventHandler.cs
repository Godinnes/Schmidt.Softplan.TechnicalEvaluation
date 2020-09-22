using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction
{
    internal interface IDomainEventHandlerAsync<in TCommand> : IRequestHandler<TCommand, Unit>
        where TCommand : IRequest
    {
        Task HandleAsync(TCommand request);
    }
    public abstract class DomainEventHandlerAsync<TRequest>
        : IDomainEventHandlerAsync<TRequest>, IDomainEvent
        where TRequest : IDomainEvent
    {
        public async Task<Unit> Handle(TRequest request, CancellationToken cancellationToken)
        {
            await HandleAsync(request);
            return await Unit.Task;
        }

        public abstract Task HandleAsync(TRequest request);
    }
}
