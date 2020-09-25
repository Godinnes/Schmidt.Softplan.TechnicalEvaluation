using Schmidt.Softplan.TechnicalEvaluation.ExceptionHandler.Abstraction;

namespace Schmidt.Softplan.TechnicalEvaluation.Common.Exception
{
    public class ProcessoNumeroProcessoUnificadoLengthException : FriendlyException
    {
        public ProcessoNumeroProcessoUnificadoLengthException(int length)
            : base(new[] { length.ToString() })
        {

        }
    }
}
