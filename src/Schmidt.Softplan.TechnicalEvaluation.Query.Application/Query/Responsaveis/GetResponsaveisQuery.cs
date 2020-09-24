using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.ViewModel;
using System.Collections.Generic;

namespace Schmidt.Softplan.TechnicalEvaluation.Query.Application.Query.Responsaveis
{
    public class GetResponsaveisQuery : ICommand<IEnumerable<ResponsavelQueryViewModel>>
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string NumeroProcessoUnificado { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}
