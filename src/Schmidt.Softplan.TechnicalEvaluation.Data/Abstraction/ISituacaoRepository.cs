using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;
using System;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction
{
    public interface ISituacaoRepository
    {
        Task<Situacao> FindAsync(Guid id);
    }
}
