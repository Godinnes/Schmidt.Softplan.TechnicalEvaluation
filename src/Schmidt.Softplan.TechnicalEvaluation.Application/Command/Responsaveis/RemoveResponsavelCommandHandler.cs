using Microsoft.EntityFrameworkCore;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using System.Linq;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.Command.Responsaveis
{
    public class RemoveResponsavelCommandHandler : CommandHandlerAsync<RemoveResponsavelCommand>
    {
        private readonly IResponsavelRepository _repository;
        public RemoveResponsavelCommandHandler(IResponsavelRepository repository)
        {
            _repository = repository;
        }
        public async override Task HandleAsync(RemoveResponsavelCommand request)
        {
            var responsavel = await _repository.Entities
                .Include(a => a.ProcessoResponsaveis)
                .ThenInclude(a => a.Processo)
                .Where(a => a.ID == request.ID)
                .FirstOrDefaultAsync();

            _repository.Remove(responsavel);
            await _repository.SaveChangesAsync();
        }
    }
}
