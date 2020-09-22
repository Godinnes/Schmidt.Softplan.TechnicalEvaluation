using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Data.Context;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;
using System;
using System.Linq;

namespace Schmidt.Softplan.TechnicalEvaluation.Data.Repository
{
    public class ProcessoRepository : SchmidtDbContext<Processo>, IProcessoRepository
    {
        public ProcessoRepository(SchmidtContext context,
                                  IServiceProvider serviceProvider)
            : base(context, serviceProvider)
        {
        }
        public bool HasNumeroProcessoUnificado(string numeroProcessoUnificado)
        {
            var exists = Entity.Any(p => p.NumeroProcessoUnificado == numeroProcessoUnificado);
            return exists;
        }
    }
}
