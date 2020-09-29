using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Schmidt.Softplan.TechnicalEvaluation.Application.Command.Processos;
using Schmidt.Softplan.TechnicalEvaluation.Common.ValueObjects;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;
using Schmidt.Softplan.TechnicalEvaluation.SpecFlow.Drivers;
using System;
using System.Collections.Generic;
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

        [Given(@"a processo número '(.*)', descrição '(.*)', Situacao '(.*)', Responsáveis '(.*)', Pasta do cliente '(.*)', data de distribuição '(.*)' e Segredo de justiça '(.*)'")]
        public async Task GivenProcessoAsync(string numeroProcessoUnificado, string descricao, string situacao, string responsaveis, string pastaCliente, string distribuicao, string segredo)
        {
            var context = ServiceProvider.GetRequiredService<SchmidtContext>();
            var situacaoEntity = context.Set<Situacao>().Where(a => a.Nome == situacao).FirstOrDefault();
            var responsaveisNomes = responsaveis.Split(',').Select(a => a.Trim()).ToList();
            var responsaveisEntity = new List<Responsavel>();
            foreach (var responsavelNome in responsaveisNomes)
            {
                if (string.IsNullOrWhiteSpace(responsavelNome))
                    continue;
                var responsavel = context.Set<Responsavel>().Where(a => a.Nome == responsavelNome).First();
                responsaveisEntity.Add(responsavel);
            }

            var command = new CreateProcessoCommand()
            {
                NumeroProcessoUnificado = numeroProcessoUnificado,
                Descricao = descricao,
                SegredoJustica = ParseSimNao(segredo),
                SituacaoID = situacaoEntity?.ID ?? Guid.Empty,
                Responsaveis = responsaveisEntity.Select(a => a.ID),
                PastaFisicaCliente = pastaCliente,
                Distribuicao = TryParseDateTime(distribuicao)
            };
            try
            {
                ProcessoID = await Mediator.SendAsync(command);
            }
            catch (Exception ex)
            {
                AddException(ex);
            }
        }

        [Given(@"a processo número '(.*)', descrição '(.*)', Situacao '(.*)', Responsáveis '(.*)', Pasta do cliente '(.*)', data de distribuição '(.*)', Segredo de justiça '(.*)' e processo pai '(.*)'")]
        public async Task GivenProcessoParentAsync(string numeroProcessoUnificado, string descricao, string situacao, string responsaveis, string pastaCliente, string distribuicao, string segredo, string numeroProcessoPai)
        {
            var context = ServiceProvider.GetRequiredService<SchmidtContext>();
            var situacaoEntity = context.Set<Situacao>().Where(a => a.Nome == situacao).FirstOrDefault();
            var processoPaiID = context.Set<Processo>().Where(a => a.NumeroProcessoUnificado == new NumeroProcessoUnificadoValueObject(numeroProcessoPai).Value).Select(a => a.ID).First();
            var responsaveisNomes = responsaveis.Split(',').Select(a => a.Trim()).ToList();
            var responsaveisEntity = new List<Responsavel>();
            foreach (var responsavelNome in responsaveisNomes)
            {
                if (string.IsNullOrWhiteSpace(responsavelNome))
                    continue;
                var responsavel = context.Set<Responsavel>().Where(a => a.Nome == responsavelNome).First();
                responsaveisEntity.Add(responsavel);
            }

            var command = new CreateProcessoCommand()
            {
                NumeroProcessoUnificado = numeroProcessoUnificado,
                Descricao = descricao,
                SegredoJustica = ParseSimNao(segredo),
                SituacaoID = situacaoEntity?.ID ?? Guid.Empty,
                Responsaveis = responsaveisEntity.Select(a => a.ID),
                PastaFisicaCliente = pastaCliente,
                Distribuicao = TryParseDateTime(distribuicao),
                ProcessoPaiID = processoPaiID
            };
            try
            {
                ProcessoID = await Mediator.SendAsync(command);
            }
            catch (Exception ex)
            {
                AddException(ex);
            }
        }

        [When(@"atualizo o processo número '(.*)', descrição '(.*)', Situacao '(.*)', Responsáveis '(.*)', Pasta do cliente '(.*)', data de distribuição '(.*)' e Segredo de justiça '(.*)'")]
        public async Task WhenAtualizoAsync(string numeroProcessoUnificado, string descricao, string situacao, string responsaveis, string pastaCliente, string distribuicao, string segredo)
        {
            var context = ServiceProvider.GetRequiredService<SchmidtContext>();
            var situacaoEntity = context.Set<Situacao>().Where(a => a.Nome == situacao).FirstOrDefault();
            var responsaveisNomes = responsaveis.Split(',').Select(a => a.Trim()).ToList();
            var responsaveisEntity = new List<Responsavel>();
            foreach (var responsavelNome in responsaveisNomes)
            {
                if (string.IsNullOrWhiteSpace(responsavelNome))
                    continue;
                var responsavel = context.Set<Responsavel>().Where(a => a.Nome == responsavelNome).First();
                responsaveisEntity.Add(responsavel);
            }

            var command = new ChangeProcessoCommand()
            {
                ID = ProcessoID,
                NumeroProcessoUnificado = numeroProcessoUnificado,
                Descricao = descricao,
                SegredoJustica = ParseSimNao(segredo),
                SituacaoID = situacaoEntity?.ID ?? Guid.Empty,
                Responsaveis = responsaveisEntity.Select(a => a.ID),
                PastaFisicaCliente = pastaCliente,
                Distribuicao = TryParseDateTime(distribuicao)
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

        [When(@"eu removo o processo '(.*)'")]
        public async Task WhenRemoveProcessoAsync(string numeroProcesso)
        {
            var context = ServiceProvider.GetRequiredService<SchmidtContext>();
            var processoID = context.Set<Processo>().Where(a => a.NumeroProcessoUnificado == new NumeroProcessoUnificadoValueObject(numeroProcesso).Value).Select(a => a.ID).First();
            var command = new RemoveProcessoCommand()
            {
                ID = processoID
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

        [Then(@"possuo um processo")]
        public void ThenPossuoUmProcesso()
        {
            var context = ServiceProvider.GetRequiredService<SchmidtContext>();
            var processo = context.Set<Processo>().Find(ProcessoID);
            Assert.NotNull(processo);
        }

        [Then(@"processo '(.*)' foi removido")]
        public void ThenProcessoFoiRemovido(string numeroProcesso)
        {
            var context = ServiceProvider.GetRequiredService<SchmidtContext>();
            var processo = context.Set<Processo>().FirstOrDefault(a => a.NumeroProcessoUnificado == new NumeroProcessoUnificadoValueObject(numeroProcesso).Value);
            Assert.IsNull(processo);
        }

        [Then(@"I have a exception '(.*)'")]
        public void ThenException(string message)
        {
            Assert.AreEqual(message, ExpectedExceptions.First().Message);
        }

        [Then(@"I sended (.*) e-mails")]
        public void ThenISendedE_Mails(int quantityEmails)
        {
            Assert.AreEqual(quantityEmails, NumberEmailSended);
        }
    }
}
