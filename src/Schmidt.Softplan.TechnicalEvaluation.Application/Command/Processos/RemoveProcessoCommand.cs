using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using System;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.Command.Processos
{
    public class RemoveProcessoCommand : ICommand
    {
        public Guid ID { get; set; }
    }
}
