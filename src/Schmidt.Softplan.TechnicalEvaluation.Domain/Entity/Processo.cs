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
        public Guid? ProcessoPaiID { get; private set; }
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
                         IEnumerable<Responsavel> responsaveis,
                         Guid? processoPaiID)
        {
            ID = id;
            NumeroProcessoUnificado = ValidateNumeroProcessoUnificado(numeroProcessoUnificado);
            Distribuicao = distribuicao;
            SegredoJustica = segredoJustica;
            PastaFisicaCliente = pastaFisicaCliente;
            Descricao = descricao;
            SituacaoID = situacao.ID;
            ProcessoPaiID = processoPaiID;
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
                                      IEnumerable<Responsavel> responsaveis,
                                      Guid? processoPaiID)
        {
            return new Processo(Guid.NewGuid(),
                                numeroProcessoUnificado,
                                distribuicao,
                                pastaFisicaCliente,
                                descricao,
                                segredoJustica,
                                situacao,
                                responsaveis,
                                processoPaiID);
        }
        public void Update(string numeroProcessoUnificado,
                           DateTime? distribuicao,
                           string pastaFisicaCliente,
                           string descricao,
                           bool segredoJustica,
                           Situacao situacao,
                           IEnumerable<Responsavel> responsaveis,
                           Guid? processoPaiID)
        {
            NumeroProcessoUnificado = ValidateNumeroProcessoUnificado(numeroProcessoUnificado);
            Distribuicao = distribuicao;
            SegredoJustica = segredoJustica;
            PastaFisicaCliente = pastaFisicaCliente;
            Descricao = descricao;
            SituacaoID = situacao.ID;
            ProcessoPaiID = processoPaiID;
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
            ValidResponsaveis(responsaveis);
            return responsaveis.Select(a => ProcessoResponsavel.Create(id, a.ID)).ToList();
        }
        private void ValidResponsaveis(IEnumerable<Responsavel> responsaveis)
        {
            if (!(responsaveis.Any() == true))
                throw new ProcessoResponsavelIsRequiredException();
            var maxResponsaveis = 3;
            if (responsaveis.Count() > maxResponsaveis)
                throw new ProcessoResponsavelMaxLengthException(maxResponsaveis);
            if (responsaveis.Select(a => a.ID).Distinct().Count() != responsaveis.Count())
                throw new ProcessoResponsavelDuplicatedException();
        }
    }
}
