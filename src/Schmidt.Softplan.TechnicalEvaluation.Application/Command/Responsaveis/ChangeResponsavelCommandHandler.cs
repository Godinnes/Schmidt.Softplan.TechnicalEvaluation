using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.Command.Responsaveis
{
    public class ChangeResponsavelCommandHandler : CommandHandlerAsync<ChangeResponsavelCommand>
    {
        private readonly IResponsavelRepository _repository;
        public ChangeResponsavelCommandHandler(IResponsavelRepository repository)
        {
            _repository = repository;
        }
        public async override Task HandleAsync(ChangeResponsavelCommand request)
        {
            var responsavel = await _repository.FindAsync(request.ID);
            responsavel.Update(request.Nome, request.CPF, request.Email, request.Foto);
            await _repository.SaveChangesAsync();
        }
    }
}
