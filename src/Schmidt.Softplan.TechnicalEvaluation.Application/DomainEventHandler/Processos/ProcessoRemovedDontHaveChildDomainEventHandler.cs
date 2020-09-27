using Schmidt.Softplan.TechnicalEvaluation.Common.Exception;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEvents.Processos;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.DomainEventHandler.Processos
{
    public class ProcessoRemovedDontHaveChildDomainEventHandler : DomainEventHandlerAsync<RemoveProcessoDomainEvent>
    {
        private readonly IProcessoRepository _repository;
        public ProcessoRemovedDontHaveChildDomainEventHandler(IProcessoRepository repository)
        {
            _repository = repository;
        }
        public async override Task HandleAsync(RemoveProcessoDomainEvent request)
        {
            var processoChild = await _repository.HasChildAsync(request.Processo.ID);
            if (processoChild)
                throw new ProcessoRemoveVinculedException();
        }
    }
}
