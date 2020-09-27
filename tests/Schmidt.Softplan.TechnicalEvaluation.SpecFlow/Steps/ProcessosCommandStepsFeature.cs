using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Schmidt.Softplan.TechnicalEvaluation.Application.Command.Processos;
using Schmidt.Softplan.TechnicalEvaluation.Common.ValueObjects;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;
using Schmidt.Softplan.TechnicalEvaluation.SpecFlow.Drivers;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Schmidt.Softplan.TechnicalEvaluation.SpecFlow.Steps
{

    [Binding]
    [Scope(Tag = "ProcessosCommand")]
    public class ProcessosCommandStepsFeature : CommandBase
    {
        public ProcessosCommandStepsFeature(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
        }
        [Given(@"The follow situacões")]
        public void GiveSituacoes(Table table)
        {
            var situacoes = table.Rows
                .Select(p => (
                    Nome: p.GetString("Nome"),
                    Finalizado: ParseSimNao(p.GetString("Finalizado"))
                )).ToList();

            var context = ServiceProvider.GetRequiredService<SchmidtContext>();

            foreach (var situacao in situacoes)
            {
                var newSituacao = Situacao.Create(situacao.Nome,
                                                  situacao.Finalizado);
                context.Add(newSituacao);
            }
            context.SaveChanges();
        }
        [Given(@"The follow responsáveis")]
        public void GivenResponsaveis(Table table)
        {
            var responsaveis = table.Rows
                .Select(p => (
                    Nome: p.GetString("Nome"),
                    CPF: p.GetString("CPF").Replace(".", "").Replace("-", ""),
                    Email: p.GetString("Email")
                )).ToList();

            var context = ServiceProvider.GetRequiredService<SchmidtContext>();

            foreach (var responsavel in responsaveis)
            {
                var newResponsavel = Responsavel.Create(responsavel.Nome,
                                                       responsavel.CPF,
                                                       responsavel.Email,
                                                       null);
                context.Add(newResponsavel);
            }
            context.SaveChanges();
        }
        [Given(@"The follow processos")]
        public void GivenProcessos(Table table)
        {
            var processos = table.Rows
                .Select(p =>
                    (NumeroProcessoUnificado: new NumeroProcessoUnificadoValueObject(p.GetString("NumeroProcessoUnificado")).Value,
                    Descricao: p.GetString("Descricao"),
                    Distribuicao: TryParseDateTime(p.GetString("Distribuicao")),
                    SegredoJustica: ParseSimNao(p.GetString("SegredoJustica")),
                    Situacao: p.GetString("Situacao"),
                    Responsaveis: p.GetString("Responsaveis").Split(',').Select(a => a.Trim()).ToList())
                ).ToList();

            var context = ServiceProvider.GetRequiredService<SchmidtContext>();

            var responsaveisNomes = processos.SelectMany(i => i.Responsaveis).ToList();
            var responsaveis = context.Set<Responsavel>().Where(a => responsaveisNomes.Contains(a.Nome)).ToList();
            var situacoes = context.Set<Situacao>().Where(a => processos.Select(i => i.Situacao).Contains(a.Nome));

            foreach (var processo in processos)
            {
                var newProcesso = Processo.Create(processo.NumeroProcessoUnificado,
                                                  null,
                                                  null,
                                                  processo.Descricao,
                                                  processo.SegredoJustica,
                                                  situacoes.First(a => a.Nome == processo.Situacao),
                                                  responsaveis,
                                                  null);
                context.Add(newProcesso);
            }
            context.SaveChanges();
        }
        [Given(@"a processo número '(.*)', descrição '(.*)', Situacao '(.*)', Responsáveis '(.*)' e Segredo de justiça '(.*)'")]
        public async Task GivenProcessoAsync(string numeroProcessoUnificado, string descricao, string situacao, string responsaveis, string segredo)
        {
            var context = ServiceProvider.GetRequiredService<SchmidtContext>();
            var situacaoEntity = context.Set<Situacao>().Where(a => a.Nome == situacao).First();
            var responsaveisNomes = responsaveis.Split(',').Select(a => a.Trim()).ToList();
            var responsaveisEntity = context.Set<Responsavel>().Where(a => responsaveisNomes.Contains(a.Nome)).ToList();

            var command = new CreateProcessoCommand()
            {
                NumeroProcessoUnificado = numeroProcessoUnificado,
                Descricao = descricao,
                SegredoJustica = ParseSimNao(segredo),
                SituacaoID = situacaoEntity.ID,
                Responsaveis = responsaveisEntity.Select(a => a.ID)
            };

            ProcessoID = await Mediator.SendAsync(command);
        }

        [Then(@"possuo um processo")]
        public void ThenPossuoUmProcesso()
        {
            var context = ServiceProvider.GetRequiredService<SchmidtContext>();
            var processo = context.Set<Processo>().Find(ProcessoID);
            Assert.NotNull(processo);
        }

    }
}
