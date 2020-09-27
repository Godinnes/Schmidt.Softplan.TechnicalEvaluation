using Schmidt.Softplan.TechnicalEvaluation.Application.InputModel;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Interfaces;
using System;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.Command.Responsaveis
{
    public class ChangeResponsavelCommand : ResponsavelInputModel, ICommand
    {
        public Guid ID { get; set; }
    }
}
