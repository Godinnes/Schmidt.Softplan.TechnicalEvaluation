namespace Schmidt.Softplan.TechnicalEvaluation.Common.Exception
{
    public class ResponsavelNomeMaxLengthException : TechnicalEvaluationException
    {
        public ResponsavelNomeMaxLengthException(int maxLength)
            : base(new[] { maxLength.ToString() })
        {

        }
    }
}
