using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;
using System;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction
{
    public interface IResponsavelRepository
    {
        Task<Responsavel> FindAsync(Guid id);
        void Add(Responsavel responsavel);
        void Remove(Responsavel responsavel);
        Task SaveChangesAsync();
    }
}
