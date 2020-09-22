using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction
{
    internal interface ICommandHandlerAsync<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : IRequest<TResponse>
    {
        Task<TResponse> HandleAsync(TCommand request);
    }
    internal interface ICommandHandlerAsync<in TCommand> : IRequestHandler<TCommand, Unit>
        where TCommand : IRequest
    {
        Task HandleAsync(TCommand request);
    }
    public abstract class CommandHandlerAsync<TCommand, TResponse>
        : ICommandHandlerAsync<TCommand, TResponse>
        where TCommand : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken)
        {
            return await HandleAsync(request);
        }

        public abstract Task<TResponse> HandleAsync(TCommand request);
    }
    public abstract class CommandHandlerAsync<TCommand>
        : ICommandHandlerAsync<TCommand>
        where TCommand : IRequest
    {
        public async Task<Unit> Handle(TCommand request, CancellationToken cancellationToken)
        {
            await HandleAsync(request);
            return await Unit.Task;
        }

        public abstract Task HandleAsync(TCommand request);
    }
}
