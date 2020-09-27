using Microsoft.Extensions.DependencyInjection;
using Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Schmidt.Softplan.TechnicalEvaluation.Data.Seeder
{
    public static class InitializeContext
    {
        public static void Seed(this IServiceProvider services)
        {
            var context = services.CreateScope().ServiceProvider.GetRequiredService<SchmidtContext>();
            context.Database.EnsureCreated();
            if (context.Set<Situacao>().Where(a => true).Any())
                return;

            var situacoes = new List<Situacao>();
            situacoes.Add(Situacao.Create("Em andamento", false));
            situacoes.Add(Situacao.Create("Desmembrado", false));
            situacoes.Add(Situacao.Create("Em recurso", false));
            situacoes.Add(Situacao.Create("Finalizado", true));
            situacoes.Add(Situacao.Create("Arquivado", true));
            context.Set<Situacao>().AddRange(situacoes);
            context.SaveChanges();
        }
    }
}
