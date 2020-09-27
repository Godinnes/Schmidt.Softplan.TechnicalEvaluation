using Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEvents.Processos;
using Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEventsHandler.Abstraction.Processos;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEventsHandler.Processos
{
    public class ProcessoChangedDataDistribuicaoValidationDomainEventHandler : ProcessosDataDistribuicaoValidationDomainEventHandler<CreateProcessoDomainEvent>
    {
        public ProcessoChangedDataDistribuicaoValidationDomainEventHandler(IDateTimeService dateTimeService)
            : base(dateTimeService)
        {
        }
    }
}