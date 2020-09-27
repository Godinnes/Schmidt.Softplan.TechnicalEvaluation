using Microsoft.EntityFrameworkCore;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.Extension;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.ViewModel;
using Schmidt.Softplan.TechnicalEvaluation.Query.Data.Abstraction;
using System.Linq;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Query.Application.Query.Processos
{
    public class GetProcessoQueryHandler : CommandHandlerAsync<GetProcessoQuery, ProcessoViewModel>
    {
        private readonly IQueryRepository _repository;
        public GetProcessoQueryHandler(IQueryRepository repository)
        {
            _repository = repository;
        }
        public async override Task<ProcessoViewModel> HandleAsync(GetProcessoQuery request)
        {
            var processo = await _repository
                .Processos
                .Include(a => a.Situacao)
                .Include(a => a.ProcessoResponsaveis)
                    .ThenInclude(a => a.Responsavel)
                .Include(a => a.ProcessoVinculado)
                    .ThenInclude(a => a.Situacao)
                .Include(a => a.ProcessoVinculado)
                    .ThenInclude(a => a.ProcessoVinculado)
                        .ThenInclude(a => a.Situacao)
                .Where(a => a.ID == request.ID)
                .Select(a => a.ToViewModel())
                .FirstOrDefaultAsync();

            return processo;
        }
    }
}
