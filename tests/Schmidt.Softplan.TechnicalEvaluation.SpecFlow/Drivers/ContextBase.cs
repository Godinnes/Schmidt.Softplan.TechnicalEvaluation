using Microsoft.Extensions.DependencyInjection;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Schmidt.Softplan.TechnicalEvaluation.SpecFlow.Drivers
{
    public class ContextBase
    {
        protected readonly ScenarioContext ScenarioContext;
        public ContextBase(ScenarioContext scenarioContext)
        {
            ScenarioContext = scenarioContext;
        }

        public ServiceProvider ServiceProvider
        {
            get { return ScenarioContext.Get<ServiceProvider>(nameof(ServiceProvider)); }
            set { ScenarioContext.Set(value, nameof(ServiceProvider)); }
        }
        public ISchmidtMediator Mediator => ServiceProvider.GetRequiredService<ISchmidtMediator>();
        public IEnumerable<Exception> ExpectedExceptions
        {
            get
            {
                if (ScenarioContext.TryGetValue<IEnumerable<Exception>>(nameof(ExpectedExceptions), out var expectedExceptions))
                    return expectedExceptions;
                return new List<Exception>();
            }
            set { ScenarioContext.Set(value, nameof(ExpectedExceptions)); }
        }
        public void AddException(Exception ex)
        {
            var exceptions = ExpectedExceptions.ToList();
            exceptions.Add(ex);
            ExpectedExceptions = exceptions;
        }
        public DateTime? TryParseDateTime(string dateString)
        {
            var dateResult = DateTime.Now;
            if (DateTime.TryParse(dateString, out dateResult))
                return dateResult;
            return null;
        }
        public bool ParseSimNao(string value) => value?.ToLower() == "sim";
    }
}
