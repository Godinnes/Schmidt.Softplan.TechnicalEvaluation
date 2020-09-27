using Schmidt.Softplan.TechnicalEvaluation.Common.Exception;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using System.Linq;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.Command.Processos
{
    public class ChangeProcessoCommandHandler : CommandHandlerAsync<ChangeProcessoCommand>
    {
        private readonly IResponsavelRepository _responsavelRepository;
        private readonly IProcessoRepository _processoRepository;
        private readonly ISituacaoRepository _situacaoRepository;
        public ChangeProcessoCommandHandler(IProcessoRepository processoRepository,
                                            IResponsavelRepository responsavelRepository,
                                            ISituacaoRepository situacaoRepository)
        {
            _processoRepository = processoRepository;
            _responsavelRepository = responsavelRepository;
            _situacaoRepository = situacaoRepository;
        }
        public async override Task HandleAsync(ChangeProcessoCommand request)
        {
            if (request.Responsaveis.Count() != request.Responsaveis.Distinct().Count())
                throw new ProcessoResponsavelDuplicatedException();

            var processo = await _processoRepository.FindAsync(request.ID);
            if (processo == null)
                throw new ProcessoNotFoundException();

            var responsaveis = await _responsavelRepository.GetResponsaveisByIDsAsync(request.Responsaveis);
            var situacao = await _situacaoRepository.FindAsync(request.SituacaoID);

            processo.Update(request.NumeroProcessoUnificado,
                            request.Distribuicao,
                            request.PastaFisicaCliente,
                            request.Descricao,
                            request.SegredoJustica,
                            situacao,
                            responsaveis,
                            request.ProcessoPaiID);

            await _processoRepository.SaveChangesAsync();
        }
    }
}
