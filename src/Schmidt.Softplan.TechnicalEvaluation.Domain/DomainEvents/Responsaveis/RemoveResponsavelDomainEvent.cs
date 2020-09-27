using Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEvents.Responsaveis
{
    public class RemoveResponsavelDomainEvent : IResponsavelDomainEvent
    {
        public Responsavel Responsavel { get; }
        public RemoveResponsavelDomainEvent(Responsavel responsavel)
        {
            Responsavel = responsavel;
        }
    }
}
