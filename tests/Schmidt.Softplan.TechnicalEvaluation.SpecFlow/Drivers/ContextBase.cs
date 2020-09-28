using Microsoft.Extensions.DependencyInjection;
using Schmidt.Softplan.TechnicalEvaluation.Mediator.Interfaces;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.ViewModel;
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
            if (DateTime.TryParseExact(dateString, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out var dateResult))
                return dateResult;
            return null;
        }
        public Guid? TryParseGuid(string guid)
        {
            if (Guid.TryParse(guid, out var parsedGuid))
                return parsedGuid;
            return null;
        }
        public bool ParseSimNao(string value) => value?.ToLower() == "sim";
        public bool? TryParseSimNao(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;
            return ParseSimNao(value);
        }

        public IEnumerable<ResponsavelQueryViewModel> Responsaveis
        {
            get
            {
                if (ScenarioContext.TryGetValue<IEnumerable<ResponsavelQueryViewModel>>(nameof(Responsaveis), out var responsaveis))
                    return responsaveis;
                return new List<ResponsavelQueryViewModel>();
            }
            set { ScenarioContext.Set(value, nameof(Responsaveis)); }
        }
        public IEnumerable<ProcessoQueryViewModel> ProcessosQueryViewModel
        {
            get
            {
                if (ScenarioContext.TryGetValue<IEnumerable<ProcessoQueryViewModel>>(nameof(ProcessosQueryViewModel), out var processos))
                    return processos;
                return new List<ProcessoQueryViewModel>();
            }
            set { ScenarioContext.Set(value, nameof(ProcessosQueryViewModel)); }
        }
        public ProcessoViewModel ProcessoViewModel
        {
            get
            {
                if (ScenarioContext.TryGetValue<ProcessoViewModel>(nameof(ProcessoViewModel), out var processo))
                    return processo;
                return null;
            }
            set { ScenarioContext.Set(value, nameof(ProcessoViewModel)); }
        }
        public Guid ResponsavelID
        {
            get { return ScenarioContext.Get<Guid>(nameof(ResponsavelID)); }
            set { ScenarioContext.Set(value, nameof(ResponsavelID)); }
        }
        public Guid ProcessoID
        {
            get { return ScenarioContext.Get<Guid>(nameof(ProcessoID)); }
            set { ScenarioContext.Set(value, nameof(ProcessoID)); }
        }
        public int NumberEmailSended
        {
            get { return ScenarioContext.Get<int>(nameof(NumberEmailSended)); }
            set { ScenarioContext.Set(value, nameof(NumberEmailSended)); }
        }
    }
}
