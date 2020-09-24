using Schmidt.Softplan.TechnicalEvaluation.Common.Exception;
using Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEvents.Processos;
using System;
using System.Collections.Generic;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.Entity
{
    public class Processo : Abstraction.Entity
    {
        public Guid ID { get; private set; }
        public string NumeroProcessoUnificado { get; private set; }
        public DateTime? Distribuicao { get; private set; }
        public bool SegredoJustica { get; private set; }
        public string PastaFisicaCliente { get; private set; }
        public string Descricao { get; private set; }
        public Guid SituacaoID { get; private set; }
        public Situacao Situacao { get; private set; }
        public IEnumerable<Responsavel> Responsaveis { get; private set; }
        private Processo() { }
        private Processo(Guid id,
                         string numeroProcessoUnificado,
                         DateTime? distribuicao,
                         string pastaFisicaCliente,
                         string descricao,
                         bool segredoJustica,
                         Situacao situacao,
                         IEnumerable<Responsavel> responsaveis)
        {
            ID = id;
            NumeroProcessoUnificado = ValidateNumeroProcessoUnificado(numeroProcessoUnificado);
            Distribuicao = distribuicao;
            SegredoJustica = segredoJustica;
            PastaFisicaCliente = pastaFisicaCliente;
            Descricao = descricao;
            SituacaoID = situacao.ID;
            Situacao = situacao;
            Responsaveis = responsaveis;
            AddDomainEvent(new CreateProcessoDomainEvent(this));
        }
        public static Processo Create(string numeroProcessoUnificado,
                                      DateTime? distribuicao,
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
        public void Update(string numeroProcessoUnificado,
                           DateTime? distribuicao,
                           string pastaFisicaCliente,
                           string descricao,
                           bool segredoJustica,
                           Situacao situacao,
                           IEnumerable<Responsavel> responsaveis)
        {
            NumeroProcessoUnificado = ValidateNumeroProcessoUnificado(numeroProcessoUnificado);
            Distribuicao = distribuicao;
            SegredoJustica = segredoJustica;
            PastaFisicaCliente = pastaFisicaCliente;
            Descricao = descricao;
            SituacaoID = situacao.ID;
            Situacao = situacao;
            Responsaveis = responsaveis;
            AddDomainEvent(new ChangeProcessoDomainEvent(this));
        }
        public void CanRemove()
        {
            if (Situacao.Finalizado)
                throw new ProcessoIsFinalizedSituacaoException();
        }
        private string ValidateNumeroProcessoUnificado(string numeroProcessoUnificado)
        {
            if (string.IsNullOrWhiteSpace(numeroProcessoUnificado))
                throw new ProcessoNumeroProcessoUnificadoNullException();
            if (numeroProcessoUnificado.Length != 20)
                throw new ProcessoNumeroProcessoUnificadoLengthException();
            return numeroProcessoUnificado;
        }
    }
}
