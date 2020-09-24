using Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEvents.Processos;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.DomainEventHandler.Processo
{
    public class ProcessoRemoveValidSituacaoDomainEventHandler : DomainEventHandlerAsync<RemoveProcessoDomainEvent>
    {
        public async override Task HandleAsync(RemoveProcessoDomainEvent request)
        {
            request.Processo.CanRemove();
        }
    }
}
