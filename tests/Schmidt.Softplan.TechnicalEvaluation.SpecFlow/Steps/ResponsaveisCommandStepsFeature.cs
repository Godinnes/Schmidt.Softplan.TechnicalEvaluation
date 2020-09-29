using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Schmidt.Softplan.TechnicalEvaluation.Application.Command.Responsaveis;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.SpecFlow.Drivers;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Schmidt.Softplan.TechnicalEvaluation.SpecFlow.Steps
{
    [Binding]
    [Scope(Tag = "ResponsaveisCommand")]
    public class ResponsaveisCommandStepsFeature : CommandBase
    {
        public ResponsaveisCommandStepsFeature(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
        }

        [Given(@"a responsavel '(.*)', CPF '(.*)', Email '(.*)'")]
        public async Task GivenResponsavel(string nome, string cpf, string email)
        {
            var command = new CreateResponsavelCommand()
            {
                Nome = nome,
                CPF = cpf,
                Email = email
            };

            try
            {
                ResponsavelID = await Mediator.SendAsync(command);
            }
            catch (Exception ex)
            {
                AddException(ex);
            }
        }

        [Then(@"I have a responsavel")]
        public async Task ThenIHaveAResponsavel()
        {
            var repository = ServiceProvider.GetRequiredService<IResponsavelRepository>();
            var responsavel = await repository.FindAsync(ResponsavelID);
            Assert.NotNull(responsavel);
        }

        [Then(@"I have a exception '(.*)'")]
        public void ThenIHaveAException(string message)
        {
            Assert.AreEqual(message, ExpectedExceptions.First().Message);
        }
    }
}

