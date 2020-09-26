using System;
using System.Resources;

namespace Schmidt.Softplan.TechnicalEvaluation.ExceptionHandler.Implementation
{
    public class FriendlyException<T> : Exception
    {
        public override string Message { get; }
        public FriendlyException()
        {
            Message = TranslateMessage();
        }
        public FriendlyException(string message)
        {
            Message = message;
        }
        public FriendlyException(params string[] arguments)
        {
            Message = TranslateMessage(arguments);
        }
        private string TranslateMessage(params string[] arguments)
        {
            var resource = new ResourceManager(typeof(T).FullName, typeof(T).Assembly);
            var message = resource.GetString(this.GetType().Name);
            if (arguments.Length > 0)
                return string.Format(message, arguments);
            return message;
        }
    }
}
