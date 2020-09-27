using Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEvents.Processos
{
    public class ChangeProcessoSendEmailDomainEvent : IProcessoSendEmailDomainEvent
    {
        public Processo Processo { get; }
        public ChangeProcessoSendEmailDomainEvent(Processo processo)
        {
            Processo = processo;
        }
    }
}
