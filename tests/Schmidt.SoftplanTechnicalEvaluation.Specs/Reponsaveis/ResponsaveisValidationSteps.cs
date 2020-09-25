using Microsoft.Extensions.DependencyInjection;
using Schmidt.Softplan.TechnicalEvaluation.Application.Command.Responsaveis;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace Schmidt.SoftplanTechnicalEvaluation.Specs.Reponsaveis
{
    [Binding]
    [Scope(Tag = "Responsavel")]
    public class ResponsaveisValidationSteps : ResponsaveisBase
    {
        public ResponsaveisValidationSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
        }
        [Given(@"a responsavel (.*), CPF (.*), Email (.*)")]
        public async Task GivenResponsavelAsync(string nome, string cpf, string email)
        {
            var command = new CreateResponsavelCommand()
            {
                Nome = nome,
                CPF = cpf,
                Email = email
            };

            ResponsavelID = await Mediator.SendAsync(command);
        }

        [Then(@"I have a responsavel")]
        public async Task ThenIHaveAResponsavel()
        {
            var repository = ServiceProvider.GetRequiredService<IResponsavelRepository>();
            var responsavel = await repository.FindAsync(ResponsavelID);
            Assert.NotNull(responsavel);
        }
    }
}
