namespace Schmidt.Softplan.TechnicalEvaluation.Common.Exception
{
    public class ProcessoHierarchyMaxLenghtException : TechnicalEvaluationException
    {
        public ProcessoHierarchyMaxLenghtException(int maxLength)
            : base(new[] { maxLength.ToString() })
        {

        }
    }
}
