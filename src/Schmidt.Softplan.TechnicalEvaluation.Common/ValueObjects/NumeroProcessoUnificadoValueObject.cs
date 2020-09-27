using System;
using System.Linq;

namespace Schmidt.Softplan.TechnicalEvaluation.Common.ValueObjects
{
    public struct NumeroProcessoUnificadoValueObject
    {
        public string Value { get; set; }
        public NumeroProcessoUnificadoValueObject(string numeroProcessoUnificado)
        {
            Value = new string(numeroProcessoUnificado.Where(Char.IsDigit).ToArray());
        }
    }
}
