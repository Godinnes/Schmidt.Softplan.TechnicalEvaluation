using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using System;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.Command.Responsaveis
{
    public class RemoveResponsavelCommand : ICommand
    {
        public Guid ID { get; set; }
    }
}
