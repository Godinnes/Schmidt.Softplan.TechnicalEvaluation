using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction
{
    public abstract class RepositoryBase<TEntity>
        where TEntity : Entity
    {
        private readonly ISchmidtMediator _mediator;
        protected readonly DbContext Context;
        public RepositoryBase(DbContext context,
                              IServiceProvider serviceProvider)
        {
            Context = context;

            Entity = context.Set<TEntity>();

            _mediator = serviceProvider.GetRequiredService<ISchmidtMediator>();
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
            var validationEvents = Context.ChangeTracker.Entries().Select(a => a.Entity as TEntity).Where(e => e?.BeforeEvents?.Any() == true).SelectMany(a => a.BeforeEvents);
            foreach (var domainEvent in validationEvents)
            {
                await _mediator.PublishAsync(domainEvent);
            }

            await Context.SaveChangesAsync();

            var afterEvents = Context.ChangeTracker.Entries().Select(a => a.Entity as TEntity).Where(e => e?.AfterEvents?.Any() == true).SelectMany(a => a.AfterEvents);
            foreach (var domainEvent in afterEvents)
            {
                await _mediator.PublishAsync(domainEvent);
            }
        }
    }
}
