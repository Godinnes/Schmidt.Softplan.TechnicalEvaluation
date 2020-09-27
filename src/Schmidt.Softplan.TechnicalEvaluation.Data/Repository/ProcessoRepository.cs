using Microsoft.EntityFrameworkCore;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Data.Context;
using Schmidt.Softplan.TechnicalEvaluation.Domain.DomainEvents.Processos;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Data.Repository
{
    public class ProcessoRepository : SchmidtDbContext<Processo>, IProcessoRepository
    {
        public ProcessoRepository(SchmidtContext context,
                                  IServiceProvider serviceProvider)
            : base(context, serviceProvider)
        {
        }

        public override void Remove(Processo entity)
        {
            entity.AddDomainEvent(new RemoveProcessoDomainEvent(entity));
            base.Remove(entity);
        }
        public bool HasNumeroProcessoUnificado(Guid id, string numeroProcessoUnificado)
        {
            var exists = Entity.Any(p => p.ID != id && p.NumeroProcessoUnificado == numeroProcessoUnificado);
            return exists;
        }
        public async Task<Processo> FindChildAsync(Guid id)
        {
            return await Entity.FirstOrDefaultAsync(a => a.ProcessoPaiID == id);
        }
        public async Task<bool> HasChildAsync(Guid id)
        {
            return await Entity.AnyAsync(a => a.ProcessoPaiID == id);
        }
    }
}
