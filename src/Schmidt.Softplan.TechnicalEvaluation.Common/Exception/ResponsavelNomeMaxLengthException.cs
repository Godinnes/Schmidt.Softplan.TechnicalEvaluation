using Schmidt.Softplan.TechnicalEvaluation.ExceptionHandler.Abstraction;

namespace Schmidt.Softplan.TechnicalEvaluation.Common.Exception
{
    public class ResponsavelNomeMaxLengthException : FriendlyException
    {
        public ResponsavelNomeMaxLengthException(int maxLength)
            : base(new[] { maxLength.ToString() })
        {

        }
    }
}
