using Schmidt.Softplan.TechnicalEvaluation.Application.DomainEventHandler.Abstraction.Processos;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEvents.Processos;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.DomainEventHandler.Processos
{
    public class ProcessoChangedUniqueCodigoProcessoUnificadoDomainEventHandler : ProcessoNumeroProcessoUnificadoUniqueValidationDomainEventHandler<ChangeProcessoDomainEvent>
    {
        public ProcessoChangedUniqueCodigoProcessoUnificadoDomainEventHandler(IProcessoRepository repository)
            : base(repository)
        {
        }
    }
}