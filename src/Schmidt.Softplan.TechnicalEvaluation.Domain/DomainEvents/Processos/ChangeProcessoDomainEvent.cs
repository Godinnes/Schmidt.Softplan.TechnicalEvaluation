using Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEvents.Processos
{
    public class ChangeProcessoDomainEvent : IProcessoDomainEvent
    {
        public Processo Processo { get; }
        public ChangeProcessoDomainEvent(Processo processo)
        {
            Processo = processo;
        }
    }
}
