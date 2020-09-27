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

            modelBuilder.Entity<Processo>().HasMany(p => p.ProcessoResponsaveis).WithOne(p => p.Processo).HasForeignKey(a => a.ProcessoID);

            modelBuilder.Entity<Processo>().HasOne(a => a.ProcessoVinculado).WithMany().HasForeignKey(a => a.ProcessoPaiID);

            modelBuilder.Entity<Responsavel>(build =>
            {
                build.ToTable("Responsaveis");
                build.HasKey(k => k.ID);
                build.Property(p => p.CPF).IsRequired().HasMaxLength(11);
                build.Property(p => p.Nome).IsRequired().HasMaxLength(150);
                build.Property(p => p.Email).IsRequired().HasMaxLength(400);
            });
            modelBuilder.Entity<Responsavel>().HasMany(p => p.ProcessoResponsaveis).WithOne(p => p.Responsavel).HasForeignKey(a => a.ResponsavelID);

            modelBuilder.Entity<Situacao>(build =>
            {
                build.ToTable("Situacoes");
                build.HasKey(k => k.ID);
                build.Property(p => p.Nome).IsRequired().HasMaxLength(12);
                build.HasMany<Processo>().WithOne().HasForeignKey(p => p.SituacaoID);
            });
        }
    }
}
