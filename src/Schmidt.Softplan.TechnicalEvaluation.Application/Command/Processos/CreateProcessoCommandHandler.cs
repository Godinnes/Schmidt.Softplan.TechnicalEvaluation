using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using System;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.Command.Processos
{
    public class CreateProcessoCommandHandler : CommandHandlerAsync<CreateProcessoCommand, Guid>
    {
        private readonly IResponsavelRepository _responsavelRepository;
        private readonly IProcessoRepository _processoRepository;
        private readonly ISituacaoRepository _situacaoRepository;
        public CreateProcessoCommandHandler(IProcessoRepository processoRepository,
                                            IResponsavelRepository responsavelRepository,
                                            ISituacaoRepository situacaoRepository)
        {
            _processoRepository = processoRepository;
            _responsavelRepository = responsavelRepository;
            _situacaoRepository = situacaoRepository;
        }
        public async override Task<Guid> HandleAsync(CreateProcessoCommand request)
        {
            var responsaveis = await _responsavelRepository.GetResponsaveisByIDsAync(request.Responsaveis);
            var situacao = await _situacaoRepository.FindAsync(request.SituacaoID);
            var newProcesso = Processo.Create(request.NumeroProcessoUnificado,
                                              request.Distribuicao,
                                              request.PastaFisicaCliente,
                                              request.Descricao,
                                              request.SegredoJustica,
                                              situacao,
                                              responsaveis,
                                              request.ProcessoPaiID);
            _processoRepository.Add(newProcesso);
            await _processoRepository.SaveChangesAsync();
            return newProcesso.ID;
        }
    }
}
