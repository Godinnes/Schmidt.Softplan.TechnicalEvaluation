namespace Schmidt.Softplan.TechnicalEvaluation.Common.Exception
{
    public class ProcessoDescricaoMaxLengthException : TechnicalEvaluationException
    {
        public ProcessoDescricaoMaxLengthException(int maxLength)
            : base(new[] { maxLength.ToString() })
        {

        }
    }
}
