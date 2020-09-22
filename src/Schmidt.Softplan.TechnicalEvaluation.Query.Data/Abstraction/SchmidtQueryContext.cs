using Microsoft.EntityFrameworkCore;
using Schmidt.Softplan.TechnicalEvaluation.Query.Model.Model;

namespace Schmidt.Softplan.TechnicalEvaluation.Query.Data.Abstraction
{
    public class SchmidtQueryContext : DbContext
    {
        public SchmidtQueryContext(DbContextOptions<SchmidtQueryContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Processo>(build =>
            {
                build.ToTable("Processos");
                build.HasKey(k => k.ID);
            });

            modelBuilder.Entity<Responsavel>(build =>
            {
                build.ToTable("Responsaveis");
                build.HasKey(k => k.ID);
            });

            modelBuilder.Entity<Situacao>(build =>
            {
                build.ToTable("Situacoes");
                build.HasKey(k => k.ID);
            });
        }
    }
}
