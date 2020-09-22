using Microsoft.EntityFrameworkCore;
using Schmidt.Softplan.TechnicalEvaluation.Query.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Query.Model.Model;
using System.Linq;

namespace Schmidt.Softplan.TechnicalEvaluation.Query.Data.Repository
{
    public class QueryRepository : IQueryRepository
    {
        private readonly SchmidtQueryContext _context;
        public QueryRepository(SchmidtQueryContext context)
        {
            _context = context;
        }
        public IQueryable<Processo> Processos
        {
            get
            {
                return _context.Set<Processo>()
                    .AsNoTracking();
            }
        }
    }
}
