namespace Schmidt.Softplan.TechnicalEvaluation.EmailSender.Interface
{
    public interface IMailSender
    {
        void Send(string title, string message, params string[] emails);
    }
}
