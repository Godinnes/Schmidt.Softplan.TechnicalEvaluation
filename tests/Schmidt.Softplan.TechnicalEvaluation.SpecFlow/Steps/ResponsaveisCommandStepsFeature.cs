using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Schmidt.Softplan.TechnicalEvaluation.Application.Command.Processos;
using Schmidt.Softplan.TechnicalEvaluation.Application.Command.Responsaveis;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;
using Schmidt.Softplan.TechnicalEvaluation.SpecFlow.Drivers;
using System;
using System.Collections.Generic;
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
        [Given(@"vinculo um processo")]
        public async Task GivenVinculoUmProcessoAsync()
        {
            var context = ServiceProvider.GetRequiredService<SchmidtContext>();
            var situacao = Situacao.Create("Em andamento", false);
            context.Add(situacao);
            context.SaveChanges();

            var command = new CreateProcessoCommand()
            {
                NumeroProcessoUnificado = "3513042-04.2016.8.19.0423",
                Descricao = "remoção de responsável",
                Responsaveis = new List<Guid>() { ResponsavelID },
                SituacaoID = situacao.ID
            };
            await Mediator.SendAsync(command);
        }

        [When(@"removo o responsável")]
        public async Task WhenRemovoOResponsavelAsync()
        {
            var command = new RemoveResponsavelCommand()
            {
                ID = ResponsavelID
            };
            try
            {
                await Mediator.SendAsync(command);
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

