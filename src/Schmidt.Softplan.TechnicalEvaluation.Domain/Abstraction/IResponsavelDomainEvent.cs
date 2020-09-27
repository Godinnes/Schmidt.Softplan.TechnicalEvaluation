using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Interfaces;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction
{
    public interface IResponsavelDomainEvent : IDomainEvent
    {
        Responsavel Responsavel { get; }
    }
}
