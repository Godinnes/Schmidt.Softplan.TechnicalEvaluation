using MediatR;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Mediator.Interfaces
{
    public interface IDomainEventHandlerAsync<in TDomainEvent> : INotificationHandler<TDomainEvent>
        where TDomainEvent : INotification
    {
        Task HandleAsync(TDomainEvent request);
    }
    public interface IDomainEventHandler<in TDomainEvent> : INotificationHandler<TDomainEvent>
        where TDomainEvent : INotification
    {
        void Handle(TDomainEvent request);
    }
}
