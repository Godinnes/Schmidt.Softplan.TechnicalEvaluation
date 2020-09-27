namespace Schmidt.Softplan.TechnicalEvaluation.Common.Exception
{
    public class ProcessoResponsavelMaxLengthException : TechnicalEvaluationException
    {
        public ProcessoResponsavelMaxLengthException(int maxLenght)
            : base(new[] { maxLenght.ToString() })
        {


        }
    }
}
