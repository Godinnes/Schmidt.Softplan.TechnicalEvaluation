using Schmidt.Softplan.TechnicalEvaluation.Mediator.Interfaces;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.ViewModel;
using System;

namespace Schmidt.Softplan.TechnicalEvaluation.Query.Application.Query.Responsaveis
{
    public class GetResponsavelQuery : ICommand<ResponsavelViewModel>
    {
        public Guid ID { get; set; }
    }
}
