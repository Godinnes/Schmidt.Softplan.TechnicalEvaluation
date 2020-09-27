using Schmidt.Softplan.TechnicalEvaluation.Mediator.Interfaces;
using System;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.Command.Processos
{
    public class RemoveProcessoCommand : ICommand
    {
        public Guid ID { get; set; }
    }
}
