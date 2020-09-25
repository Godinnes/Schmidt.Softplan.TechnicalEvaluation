namespace Schmidt.Softplan.TechnicalEvaluation.Common.Exception
{
    public class ProcessoNumeroProcessoUnificadoLengthException : TechnicalEvaluationException
    {
        public ProcessoNumeroProcessoUnificadoLengthException(int length)
            : base(new[] { length.ToString() })
        {

        }
    }
}
