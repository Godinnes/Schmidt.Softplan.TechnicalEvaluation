using Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEvents.Responsaveis
{
    public class ChangeResponsavelDomainEvent : IResponsavelDomainEvent
    {
        public Responsavel Responsavel { get; }
        public ChangeResponsavelDomainEvent(Responsavel responsavel)
        {
            Responsavel = responsavel;
        }
    }
}
