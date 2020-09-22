using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction
{
    public interface ISchmidtMediator
    {
        Task<TResult> SendAsync<TResult>(ICommand<TResult> request);
        Task SendAsync(ICommand request);
        Task SendAsync(IDomainEvent request);
    }
}
