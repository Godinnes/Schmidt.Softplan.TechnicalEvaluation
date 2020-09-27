using Schmidt.Softplan.TechnicalEvaluation.Application.DomainEventHandler.Abstraction.Responsaveis;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEvents.Responsaveis;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.DomainEventHandler.Responsaveis
{
    public class CreateResponsavelValidateCPFDomainEventHandler : ResponsavelCFPUniqueValidationDomainEventHandler<CreateResponsavelDomainEvent>
    {
        public CreateResponsavelValidateCPFDomainEventHandler(IResponsavelRepository repository) : base(repository)
        {
        }
    }
}
