using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Data.Context;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;
using System;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Data.Repository
{
    public class SituacaoRepository : SchmidtDbContext<Situacao>, ISituacaoRepository
    {
        public SituacaoRepository(SchmidtContext context, IServiceProvider serviceProvider)
            : base(context, serviceProvider)
        {
        }
        public async Task<Situacao> FindAsync(Guid id)
        {
            return await Entity.FindAsync(id);
        }
    }
}
