using Schmidt.Softplan.TechnicalEvaluation.Common.Resources;
using Schmidt.Softplan.TechnicalEvaluation.ExceptionHandler.Implementation;

namespace Schmidt.Softplan.TechnicalEvaluation.Common.Exception
{
    public class TechnicalEvaluationException : FriendlyException<TechnicalEvaluationExceptions>
    {
        public TechnicalEvaluationException()
            : base()
        {

        }
        public TechnicalEvaluationException(string message)
            : base(message)
        {

        }
        public TechnicalEvaluationException(params string[] args)
            : base(args)
        {

        }
    }
}
