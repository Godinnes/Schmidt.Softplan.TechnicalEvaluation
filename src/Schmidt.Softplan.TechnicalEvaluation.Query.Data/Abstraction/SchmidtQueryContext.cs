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
                build.HasOne<Processo>().WithMany().HasForeignKey(a => a.ProcessoID);
                build.HasOne<Responsavel>().WithMany().HasForeignKey(a => a.ResponsavelID);
            });

            modelBuilder.Entity<Processo>(build =>
            {
                build.ToTable("Processos");
                build.HasKey(k => k.ID);
                build.HasOne(p => p.Situacao).WithMany().HasForeignKey("situacaoID");
                build.HasMany(p => p.Responsaveis);
            });

            modelBuilder.Entity<Responsavel>(build =>
            {
                build.ToTable("Responsaveis");
                build.HasKey(k => k.ID);
                build.HasMany(p => p.Processos);
            });

            modelBuilder.Entity<Situacao>(build =>
            {
                build.ToTable("Situacoes");
                build.HasKey(k => k.ID);
            });
        }
    }
}
