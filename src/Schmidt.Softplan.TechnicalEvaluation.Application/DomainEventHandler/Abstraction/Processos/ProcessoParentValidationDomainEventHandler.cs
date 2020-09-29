using Schmidt.Softplan.TechnicalEvaluation.Common.Exception;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using System.Linq;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.DomainEventHandler.Abstraction.Processos
{
    public abstract class ProcessoParentValidationDomainEventHandler<TProcessoDomainEvent> : DomainEventHandlerAsync<TProcessoDomainEvent>
        where TProcessoDomainEvent : IProcessoDomainEvent
    {
        private readonly IProcessoRepository _repository;
        private readonly IProcessoHierarchyRepository _hierarchyRepository;
        public ProcessoParentValidationDomainEventHandler(IProcessoRepository repository,
                                                          IProcessoHierarchyRepository hierarchyRepository)
        {
            _repository = repository;
            _hierarchyRepository = hierarchyRepository;
        }
        public async override Task HandleAsync(TProcessoDomainEvent request)
        {
            if (!request.Processo.ProcessoPaiID.HasValue)
                return;

            var hasParentAlreadVinculed = await _repository.HasProcessoParentVinculedAsync(request.Processo.ID, request.Processo.ProcessoPaiID.Value);
            if (hasParentAlreadVinculed)
                throw new ProcessoParentAlreadyVinculedException();

            var maxHierarchyProcessos = 4;
            var processoIDs = await _hierarchyRepository.ProcessosFamilyAsync(request.Processo.ProcessoPaiID.Value);
            if (processoIDs.Count() >= maxHierarchyProcessos)
                throw new ProcessoHierarchyMaxLenghtException(maxHierarchyProcessos);
        }
    }
}
