using Schmidt.Softplan.TechnicalEvaluation.Query.Model.Model;
using System.Linq;

namespace Schmidt.Softplan.TechnicalEvaluation.Query.Data.Abstraction
{
    public interface IQueryRepository
    {
        IQueryable<Processo> Processos { get; }
    }
}
