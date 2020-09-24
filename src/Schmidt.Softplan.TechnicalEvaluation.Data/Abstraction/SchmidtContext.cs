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
            modelBuilder.Entity<ProcessoResponsavel>(build =>
            {
                build.HasKey(k => new { k.ProcessoID, k.ResponsavelID });
                build.HasOne<Processo>().WithMany().HasForeignKey(a => a.ProcessoID);
                build.HasOne<Responsavel>().WithMany().HasForeignKey(a => a.ResponsavelID);
            });

            modelBuilder.Entity<Processo>(build =>
            {
                build.ToTable("Processos");
                build.HasKey(k => k.ID);
                build.HasOne<Situacao>();
                build.HasMany(p => p.Responsaveis);
            });
            modelBuilder.Entity<Responsavel>(build =>
            {
                build.ToTable("Responsaveis");
                build.HasKey(k => k.ID);
                build.Property(p => p.CPF).IsRequired().HasMaxLength(11);
                build.HasMany(p => p.Processos);
            });
            modelBuilder.Entity<Situacao>(build =>
            {
                build.ToTable("Situacoes");
                build.HasKey(k => k.ID);
                build.HasMany<Processo>().WithOne().HasForeignKey(p => p.SituationID);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
