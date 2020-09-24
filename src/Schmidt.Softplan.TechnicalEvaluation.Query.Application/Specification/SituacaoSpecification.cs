using Schmidt.Softplan.TechnicalEvaluation.Query.Model.Model;
using System;
using System.Linq.Expressions;

namespace Schmidt.Softplan.TechnicalEvaluation.Query.Application.Specification
{
    public static class SituacaoSpecification
    {
        public static Expression<Func<Situacao, bool>> SituacaoNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return p => true;

            return p => p.Nome.ToLower().Contains(nome.ToLower());
        }
    }
}
