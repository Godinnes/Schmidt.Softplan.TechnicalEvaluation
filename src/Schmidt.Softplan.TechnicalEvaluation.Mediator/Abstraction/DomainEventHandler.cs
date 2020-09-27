using Schmidt.Softplan.TechnicalEvaluation.Mediator.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction
{
    public abstract class DomainEventHandlerAsync<TDomainEvent>
        : IDomainEventHandlerAsync<TDomainEvent>, IDomainEvent
        where TDomainEvent : IDomainEvent
    {
        public async Task Handle(TDomainEvent notification, CancellationToken cancellationToken)
        {
            await HandleAsync(notification);
        }

        public abstract Task HandleAsync(TDomainEvent request);
    }
    public abstract class DomainEventHandler<TDomainEvent>
        : IDomainEventHandler<TDomainEvent>, IDomainEvent
        where TDomainEvent : IDomainEvent
    {
        public Task Handle(TDomainEvent notification, CancellationToken cancellationToken)
        {
            Handle(notification);
            return Task.CompletedTask;
        }

        public abstract void Handle(TDomainEvent request);
    }
}
