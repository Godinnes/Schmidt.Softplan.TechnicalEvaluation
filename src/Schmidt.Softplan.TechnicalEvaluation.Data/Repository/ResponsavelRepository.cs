using Microsoft.EntityFrameworkCore;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Data.Context;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Data.Repository
{
    public class ResponsavelRepository : SchmidtDbContext<Responsavel>, IResponsavelRepository
    {
        public ResponsavelRepository(SchmidtContext context,
                                     IServiceProvider serviceProvider)
            : base(context, serviceProvider)
        {
        }
        public async Task<IEnumerable<Responsavel>> GetResponsaveisByIDsAync(IEnumerable<Guid> ids)
        {
            return await Entity
                .Where(r => ids.Contains(r.ID))
                .ToListAsync();
        }
        public bool ExistsCPF(Guid id, string cpf)
        {
            return Entity.Any(r => r.ID != id && r.CPF == cpf);
        }
    }
}
