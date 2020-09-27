using Microsoft.EntityFrameworkCore.Internal;
using Schmidt.Softplan.TechnicalEvaluation.Common.ValueObjects;
using Schmidt.Softplan.TechnicalEvaluation.Query.Model.Model;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Schmidt.Softplan.TechnicalEvaluation.Query.Application.Specification
{
    public static class ProcessoSpecification
    {
        public static Expression<Func<Processo, bool>> ProcessoDestribuicaoBetween(DateTime? inicio, DateTime? fim)
        {
            if (!inicio.HasValue && !fim.HasValue)
                return p => true;

            return p => (!inicio.HasValue || p.Distribuicao >= inicio.Value) &&
                        (!fim.HasValue || p.Distribuicao <= fim.Value);
        }
        public static Expression<Func<Processo, bool>> ProcessoNumeroProcessoUnificado(string numeroProcessoUnificado)
        {
            if (string.IsNullOrEmpty(numeroProcessoUnificado))
                return p => true;
            var numberWithoutDots = new NumeroProcessoUnificadoValueObject(numeroProcessoUnificado).Value;

            return p => numberWithoutDots == p.NumeroProcessoUnificado;
        }
        public static Expression<Func<Processo, bool>> ProcessoPastaFisicaPessoa(string pastaFisicaPessoa)
        {
            if (string.IsNullOrEmpty(pastaFisicaPessoa))
                return p => true;

            return p => p.PastaFisicaCliente.Contains(pastaFisicaPessoa);
        }
        public static Expression<Func<Processo, bool>> ProcessoSituacao(Guid? situationID)
        {
            if (!situationID.HasValue || situationID == Guid.Empty)
                return p => true;

            return p => situationID.Value == p.Situacao.ID;
        }
        public static Expression<Func<Processo, bool>> ProcessoResponsavel(string responsavel)
        {
            if (string.IsNullOrEmpty(responsavel))
                return p => true;

            return p => p.ProcessoResponsaveis.Any(r => r.Responsavel.Nome.ToLower().Contains(responsavel.ToLower()));
        }
        public static Expression<Func<Processo, bool>> ProcessoSegredoJustica(bool segredoJustica)
        {
            if (!segredoJustica)
                return p => true;

            return p => p.SegredoJustica == segredoJustica;
        }
        public static Expression<Func<Processo, bool>> ProcessoDescricao(string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
                return p => true;

            return p => p.Descricao.ToLower().Contains(descricao.ToLower());
        }
    }
}
