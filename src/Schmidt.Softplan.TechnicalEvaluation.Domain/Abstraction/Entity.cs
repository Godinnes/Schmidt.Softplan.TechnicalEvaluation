using Schmidt.Softplan.TechnicalEvaluation.Mediator.Interfaces;
using System.Collections.Generic;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction
{
    public class Entity
    {
        private List<IDomainEvent> _events = new List<IDomainEvent>();
        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _events.Add(domainEvent);
        }
        public IEnumerable<IDomainEvent> Events => _events;
    }
}
