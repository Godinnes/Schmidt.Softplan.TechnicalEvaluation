using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Schmidt.Softplan.TechnicalEvaluation.EmailSender.Interface;
using System.Net.Mail;

namespace Schmidt.Softplan.TechnicalEvaluation.EmailSender.Implementation
{
    public class MailSender : IMailSender
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<MailSender> _logger;
        public MailSender(IConfiguration configuration,
                          ILogger<MailSender> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public void Send(string title, string message, params string[] emails)
        {
            if (emails.Length == 0)
                return;
            var emailSender = _configuration["Email:Address"];
            if (string.IsNullOrEmpty(emailSender))
                return;

            var mail = CreateMessage(emailSender, title, message, emails);
            var smtpClient = CreateClient(emailSender);
            smtpClient.Send(mail);
            _logger.LogInformation("E-mail sended.");
        }
        private SmtpClient CreateClient(string emailSender)
        {
            var password = _configuration["Email:Password"];
            var smtp = _configuration["Email:SMTP"];
            var port = int.Parse(_configuration["Email:PORT"]);
            var smtpClient = new SmtpClient(smtp, port);
            smtpClient.EnableSsl = bool.Parse(_configuration["Email:SSL"]);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential(emailSender, password);

            return smtpClient;
        }
        private MailMessage CreateMessage(string emailSender, string title, string message, string[] emails)
        {
            var display = _configuration["Email:Display"];
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(emailSender, display);
            foreach (var email in emails)
            {
                mail.To.Add(new MailAddress(email));
            }
            mail.Subject = title;
            mail.Body = message;
            return mail;
        }
    }
}
