using Schmidt.Softplan.TechnicalEvaluation.Mediator.Interfaces;
using System;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.Command.Responsaveis
{
    public class RemoveResponsavelCommand : ICommand
    {
        public Guid ID { get; set; }
    }
}
