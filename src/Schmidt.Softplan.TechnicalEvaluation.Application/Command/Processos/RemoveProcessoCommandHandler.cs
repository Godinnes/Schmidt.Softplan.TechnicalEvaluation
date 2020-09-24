using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.Command.Processos
{
    public class RemoveProcessoCommandHandler : CommandHandlerAsync<RemoveProcessoCommand>
    {
        private readonly IProcessoRepository _repository;
        public RemoveProcessoCommandHandler(IProcessoRepository repository)
        {
            _repository = repository;
        }
        public async override Task HandleAsync(RemoveProcessoCommand request)
        {
            var processo = await _repository.FindAsync(request.ID);
            _repository.Remove(processo);
            await _repository.SaveChangesAsync();
        }
    }
}
