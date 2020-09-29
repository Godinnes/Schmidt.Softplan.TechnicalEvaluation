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
        bool HasNumeroProcessoUnificado(Guid id, string numeroProcessoUnificado);
        Task<Processo> FindChildAsync(Guid id);
        Task<bool> HasChildAsync(Guid id);
        Task<bool> HasProcessoParentVinculedAsync(Guid id, Guid parentID);
    }
}
