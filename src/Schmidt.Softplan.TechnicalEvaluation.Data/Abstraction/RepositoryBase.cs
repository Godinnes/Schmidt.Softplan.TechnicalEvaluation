using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction
{
    public abstract class RepositoryBase<TEntity>
        where TEntity : Entity
    {
        private List<IDomainEvent> BeforeDomainEvents;
        private readonly ISchmidtMediator _mediator;
        protected readonly DbContext Context;
        public RepositoryBase(DbContext context,
                              IServiceProvider serviceProvider)
        {
            Context = context;

            Entity = context.Set<TEntity>();

            _mediator = serviceProvider.GetRequiredService<ISchmidtMediator>();
            BeforeDomainEvents = new List<IDomainEvent>();
        }
        public DbSet<TEntity> Entity { get; private set; }
        public async virtual Task<TEntity> FindAsync(Guid id)
        {
            return await Entity.FindAsync(id);
        }
        public virtual void Add(TEntity entity)
        {
            Entity.Add(entity);
        }
        public virtual void Remove(TEntity entity)
        {
            Entity.Remove(entity);
        }
        public async virtual Task SaveChangesAsync()
        {
            foreach (var domainEvent in BeforeDomainEvents)
            {
                await _mediator.SendAsync(domainEvent);
            }

            await Context.SaveChangesAsync();
        }
    }
}
