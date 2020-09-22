using Microsoft.EntityFrameworkCore;
using Schmidt.Softplan.TechnicalEvaluation.Domain.Entity;

namespace Schmidt.Softplan.TechnicalEvaluation.Data.Abstraction
{
    public class SchmidtContext : DbContext
    {
        public SchmidtContext(DbContextOptions<SchmidtContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Processo>(build =>
            {
                build.ToTable("Processos");
                build.HasKey(k => k.ID);
                build.HasMany<Responsavel>();
                build.HasOne<Situacao>().WithMany();
            });
            modelBuilder.Entity<Responsavel>(build =>
            {
                build.ToTable("Responsaveis");
                build.HasKey(k => k.ID);
                build.HasMany<Processo>();
            });
            modelBuilder.Entity<Situacao>(build =>
            {
                build.ToTable("Situacoes");
                build.HasKey(k => k.ID);
                build.HasMany<Processo>().WithOne();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
