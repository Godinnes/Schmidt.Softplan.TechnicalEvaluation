using Microsoft.Extensions.DependencyInjection;
using Schmidt.Softplan.TechnicalEvaluation.EmailSender.Implementation;
using Schmidt.Softplan.TechnicalEvaluation.EmailSender.Interface;

namespace Schmidt.Softplan.TechnicalEvaluation.EmailSender.Extension
{
    public static class EmailSenderExtension
    {
        public static IServiceCollection AddEmailSender(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMailSender, MailSender>();

            return serviceCollection;
        }
    }
}
