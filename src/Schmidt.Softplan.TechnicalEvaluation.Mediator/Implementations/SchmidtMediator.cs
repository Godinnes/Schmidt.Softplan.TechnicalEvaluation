using MediatR;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Interfaces;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Mediator.Implementations
{
    internal class SchmidtMediator : ISchmidtMediator
    {
        private readonly IMediator _mediator;
        public SchmidtMediator(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<TResult> SendAsync<TResult>(ICommand<TResult> request)
        {
            return await _mediator.Send(request, default);
        }
        public Task SendAsync(ICommand request)
        {
            return _mediator.Send(request);
        }
        public Task PublishAsync<TDomainEvent>(TDomainEvent notification)
            where TDomainEvent : IDomainEvent
        {
            return _mediator.Publish(notification, default);
        }
    }
}
