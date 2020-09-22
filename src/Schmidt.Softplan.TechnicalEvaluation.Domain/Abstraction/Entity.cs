using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction
{
    public class Entity
    {
        public IEnumerable<IDomainEvent> Events { get; private set; }
        public Guid ID { get; protected set; }
        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            var events = Events?.ToList() ?? new List<IDomainEvent>();
            events.Add(domainEvent);
            Events = events;
        }
    }
}
