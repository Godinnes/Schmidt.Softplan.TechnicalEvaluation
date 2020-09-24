using Schmidt.Softplan.TechnicalEvaluation.Common.Exception;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.DomainEventHandler.Abstraction.Responsavel
{
    public abstract class ResponsavelCFPUniqueValidationDomainEventHandler<TResponsavelDomainEvent> : DomainEventHandlerAsync<TResponsavelDomainEvent>
        where TResponsavelDomainEvent : IResponsavelDomainEvent
    {
        private readonly IResponsavelRepository _repository;
        public ResponsavelCFPUniqueValidationDomainEventHandler(IResponsavelRepository repository)
        {
            _repository = repository;
        }
        public async override Task HandleAsync(TResponsavelDomainEvent request)
        {
            if (_repository.ExistsCPF(request.Responsavel.ID, request.Responsavel.CPF))
                throw new ResponsavelCPFAlreadyExistsException();
        }
    }
}
