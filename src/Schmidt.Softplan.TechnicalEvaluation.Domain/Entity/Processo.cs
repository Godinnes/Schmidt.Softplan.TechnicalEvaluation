using Schmidt.Softplan.TechnicalEvaluation.Common.Exception;
using System;
using System.Collections.Generic;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.Entity
{
    public class Processo : Abstraction.Entity
    {
        public string NumeroProcessoUnificado { get; private set; }
        public DateTime Distribuicao { get; private set; }
        public bool SegredoJustica { get; private set; }
        public string PastaFisicaCliente { get; private set; }
        public string Descricao { get; private set; }
        public Guid SituationID { get; private set; }
        public IEnumerable<Responsavel> Responsaveis { get; private set; }
        private Processo() { }
        private Processo(Guid id,
                         string numeroProcessoUnificado,
                         DateTime distribuicao,
                         string pastaFisicaCliente,
                         string descricao,
                         bool segredoJustica,
                         Guid situationID,
                         IEnumerable<Responsavel> responsaveis)
        {
            ID = id;

            if (string.IsNullOrWhiteSpace(numeroProcessoUnificado))
                throw new ProcessoNumeroProcessoUnificadoNullException();
            if (numeroProcessoUnificado.Length < 20)
                throw new ProcessoNumeroProcessoUnificadoMinLengthException();
            NumeroProcessoUnificado = numeroProcessoUnificado;

            Distribuicao = distribuicao;
            SegredoJustica = segredoJustica;
            PastaFisicaCliente = pastaFisicaCliente;
            Descricao = descricao;
            SituationID = situationID;
            Responsaveis = responsaveis;
        }
        public static Processo Create(string numeroProcessoUnificado,
                                      DateTime distribuicao,
                                      string pastaFisicaCliente,
                                      string descricao,
                                      bool segredoJustica,
                                      Guid situacao,
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
    }
}
