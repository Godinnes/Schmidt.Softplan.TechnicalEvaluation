using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Query.Data.Abstraction
{
    public interface IProcessoHierarchyQueryRepository
    {
        Task<IEnumerable<Guid>> ProcessosFamilyAsync(Guid id);
    }
}
