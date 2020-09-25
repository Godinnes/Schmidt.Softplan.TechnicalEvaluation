using Schmidt.Softplan.TechnicalEvaluation.ExceptionHandler.Abstraction;

namespace Schmidt.Softplan.TechnicalEvaluation.Common.Exception
{
    public class ResponsavelEmailMaxLengthException : FriendlyException
    {
        public ResponsavelEmailMaxLengthException(int length)
            : base(new[] { length.ToString() })
        {

        }
    }
}
