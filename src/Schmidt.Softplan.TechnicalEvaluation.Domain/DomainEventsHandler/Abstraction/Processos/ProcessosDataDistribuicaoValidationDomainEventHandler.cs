using Schmidt.Softplan.TechnicalEvaluation.Common.Exception;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEventsHandler.Abstraction.Processos
{
    public abstract class ProcessosDataDistribuicaoValidationDomainEventHandler<TProcessoDomainEvent> : DomainEventHandler<TProcessoDomainEvent>
        where TProcessoDomainEvent : IProcessoDomainEvent
    {
        private readonly IDateTimeService _dateTimeService;
        public ProcessosDataDistribuicaoValidationDomainEventHandler(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
        }
        public override void Handle(TProcessoDomainEvent request)
        {
            if (!request.Processo.Distribuicao.HasValue)
                return;

            if (_dateTimeService.CurrentDateTime > request.Processo.Distribuicao.Value)
                throw new ProcessoDateDistribuicaoException();
        }
    }
}
