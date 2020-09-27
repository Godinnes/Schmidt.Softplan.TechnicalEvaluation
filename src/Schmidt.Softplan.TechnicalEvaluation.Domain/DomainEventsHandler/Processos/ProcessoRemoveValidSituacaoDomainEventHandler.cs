using Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEvents.Processos;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEventsHandler.Processos
{
    public class ProcessoRemoveValidSituacaoDomainEventHandler : DomainEventHandler<RemoveProcessoDomainEvent>
    {
        public override void Handle(RemoveProcessoDomainEvent request)
        {
            request.Processo.CanModify();
        }
    }
}
