using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEvents;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using System;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.DomainEventHandler.Processo
{
    public class ProcessoUniqueCodigoProcessoUnificadoDomainEventHandler : DomainEventHandlerAsync<CreateProcessoDomainEvent>
    {
        private readonly IProcessoRepository _repository;
        public ProcessoUniqueCodigoProcessoUnificadoDomainEventHandler(IProcessoRepository repository)
        {
            _repository = repository;
        }
        public async override Task HandleAsync(CreateProcessoDomainEvent request)
        {
            var exists = _repository.HasNumeroProcessoUnificado(request.Processo.NumeroProcessoUnificado);
            if (exists)
                throw new Exception();
        }
    }
}
