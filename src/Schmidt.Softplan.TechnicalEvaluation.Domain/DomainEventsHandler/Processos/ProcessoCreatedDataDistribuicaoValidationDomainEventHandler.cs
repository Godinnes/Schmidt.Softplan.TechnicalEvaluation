using Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEvents.Processos;
using Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEventsHandler.Abstraction.Processos;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEventsHandler.Processos
{
    public class ProcessoCreatedDataDistribuicaoValidationDomainEventHandler : ProcessosDataDistribuicaoValidationDomainEventHandler<CreateProcessoDomainEvent>
    {
        public ProcessoCreatedDataDistribuicaoValidationDomainEventHandler(IDateTimeService dateTimeService)
            : base(dateTimeService)
        {
        }
    }
}
