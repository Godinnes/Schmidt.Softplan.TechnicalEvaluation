using Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEvents.Processos
{
    public class RemoveProcessoDomainEvent : IProcessoDomainEvent
    {
        public Processo Processo { get; }
        public RemoveProcessoDomainEvent(Processo processo)
        {
            Processo = processo;
        }
    }
}
