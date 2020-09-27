using Schmidt.Softplan.TechnicalEvaluation.Mediator.Interfaces;
using System.Collections.Generic;

namespace Schmidt.Softplan.TechnicalEvaluation.Domain.Abstraction
{
    public class Entity
    {
        private List<IDomainEvent> _eventsBefore = new List<IDomainEvent>();
        private List<IDomainEvent> _eventsAfter = new List<IDomainEvent>();
        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _eventsBefore.Add(domainEvent);
        }
        public void AddAfterDomainEvent(IDomainEvent domainEvent)
        {
            _eventsAfter.Add(domainEvent);
        }
        public IEnumerable<IDomainEvent> BeforeEvents => _eventsBefore;
        public IEnumerable<IDomainEvent> AfterEvents => _eventsAfter;
        public void ClearEvents()
        {
            _eventsBefore.Clear();
            _eventsAfter.Clear();
        }
    }
}
