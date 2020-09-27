using Schmidt.Softplan.TechnicalEvaluation.Common.Exception;
using Schmidt.Softplan.TechnicalEvaluation.Common.ValueObjects;
using Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEvents.Processos;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public IEnumerable<ProcessoResponsavel> ProcessoResponsaveis { get; private set; }
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
            ProcessoResponsaveis = ToProcessoResposaveis(ID, responsaveis);
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
            ProcessoResponsaveis = ToProcessoResposaveis(ID, responsaveis);
            AddDomainEvent(new ChangeProcessoDomainEvent(this));
        }
        public void CanRemove()
        {
            if (Situacao.Finalizado)
                throw new ProcessoIsFinalizedSituacaoException();
        }
        private string ValidateNumeroProcessoUnificado(string numeroProcessoUnificado)
        {
            var lengthRequired = 20;
            if (string.IsNullOrWhiteSpace(numeroProcessoUnificado))
                throw new ProcessoNumeroProcessoUnificadoNullException();
            var numberWithoutDots = new NumeroProcessoUnificadoValueObject(numeroProcessoUnificado).Value;
            if (numberWithoutDots.Length != lengthRequired)
                throw new ProcessoNumeroProcessoUnificadoLengthException(lengthRequired);
            return numberWithoutDots;
        }
        private IEnumerable<ProcessoResponsavel> ToProcessoResposaveis(Guid id, IEnumerable<Responsavel> responsaveis)
        {
            if (!(responsaveis?.Any() == true))
                return null;
            return responsaveis.Select(a => ProcessoResponsavel.Create(id, a.ID)).ToList();
        }
    }
}
