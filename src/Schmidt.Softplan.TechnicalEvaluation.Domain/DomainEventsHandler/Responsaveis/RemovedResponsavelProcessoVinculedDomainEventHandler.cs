using Schmidt.Softplan.TechnicalEvaluation.Common.Exception;
using Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEvents.Responsaveis;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using System.Linq;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEventsHandler.Responsaveis
{
    public class RemovedResponsavelProcessoVinculedDomainEventHandler : DomainEventHandler<RemoveResponsavelDomainEvent>
    {
        public override void Handle(RemoveResponsavelDomainEvent request)
        {
            if (request.Responsavel.ProcessoResponsaveis.Any())
                throw new ResponsavelRemoveProcessoVinculedException();
        }
    }
}
