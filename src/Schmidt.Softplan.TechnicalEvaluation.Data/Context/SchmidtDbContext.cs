using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction;
using System;

namespace Schmidt.Softplan.TechnicalEvaluation.Data.Context
{
    public class SchmidtDbContext<TEntity>
        : RepositoryBase<TEntity> where TEntity : Entity
    {
        public SchmidtDbContext(SchmidtContext context,
                                IServiceProvider serviceProvider)
            : base(context, serviceProvider)
        {
        }
    }
}
