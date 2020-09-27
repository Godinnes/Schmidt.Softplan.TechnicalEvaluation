using Schmidt.Softplan.TechnicalEvaluation.Common.Exception;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.DomainEventHandler.Abstraction.Processos
{
    public abstract class ProcessoNumeroProcessoUnificadoUniqueValidationDomainEventHandler<TProcessoDomainEvent> : DomainEventHandler<TProcessoDomainEvent>
        where TProcessoDomainEvent : IProcessoDomainEvent
    {
        private readonly IProcessoRepository _repository;
        public ProcessoNumeroProcessoUnificadoUniqueValidationDomainEventHandler(IProcessoRepository repository)
        {
            _repository = repository;
        }
        public override void Handle(TProcessoDomainEvent request)
        {
            var exists = _repository.HasNumeroProcessoUnificado(request.Processo.NumeroProcessoUnificado);
            if (exists)
                throw new ProcessoNumeroProcessoUnificadoAlreadyExistisException();
        }
    }
}
