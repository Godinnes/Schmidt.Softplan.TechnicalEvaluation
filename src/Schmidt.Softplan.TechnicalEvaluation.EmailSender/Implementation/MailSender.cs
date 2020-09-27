using Microsoft.Extensions.Configuration;
using Schmidt.Softplan.TechnicalEvaluation.EmailSender.Interface;
using System.Net.Mail;

namespace Schmidt.Softplan.TechnicalEvaluation.EmailSender.Implementation
{
    public class MailSender : IMailSender
    {
        private readonly IConfiguration _configuration;
        public MailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Send(string title, string message, params string[] emails)
        {
            if (emails.Length == 0)
                return;
            var emailSender = _configuration["Email:Address"];
            var password = _configuration["Email:Password"];
            var display = _configuration["Email:Display"];
            if (string.IsNullOrEmpty(emailSender))
                return;
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(emailSender, display);
            foreach (var email in emails)
            {
                mail.To.Add(new MailAddress(email));
            }
            mail.Subject = title;
            mail.Body = message;

            var smtp = _configuration["Email:SMTP"];
            var port = int.Parse(_configuration["Email:PORT"]);
            var smtpClient = new SmtpClient(smtp, port);
            smtpClient.Send(mail);
        }
    }
}
