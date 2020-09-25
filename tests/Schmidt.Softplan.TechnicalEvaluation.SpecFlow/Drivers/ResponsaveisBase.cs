using System;
using TechTalk.SpecFlow;

namespace Schmidt.Softplan.TechnicalEvaluation.SpecFlow.Drivers
{
    public class ResponsaveisBase : ContextBase
    {
        public ResponsaveisBase(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
        }
        public Guid ResponsavelID
        {
            get { return ScenarioContext.Get<Guid>(nameof(ResponsavelID)); }
            set { ScenarioContext.Set(value, nameof(ResponsavelID)); }
        }
    }
}
