using Microsoft.EntityFrameworkCore;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.Extension;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.Specification;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.ViewModel;
using Schmidt.Softplan.TechnicalEvaluation.Query.Data.Abstraction;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Query.Application.Query.Responsaveis
{
    public class GetResponsaveisQueryHandler : CommandHandlerAsync<GetResponsaveisQuery, IEnumerable<ResponsavelQueryViewModel>>
    {
        private readonly IQueryRepository _repository;
        public GetResponsaveisQueryHandler(IQueryRepository repository)
        {
            _repository = repository;
        }
        public async override Task<IEnumerable<ResponsavelQueryViewModel>> HandleAsync(GetResponsaveisQuery request)
        {
            var skip = request.Skip ?? 0;
            var take = request.Take ?? 10;

            var processos = await _repository.Responsaveis
                .Include(a => a.ProcessoResponsaveis)
                    .ThenInclude(a => a.Processo)
                .Where(ResponsavelSpecification.ResponsavelNome(request.Nome))
                .Where(ResponsavelSpecification.ResponsavelCPF(request.CPF))
                .Where(ResponsavelSpecification.ResponsavelNumeroProcessoUnificado(request.NumeroProcessoUnificado))
                .Skip(skip)
                .Take(take)
                .Select(p => p.ToQueryViewModel())
                .ToListAsync();

            return processos;
        }
    }
}
