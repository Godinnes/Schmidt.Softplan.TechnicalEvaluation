using Schmidt.Softplan.TechnicalEvaluation.Query.Application.Extension;
using Schmidt.Softplan.TechnicalEvaluation.Query.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Schmidt.Softplan.TechnicalEvaluation.Query.Application.ViewModel
{
    public class ProcessoViewModel
    {
        public Guid ID { get; set; }
        public string NumeroProcessoUnificado { get; set; }
        public DateTime? Distribuicao { get; set; }
        public bool SegredoJuridico { get; set; }
        public string PastaFisicaCliente { get; set; }
        public string Descricao { get; set; }
        public SituacaoQueryViewModel Situacao { get; set; }
        public ProcessoViewModel ProcessoVinculado { get; set; }
        public IEnumerable<ResponsavelQueryViewModel> Responsaveis { get; set; }
        public IEnumerable<ProcessoViewModel> ProcessosFilhos { get; set; }
        public static implicit operator ProcessoViewModel(Processo processo)
        {
            if (processo == null)
                return null;
            return new ProcessoViewModel()
            {
                ID = processo.ID,
                NumeroProcessoUnificado = processo.NumeroProcessoUnificado,
                Distribuicao = processo.Distribuicao,
                SegredoJuridico = processo.SegredoJustica,
                PastaFisicaCliente = processo.PastaFisicaCliente,
                Descricao = processo.Descricao,
                Situacao = processo.Situacao,
                ProcessoVinculado = processo.ProcessoVinculado?.ToViewModel(),
                Responsaveis = processo.ProcessoResponsaveis.Select(a => a.Responsavel.ToQueryViewModel())
            };
        }
    }
}
