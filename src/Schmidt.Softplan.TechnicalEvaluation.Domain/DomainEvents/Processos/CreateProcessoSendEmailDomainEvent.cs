using Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEvents.Processos
{
    public class CreateProcessoSendEmailDomainEvent : IProcessoSendEmailDomainEvent
    {
        public Processo Processo { get; }
        public CreateProcessoSendEmailDomainEvent(Processo processo)
        {
            Processo = processo;
        }
    }
}
