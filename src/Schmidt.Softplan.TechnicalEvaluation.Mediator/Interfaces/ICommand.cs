using MediatR;

namespace Schmidt.Softplan.TechnicalEvaluation.Mediator.Interfaces
{
    public interface ICommand
        : IRequest
    {
    }
    public interface ICommand<out TResult>
        : IRequest<TResult>
    {
    }
}
