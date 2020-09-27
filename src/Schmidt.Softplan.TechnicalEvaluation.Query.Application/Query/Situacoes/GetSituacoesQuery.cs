using Schmidt.Softplan.TechnicalEvaluation.Mediator.Interfaces;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.ViewModel;
using System.Collections.Generic;

namespace Schmidt.Softplan.TechnicalEvaluation.Query.Application.Query.Situacoes
{
    public class GetSituacoesQuery : ICommand<IEnumerable<SituacaoQueryViewModel>>
    {
        public string Nome { get; set; }
    }
}
