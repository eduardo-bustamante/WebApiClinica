using Microsoft.EntityFrameworkCore;
using WebApiClinica.Models;

namespace WebApiClinica.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<PacienteModel> Pacientes { get; set; }
        public DbSet<MedicoModel> Medicos { get; set; }
        public DbSet<ConsultaModel> Consultas { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ConsultaModel>()
                .HasKey(c => c.ConsultaId); // Configura a propriedade como chave primária

            modelBuilder.Entity<MedicoModel>()
                .HasKey(c => c.MedicoId); // Configura a propriedade como chave primária

            modelBuilder.Entity<PacienteModel>()
                .HasKey(c => c.PacienteId); // Configura a propriedade como chave primária



            // Configuração do relacionamento entre Consulta e Paciente
            modelBuilder.Entity<ConsultaModel>()
                .HasOne(c => c.Paciente)
                .WithMany(p => p.Consultas)
                .HasForeignKey(c => c.PacienteId);

            // Configuração do relacionamento entre Consulta e Medico
            modelBuilder.Entity<ConsultaModel>()
                .HasOne(c => c.Medico)
                .WithMany(m => m.Consultas)
                .HasForeignKey(c => c.MedicoId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
