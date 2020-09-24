using Schmidt.Softplan.TechnicalEvaluation.Common.Exception;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.DomainEventHandler.Abstraction.Processo
{
    public abstract class ProcessoNumeroProcessoUnificadoUniqueValidationDomainEventHandler<TProcessoDomainEvent> : DomainEventHandlerAsync<TProcessoDomainEvent>
        where TProcessoDomainEvent : IProcessoDomainEvent
    {
        private readonly IProcessoRepository _repository;
        public ProcessoNumeroProcessoUnificadoUniqueValidationDomainEventHandler(IProcessoRepository repository)
        {
            _repository = repository;
        }
        public async override Task HandleAsync(TProcessoDomainEvent request)
        {
            var exists = _repository.HasNumeroProcessoUnificado(request.Processo.NumeroProcessoUnificado);
            if (exists)
                throw new ProcessoNumeroProcessoUnificadoAlreadyExistisException();
        }
    }
}
