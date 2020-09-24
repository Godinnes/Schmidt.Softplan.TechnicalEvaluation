using Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEvents.Processos
{
    public class CreateProcessoDomainEvent : IProcessoDomainEvent
    {
        public Processo Processo { get; }
        public CreateProcessoDomainEvent(Processo processo)
        {
            Processo = processo;
        }
    }
}
