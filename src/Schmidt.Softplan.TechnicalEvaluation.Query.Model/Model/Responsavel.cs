using System;
using System.Collections.Generic;

namespace Schmidt.Softplan.TechnicalEvaluation.Query.Model.Model
{
    public class Responsavel
    {
        public Guid ID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }
        public IEnumerable<ProcessoResponsavel> ProcessoResponsaveis { get; set; }
    }
}
