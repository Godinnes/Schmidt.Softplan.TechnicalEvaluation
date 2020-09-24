using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Data.Context;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;
using System;

namespace Schmidt.Softplan.TechnicalEvaluation.Data.Repository
{
    public class ResponsavelRepository : SchmidtDbContext<Responsavel>, IResponsavelRepository
    {
        public ResponsavelRepository(SchmidtContext context,
                                     IServiceProvider serviceProvider)
            : base(context, serviceProvider)
        {
        }
    }
}
