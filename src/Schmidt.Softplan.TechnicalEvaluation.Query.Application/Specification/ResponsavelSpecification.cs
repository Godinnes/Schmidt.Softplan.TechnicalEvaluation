using Schmidt.Softplan.TechnicalEvaluation.Common.ValueObjects;
using Schmidt.Softplan.TechnicalEvaluation.Query.Model.Model;
using System;
using System.Linq.Expressions;

namespace Schmidt.Softplan.TechnicalEvaluation.Query.Application.Specification
{
    public static class ResponsavelSpecification
    {
        public static Expression<Func<Responsavel, bool>> ResponsavelNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return p => true;

            return p => p.Nome.ToLower().Contains(nome.ToLower());
        }
        public static Expression<Func<Responsavel, bool>> ResponsavelCPF(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return p => true;
            var clearCPF = new CPFValueObject(cpf).Value;
            return p => p.CPF == clearCPF;
        }
        public static Expression<Func<Responsavel, bool>> ResponsavelNumeroProcessoUnificado(string numeroProcessoUnificado)
        {
            if (string.IsNullOrWhiteSpace(numeroProcessoUnificado))
                return p => true;

            return p => true;
        }
    }
}
