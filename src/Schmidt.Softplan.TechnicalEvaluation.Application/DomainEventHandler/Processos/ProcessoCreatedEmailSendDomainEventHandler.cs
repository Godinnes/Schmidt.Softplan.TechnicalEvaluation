using Schmidt.Softplan.TechnicalEvaluation.Application.DomainEventHandler.Abstraction.Processos;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEvents.Processos;
using Schmidt.Softplan.TechnicalEvaluation.EmailSender.Interface;

namespace Schmidt.Softplan.TechnicalEvaluation.Application.DomainEventHandler.Processos
{
    public class ProcessoCreatedEmailSendDomainEventHandler : ProcessoSendEmailDomainEventHandler<CreateProcessoSendEmailDomainEvent>
    {
        public ProcessoCreatedEmailSendDomainEventHandler(IMailSender mailSender, IResponsavelRepository responsavelRepository)
            : base(mailSender, responsavelRepository)
        {
        }
    }
}
