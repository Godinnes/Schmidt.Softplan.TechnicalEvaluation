using Schmidt.Softplan.TechnicalEvaluation.Common.Resources;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEvents.Processos;
using Schmidt.Softplan.TechnicalEvaluation.EmailSender.Interface;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using System.Linq;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.DomainEventHandler.Processos
{
    public class ProcessoRemovedSendEmailDomainEventHandler : DomainEventHandlerAsync<RemoveProcessoDomainEvent>
    {
        private readonly IMailSender _mailSender;
        private readonly IResponsavelRepository _responsavelRepository;
        public ProcessoRemovedSendEmailDomainEventHandler(IMailSender mailSender,
                                                          IResponsavelRepository responsavelRepository)
        {
            _mailSender = mailSender;
            _responsavelRepository = responsavelRepository;
        }
        public async override Task HandleAsync(RemoveProcessoDomainEvent request)
        {
            var title = TechnicalEvaluationMessages.EmailTitle;
            var message = string.Format(TechnicalEvaluationMessages.EmailRemovedMessage, request.Processo.NumeroProcessoUnificado);
            var responsaveisIDs = request.Processo.ProcessoResponsaveis.Select(a => a.ResponsavelID);
            var responsaveis = await _responsavelRepository.GetResponsaveisByIDsAsync(responsaveisIDs);
            var emails = responsaveis.Select(a => a.Email).ToArray();
            _mailSender.Send(title, message, emails);
        }
    }
}
