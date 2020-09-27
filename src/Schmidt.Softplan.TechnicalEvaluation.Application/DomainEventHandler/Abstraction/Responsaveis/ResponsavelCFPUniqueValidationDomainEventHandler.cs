using Schmidt.Softplan.TechnicalEvaluation.Common.Exception;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.DomainEventHandler.Abstraction.Responsaveis
{
    public abstract class ResponsavelCFPUniqueValidationDomainEventHandler<TResponsavelDomainEvent> : DomainEventHandler<TResponsavelDomainEvent>
        where TResponsavelDomainEvent : IResponsavelDomainEvent
    {
        private readonly IResponsavelRepository _repository;
        public ResponsavelCFPUniqueValidationDomainEventHandler(IResponsavelRepository repository)
        {
            _repository = repository;
        }
        public override void Handle(TResponsavelDomainEvent request)
        {
            if (_repository.ExistsCPF(request.Responsavel.ID, request.Responsavel.CPF))
                throw new ResponsavelCPFAlreadyExistsException();
        }
    }
}
