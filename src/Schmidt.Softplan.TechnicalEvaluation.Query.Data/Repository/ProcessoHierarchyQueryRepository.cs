using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Schmidt.Softplan.TechnicalEvaluation.Common.SqlQueries;
using Schmidt.Softplan.TechnicalEvaluation.Query.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Query.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Query.Data.Repository
{
    public class ProcessoHierarchyQueryRepository : IProcessoHierarchyQueryRepository
    {
        private readonly SchmidtQueryContext _context;
        public ProcessoHierarchyQueryRepository(SchmidtQueryContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Guid>> ProcessosFamilyAsync(Guid id)
        {
            var processoID = new SqliteParameter("@processoID", id);

            return await _context.Set<Processo>()
                .FromSqlRaw(ProcessoHierarchy.ProcessosFilhos, processoID)
                .Select(a => a.ID)
                .ToListAsync();
        }
    }
}
