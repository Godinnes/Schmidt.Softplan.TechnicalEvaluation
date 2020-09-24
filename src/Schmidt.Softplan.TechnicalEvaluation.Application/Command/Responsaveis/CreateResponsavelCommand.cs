using Schmidt.Softplan.TechnicalEvaluation.Application.InputModel;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using System;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.Command.Responsaveis
{
    public class CreateResponsavelCommand : ResponsavelInputModel, ICommand<Guid>
    {
    }
}
