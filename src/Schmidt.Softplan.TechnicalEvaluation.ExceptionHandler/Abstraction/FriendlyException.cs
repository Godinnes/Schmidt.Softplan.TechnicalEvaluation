using System;

namespace Schmidt.Softplan.TechnicalEvaluation.ExceptionHandler.Abstraction
{
    public class FriendlyException : Exception
    {
        public string[] Arguments { get; private set; }
        public FriendlyException()
        {

        }
        public FriendlyException(string message)
            : base(message)
        {

        }
        public FriendlyException(params string[] arguments)
        {
            Arguments = arguments;
        }
    }
}
