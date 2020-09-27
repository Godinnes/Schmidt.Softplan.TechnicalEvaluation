using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Mediator.Interfaces
{
    public interface ISchmidtMediator
    {
        Task<TResult> SendAsync<TResult>(ICommand<TResult> request);
        Task SendAsync(ICommand request);
        Task PublishAsync<TDomainEvent>(TDomainEvent notification) where TDomainEvent : IDomainEvent;
    }
}
