using Schmidt.Softplan.TechnicalEvaluation.Mediator.Interfaces;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace Schmidt.Softplan.TechnicalEvaluation.Query.Application.Query.Processos
{
    public class GetProcessosQuery : ICommand<IEnumerable<ProcessoQueryViewModel>>
    {
        public string NumeroProcessoUnificado { get; set; }
        public DateTime? InicioDistribuicao { get; set; }
        public DateTime? FimDistribuicao { get; set; }
        public string PastaFisicaCliente { get; set; }
        public Guid? SituacaoID { get; set; }
        public string Responsavel { get; set; }
        public bool? SegredoJustica { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}
