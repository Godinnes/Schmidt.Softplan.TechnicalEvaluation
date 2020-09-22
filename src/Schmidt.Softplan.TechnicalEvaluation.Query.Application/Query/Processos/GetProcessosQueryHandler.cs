using Microsoft.EntityFrameworkCore;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.Extension;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.Specification;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.ViewModel;
using Schmidt.Softplan.TechnicalEvaluation.Query.Data.Abstraction;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Query.Application.Query.Processos
{
    public class GetProcessosQueryHandler : CommandHandlerAsync<GetProcessosQuery, IEnumerable<ProcessoQueryViewModel>>
    {
        private readonly IQueryRepository _repository;
        public GetProcessosQueryHandler(IQueryRepository repository)
        {
            _repository = repository;
        }
        public async override Task<IEnumerable<ProcessoQueryViewModel>> HandleAsync(GetProcessosQuery request)
        {
            var skip = request.Skip ?? 0;
            var take = request.Take ?? 10;

            var processos = await _repository.Processos
                .Where(ProcessoSpecification.ProcessoDestribuicaoBetween(request.InicioDistribuicao, request.FimDistribuicao))
                .Where(ProcessoSpecification.ProcessoNumeroProcessoUnificado(request.NumeroProcessoUnificado))
                .Where(ProcessoSpecification.ProcessoResponsavel(request.Responsavel))
                .Where(ProcessoSpecification.ProcessoSituacao(request.SituacaoID))
                .Where(ProcessoSpecification.ProcessoPastaFisicaPessoa(request.PastaFisicaCliente))
                .Where(ProcessoSpecification.ProcessoSegredoJustica(request.SegredoJustica))
                .Where(ProcessoSpecification.ProcessoResponsavel(request.Descricao))
                .Skip(skip)
                .Take(take)
                .Select(p => p.ToViewModel())
                .ToListAsync();

            return processos;
        }
    }
}