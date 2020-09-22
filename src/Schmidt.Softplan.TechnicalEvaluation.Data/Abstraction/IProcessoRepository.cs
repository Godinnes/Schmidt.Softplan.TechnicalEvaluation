using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;
using System;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction
{
    public interface IProcessoRepository
    {
        Task<Processo> FindAsync(Guid id);
        void Add(Processo person);
        void Remove(Processo person);
        Task SaveChangesAsync();
        bool HasNumeroProcessoUnificado(string numeroProcessoUnificado);
    }
}
