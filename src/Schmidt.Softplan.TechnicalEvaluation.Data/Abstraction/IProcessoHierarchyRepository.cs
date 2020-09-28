using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction
{
    public interface IProcessoHierarchyRepository
    {
        Task<IEnumerable<Guid>> ProcessosFamilyAsync(Guid id);
    }
}
