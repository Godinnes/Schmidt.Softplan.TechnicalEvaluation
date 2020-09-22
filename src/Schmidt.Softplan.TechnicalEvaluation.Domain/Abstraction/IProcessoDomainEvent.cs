using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction
{
    public interface IProcessoDomainEvent : IDomainEvent
    {
        Processo Processo { get; }
    }
}
