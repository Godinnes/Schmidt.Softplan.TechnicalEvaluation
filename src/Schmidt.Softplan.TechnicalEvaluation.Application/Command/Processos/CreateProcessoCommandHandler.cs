using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using System;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.Command.Processos
{
    public class CreateProcessoCommandHandler : CommandHandlerAsync<CreateProcessoCommand, Guid>
    {
        private readonly IProcessoRepository _processoRepository;
        public CreateProcessoCommandHandler(IProcessoRepository processoRepository)
        {
            _processoRepository = processoRepository;
        }
        public async override Task<Guid> HandleAsync(CreateProcessoCommand request)
        {
            var newProcesso = Processo.Create(request.NumeroProcessoUnificado,
                                              request.Distribuicao,
                                              request.PastaFisicaCliente,
                                              request.Descricao,
                                              request.SegredoJustica,
                                              request.SituacaoID,
                                              request.Responsaveis);
            _processoRepository.Add(newProcesso);
            await _processoRepository.SaveChangesAsync();
            return newProcesso.ID;
        }
    }
}
