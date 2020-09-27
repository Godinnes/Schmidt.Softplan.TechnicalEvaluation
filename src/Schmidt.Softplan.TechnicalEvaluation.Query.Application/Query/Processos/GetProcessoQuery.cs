using Schmidt.Softplan.TechnicalEvaluation.Mediator.Interfaces;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.ViewModel;
using System;

namespace Schmidt.Softplan.TechnicalEvaluation.Query.Application.Query.Processos
{
    public class GetProcessoQuery : ICommand<ProcessoViewModel>
    {
        public Guid ID { get; set; }
    }
}
