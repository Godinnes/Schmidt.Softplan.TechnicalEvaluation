using System;
using System.Resources;

namespace Schmidt.Softplan.TechnicalEvaluation.ExceptionHandler.Implementation
{
    public class FriendlyException<T> : Exception
    {
        public new string Message { get; private set; }
        public FriendlyException()
        {

        }
        public FriendlyException(string message)
        {
            Message = message;
        }
        public FriendlyException(params string[] arguments)
        {
            var resource = new ResourceManager(typeof(T).FullName, typeof(T).Assembly);
            var message = resource.GetString(this.GetType().Name);
            if (arguments.Length > 0)
                Message = string.Format(message, arguments);
            else
                Message = message;
        }
    }
}
