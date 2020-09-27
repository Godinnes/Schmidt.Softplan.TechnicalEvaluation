﻿using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Schmidt.Softplan.TechnicalEvaluation.Common.ValueObjects;
using Schmidt.Softplan.TechnicalEvaluation.Query.Application.Query.Processos;
using Schmidt.Softplan.TechnicalEvaluation.Query.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Query.Model.Model;
using Schmidt.Softplan.TechnicalEvaluation.SpecFlow.Drivers;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Schmidt.Softplan.TechnicalEvaluation.SpecFlow.Steps
{
    [Binding]
    [Scope(Tag = "ProcessosQuery")]
    public class ProcessosQueryStepsFeature : QueryBase
    {
        public ProcessosQueryStepsFeature(ScenarioContext scenarioContext)
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

            var context = ServiceProvider.GetRequiredService<SchmidtQueryContext>();

            foreach (var situacao in situacoes)
            {
                var newSituacao = new Situacao();
                newSituacao.ID = Guid.NewGuid();
                newSituacao.Nome = situacao.Nome;
                newSituacao.Finalizado = situacao.Finalizado;
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

            var context = ServiceProvider.GetRequiredService<SchmidtQueryContext>();

            foreach (var responsavel in responsaveis)
            {
                var newResponsavel = new Responsavel();
                newResponsavel.ID = Guid.NewGuid();
                newResponsavel.Nome = responsavel.Nome;
                newResponsavel.CPF = responsavel.CPF;
                newResponsavel.Email = responsavel.Email;
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
                    Pasta: p.GetString("Pasta"),
                    Responsaveis: p.GetString("Responsaveis").Split(',').Select(a => a.Trim()).ToList())
                ).ToList();

            var context = ServiceProvider.GetRequiredService<SchmidtQueryContext>();

            var responsaveisNomes = processos.SelectMany(i => i.Responsaveis).ToList();
            var responsaveis = context.Set<Responsavel>().Where(a => responsaveisNomes.Contains(a.Nome)).ToList();
            var situacoes = context.Set<Situacao>().Where(a => processos.Select(i => i.Situacao).Contains(a.Nome));

            foreach (var processo in processos)
            {
                var newProcesso = new Processo();
                newProcesso.ID = Guid.NewGuid();
                newProcesso.NumeroProcessoUnificado = processo.NumeroProcessoUnificado;
                newProcesso.Descricao = processo.Descricao;
                newProcesso.Distribuicao = processo.Distribuicao;
                newProcesso.SegredoJustica = processo.SegredoJustica;
                newProcesso.PastaFisicaCliente = processo.Pasta;
                newProcesso.Situacao = situacoes.First(a => a.Nome == processo.Situacao);
                newProcesso.SituacaoID = newProcesso.Situacao.ID;
                context.Add(newProcesso);

                foreach (var responsavel in responsaveis.Where(i => processo.Responsaveis.Contains(i.Nome)).ToList())
                {
                    var newProcessoResponsavel = new ProcessoResponsavel();
                    newProcessoResponsavel.ResponsavelID = responsavel.ID;
                    newProcessoResponsavel.ProcessoID = newProcesso.ID;
                    context.Add(newProcessoResponsavel);
                }

            }
            context.SaveChanges();
        }
        [Given(@"busca por todos")]
        public async Task GivenBuscaPorTodosAsync()
        {
            var query = new GetProcessosQuery()
            {
            };
            Processos = await Mediator.SendAsync(query);
        }

        [Given(@"busca de '(.*)' a '(.*)'")]
        public async Task GivenBuscaPaginadaAsync(int skip, int take)
        {
            var query = new GetProcessosQuery()
            {
                Skip = skip,
                Take = take
            };
            var processos = Processos.ToList();
            processos.AddRange(await Mediator.SendAsync(query));
            Processos = processos;
        }


        [Given(@"busca pelo número processo unificado '(.*)'")]
        public async Task GivenBuscaPeloNumeroProcessoUnificadoAsync(string numeroProcessoUnificado)
        {
            var query = new GetProcessosQuery()
            {
                NumeroProcessoUnificado = numeroProcessoUnificado,
            };
            Processos = await Mediator.SendAsync(query);
        }

        [Given(@"busca pelo período de distribuição '(.*)' e '(.*)'")]
        public async Task GivenBuscaPeloPeriodoDeDistribuicaoAsync(string dataInicial, string dataFinal)
        {
            var query = new GetProcessosQuery()
            {
                InicioDistribuicao = TryParseDateTime(dataInicial),
                FimDistribuicao = TryParseDateTime(dataFinal)
            };
            Processos = await Mediator.SendAsync(query);
        }

        [Given(@"busca por parte da pasta física cliente '(.*)'")]
        public async Task GivenBuscaPorParteDaPastaFisicaClienteAsync(string pastaPessoaFisicaCliente)
        {
            var query = new GetProcessosQuery()
            {
                PastaFisicaCliente = pastaPessoaFisicaCliente,
            };
            Processos = await Mediator.SendAsync(query);
        }

        [Given(@"busco pela situação '(.*)'")]
        public async Task GivenBuscoPelaSituacaoAsync(string situacao)
        {
            var context = ServiceProvider.GetRequiredService<SchmidtQueryContext>();
            var situacaoEntity = context.Set<Situacao>().First(a => a.Nome == situacao);
            var query = new GetProcessosQuery()
            {
                SituacaoID = situacaoEntity.ID
            };
            Processos = await Mediator.SendAsync(query);
        }

        [Given(@"busca pelo responsável '(.*)'")]
        public async Task GivenBuscaPeloResponsavelAsync(string responsavel)
        {
            var query = new GetProcessosQuery()
            {
                Responsavel = responsavel
            };
            Processos = await Mediator.SendAsync(query);
        }


        [Then(@"possuo (.*) processos")]
        public void ThenProcessos(int quantity)
        {
            Assert.AreEqual(quantity, Processos.Count());
        }

    }
}
