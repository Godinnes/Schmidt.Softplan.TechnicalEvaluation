using Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEvents.Responsaveis
{
    public class CreateResponsavelDomainEvent : IResponsavelDomainEvent
    {
        public Responsavel Responsavel { get; }
        public CreateResponsavelDomainEvent(Responsavel responsavel)
        {
            Responsavel = responsavel;
        }
    }
}
