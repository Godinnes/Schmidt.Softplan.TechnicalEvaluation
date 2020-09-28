using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Schmidt.Softplan.TechnicalEvaluation.Common.SqlQueries;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Data.Context;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Data.Repository
{
    public class ProcessoHierarchyRepository : SchmidtDbContext<Processo>, IProcessoHierarchyRepository
    {
        public ProcessoHierarchyRepository(SchmidtContext context,
                                  IServiceProvider serviceProvider)
            : base(context, serviceProvider)
        {
        }
        public async Task<IEnumerable<Guid>> ProcessosFamilyAsync(Guid id)
        {
            var processoID = new SqliteParameter("@processoID", id);

            return await Entity
                .FromSqlRaw(ProcessoHierarchy.ProcessosFilhos, processoID)
                .Select(a => a.ID)
                .ToListAsync();
        }
    }
}
