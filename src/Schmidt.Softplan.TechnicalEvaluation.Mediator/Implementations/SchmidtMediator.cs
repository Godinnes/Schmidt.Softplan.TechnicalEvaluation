using MediatR;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
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
        public Task SendAsync(IDomainEvent request)
        {
            return _mediator.Send(request);
        }
    }
}
