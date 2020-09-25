namespace Schmidt.Softplan.TechnicalEvaluation.Common.Exception
{
    public class ResponsavelEmailMaxLengthException : TechnicalEvaluationException
    {
        public ResponsavelEmailMaxLengthException(int length)
            : base(new[] { length.ToString() })
        {

        }
    }
}
