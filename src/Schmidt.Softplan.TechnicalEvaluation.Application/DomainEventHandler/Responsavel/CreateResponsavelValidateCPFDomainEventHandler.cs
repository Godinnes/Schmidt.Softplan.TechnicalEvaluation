using Schmidt.Softplan.TechnicalEvaluation.Application.DomainEventHandler.Abstraction.Responsavel;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEvents.Responsaveis;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.DomainEventHandler.Responsavel
{
    public class CreateResponsavelValidateCPFDomainEventHandler : ResponsavelCFPUniqueValidationDomainEventHandler<CreateResponsavelDomainEvent>
    {
        public CreateResponsavelValidateCPFDomainEventHandler(IResponsavelRepository repository) : base(repository)
        {
        }
    }
}
