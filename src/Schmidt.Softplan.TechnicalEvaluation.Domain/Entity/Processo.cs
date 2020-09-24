using Schmidt.Softplan.TechnicalEvaluation.Common.Exception;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.Entity
{
    public class Processo : Abstraction.Entity
    {
        public Guid ID { get; private set; }
        public string NumeroProcessoUnificado { get; private set; }
        public DateTime Distribuicao { get; private set; }
        public bool SegredoJustica { get; private set; }
        public string PastaFisicaCliente { get; private set; }
        public string Descricao { get; private set; }
        public Guid SituationID { get; private set; }
        public Situacao Situacao { get; private set; }
        public IEnumerable<Responsavel> Responsaveis { get; private set; }
        private Processo() { }
        private Processo(Guid id,
                         string numeroProcessoUnificado,
                         DateTime distribuicao,
                         string pastaFisicaCliente,
                         string descricao,
                         bool segredoJustica,
                         Situacao situacao,
                         IEnumerable<Responsavel> responsaveis)
        {
            ID = id;

            if (string.IsNullOrWhiteSpace(numeroProcessoUnificado))
                throw new ProcessoNumeroProcessoUnificadoNullException();
            if (numeroProcessoUnificado.Length != 20)
                throw new ProcessoNumeroProcessoUnificadoLengthException();
            NumeroProcessoUnificado = numeroProcessoUnificado;

            Distribuicao = distribuicao;
            SegredoJustica = segredoJustica;
            PastaFisicaCliente = pastaFisicaCliente;
            Descricao = descricao;
            SituationID = situacao.ID;
            Situacao = situacao;
            Responsaveis = responsaveis;
        }
        public static Processo Create(string numeroProcessoUnificado,
                                      DateTime distribuicao,
                                      string pastaFisicaCliente,
                                      string descricao,
                                      bool segredoJustica,
                                      Situacao situacao,
                                      IEnumerable<Responsavel> responsaveis)
        {
            return new Processo(Guid.NewGuid(),
                                numeroProcessoUnificado,
                                distribuicao,
                                pastaFisicaCliente,
                                descricao,
                                segredoJustica,
                                situacao,
                                responsaveis);
        }
        public void AddResponsavel(Responsavel responsavel)
        {
            var responsaveis = Responsaveis?.ToList() ?? new List<Responsavel>();
            responsaveis.Add(responsavel);
            Responsaveis = responsaveis;
        }
        public void UpdateSituacao(Situacao situacao)
        {
            SituationID = situacao.ID;
            Situacao = situacao;
        }
    }
}
