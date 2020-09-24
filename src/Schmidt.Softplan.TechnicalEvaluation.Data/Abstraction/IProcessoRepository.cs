using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;
using System;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction
{
    public interface IProcessoRepository
    {
        Task<Processo> FindAsync(Guid id);
        void Add(Processo processo);
        void Remove(Processo processo);
        Task SaveChangesAsync();
        bool HasNumeroProcessoUnificado(string numeroProcessoUnificado);
    }
}
