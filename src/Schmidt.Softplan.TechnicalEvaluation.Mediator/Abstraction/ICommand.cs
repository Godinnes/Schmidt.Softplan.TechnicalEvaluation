using MediatR;

namespace Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction
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
