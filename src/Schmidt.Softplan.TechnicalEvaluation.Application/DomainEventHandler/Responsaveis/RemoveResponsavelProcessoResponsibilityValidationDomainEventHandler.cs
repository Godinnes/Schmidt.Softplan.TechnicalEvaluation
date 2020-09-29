using Schmidt.Softplan.TechnicalEvaluation.Common.Exception;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEvents.Responsaveis;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.DomainEventHandler.Responsaveis
{
    public class RemoveResponsavelProcessoResponsibilityValidationDomainEventHandler : DomainEventHandlerAsync<RemoveResponsavelDomainEvent>
    {
        private readonly IResponsavelRepository _repository;
        public RemoveResponsavelProcessoResponsibilityValidationDomainEventHandler(IResponsavelRepository repository)
        {
            _repository = repository;
        }
        public async override Task HandleAsync(RemoveResponsavelDomainEvent request)
        {
            if (await _repository.HasProcessoAsync(request.Responsavel.ID))
                throw new ResponsavelRemoveProcessoVinculedException();
        }
    }
}
