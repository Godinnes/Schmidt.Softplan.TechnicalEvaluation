using Microsoft.EntityFrameworkCore;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.Extension;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.Specification;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.ViewModel;
using Schmidt.Softplan.TechnicalEvaluation.Query.Data.Abstraction;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Query.Application.Query.Situacoes
{
    public class GetSituacoesQueryHandler : CommandHandlerAsync<GetSituacoesQuery, IEnumerable<SituacaoQueryViewModel>>
    {
        private readonly IQueryRepository _repository;
        public GetSituacoesQueryHandler(IQueryRepository repository)
        {
            _repository = repository;
        }
        public async override Task<IEnumerable<SituacaoQueryViewModel>> HandleAsync(GetSituacoesQuery request)
        {
            var situacoes = await _repository.Situacoes
                .Where(SituacaoSpecification.SituacaoNome(request.Nome))
                .Select(a => a.ToQueryViewModel())
                .ToListAsync();

            return situacoes;
        }
    }
}
