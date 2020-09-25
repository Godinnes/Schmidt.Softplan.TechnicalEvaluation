using System;
using TechTalk.SpecFlow;

namespace Schmidt.SoftplanTechnicalEvaluation.Specs.Reponsaveis
{
    public class ResponsaveisBase : Base
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
