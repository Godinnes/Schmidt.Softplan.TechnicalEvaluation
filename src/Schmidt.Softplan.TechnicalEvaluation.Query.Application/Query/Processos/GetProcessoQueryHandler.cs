using Microsoft.EntityFrameworkCore;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.Extension;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.ViewModel;
using Schmidt.Softplan.TechnicalEvaluation.Query.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Query.Model.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Query.Application.Query.Processos
{
    public class GetProcessoQueryHandler : CommandHandlerAsync<GetProcessoQuery, ProcessoViewModel>
    {
        private readonly IQueryRepository _repository;
        private readonly IProcessoHierarchyQueryRepository _hierarchyRepository;
        public GetProcessoQueryHandler(IQueryRepository repository,
                                       IProcessoHierarchyQueryRepository hierarchyRepository)
        {
            _repository = repository;
            _hierarchyRepository = hierarchyRepository;
        }
        public async override Task<ProcessoViewModel> HandleAsync(GetProcessoQuery request)
        {
            var processosIDs = await _hierarchyRepository.ProcessosFamilyAsync(request.ID);

            var processos = await _repository
                .Processos
                .Include(a => a.Situacao)
                .Include(a => a.ProcessoResponsaveis)
                    .ThenInclude(a => a.Responsavel)
                .Where(a => processosIDs.Contains(a.ID))
                .ToListAsync();

            var selectedProcesso = processos.First(a => a.ID == request.ID);
            var processoViewModel = selectedProcesso.ToViewModel();
            if (selectedProcesso.ProcessoPaiID.HasValue)
                processoViewModel.ProcessoVinculado = processos.First(a => a.ID == selectedProcesso.ProcessoPaiID.Value).ToViewModel();

            processoViewModel.ProcessosFilhos = ProcessoHierarcky(selectedProcesso, processos);

            return processoViewModel;
        }
        private IEnumerable<ProcessoViewModel> ProcessoHierarcky(Processo father, IEnumerable<Processo> processos)
        {
            var children = new List<ProcessoViewModel>();
            foreach (var processo in processos.Where(a => a.ProcessoPaiID == father.ID))
            {
                var viewModel = processo.ToViewModel();
                viewModel.ProcessosFilhos = ProcessoHierarcky(processo, processos);
                children.Add(viewModel);
            }
            return children;
        }
    }
}
