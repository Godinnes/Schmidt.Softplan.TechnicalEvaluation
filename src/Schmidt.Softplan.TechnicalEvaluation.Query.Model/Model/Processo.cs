using System;
using System.Collections.Generic;

namespace Schmidt.Softplan.TechnicalEvaluation.Query.Model.Model
{
    public class Processo
    {
        public Guid ID { get; set; }
        public string NumeroProcessoUnificado { get; set; }
        public DateTime? Distribuicao { get; set; }
        public bool SegredoJustica { get; set; }
        public string PastaFisicaCliente { get; set; }
        public string Descricao { get; set; }
        public Guid SituacaoID { get; set; }
        public Guid? ProcessoPaiID { get; set; }
        public Situacao Situacao { get; set; }
        public Processo ProcessoVinculado { get; set; }
        public IEnumerable<ProcessoResponsavel> ProcessoResponsaveis { get; set; }
    }
}
