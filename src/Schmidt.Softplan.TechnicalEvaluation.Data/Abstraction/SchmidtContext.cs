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
                build.ToTable("ProcessosResponsaveis");
                build.HasKey(k => new { k.ProcessoID, k.ResponsavelID });
            });

            modelBuilder.Entity<ProcessoResponsavel>()
                .HasOne(a => a.Processo)
                .WithMany().HasForeignKey(a => a.ProcessoID);

            modelBuilder.Entity<ProcessoResponsavel>()
                .HasOne(a => a.Responsavel)
                .WithMany().HasForeignKey(a => a.ResponsavelID);

            modelBuilder.Entity<Processo>(build =>
            {
                build.ToTable("Processos");
                build.HasKey(k => k.ID);
                build.Property(p => p.NumeroProcessoUnificado).IsRequired().HasMaxLength(20);
                build.Property(p => p.Descricao).HasMaxLength(1000);
                build.Property(p => p.PastaFisicaCliente).HasMaxLength(50);
                build.HasOne(p => p.Situacao).WithMany().HasForeignKey(p => p.SituacaoID);
            });

            modelBuilder.Entity<Processo>().HasMany(p => p.ProcessoResponsaveis).WithOne().HasForeignKey(a => a.ProcessoID);

            modelBuilder.Entity<Processo>().HasOne<Processo>().WithMany().HasForeignKey(a => a.ProcessoPaiID);

            modelBuilder.Entity<Responsavel>(build =>
            {
                build.ToTable("Responsaveis");
                build.HasKey(k => k.ID);
                build.Property(p => p.CPF).IsRequired().HasMaxLength(11);
                build.Property(p => p.Nome).IsRequired().HasMaxLength(150);
                build.Property(p => p.Email).IsRequired().HasMaxLength(400);
            });
            modelBuilder.Entity<Responsavel>().HasMany(p => p.ProcessoResponsaveis).WithOne().HasForeignKey(a => a.ResponsavelID);

            modelBuilder.Entity<Situacao>(build =>
            {
                build.ToTable("Situacoes");
                build.HasKey(k => k.ID);
                build.Property(p => p.Nome).IsRequired().HasMaxLength(12);
                build.HasMany<Processo>().WithOne().HasForeignKey(p => p.SituacaoID);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
