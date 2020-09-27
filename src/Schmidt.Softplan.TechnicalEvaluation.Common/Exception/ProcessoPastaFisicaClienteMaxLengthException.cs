namespace Schmidt.Softplan.TechnicalEvaluation.Common.Exception
{
    public class ProcessoPastaFisicaClienteMaxLengthException : TechnicalEvaluationException
    {
        public ProcessoPastaFisicaClienteMaxLengthException(int maxLength)
            : base(new[] { maxLength.ToString() })
        {

        }
    }
}
