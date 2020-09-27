using Schmidt.Softplan.TechnicalEvaluation.Application.DomainEventHandler.Abstraction.Responsaveis;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEvents.Responsaveis;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.DomainEventHandler.Responsaveis
{
    public class ChangeResponsavelCPFValidationDomainEventHandler : ResponsavelCFPUniqueValidationDomainEventHandler<ChangeResponsavelDomainEvent>
    {
        public ChangeResponsavelCPFValidationDomainEventHandler(IResponsavelRepository repository) : base(repository)
        {
        }
    }
}
