
using BlazorApp3.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp3.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<HistorialMedico> HistorialesMedicos { get; set; }
        public DbSet<AnalisisClinico> AnalisisClinicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Paciente)
                .WithMany(p => p.Citas)
                .HasForeignKey(c => c.PacienteID);

            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Medico)
                .WithMany(m => m.Citas)
                .HasForeignKey(c => c.MedicoID);

            modelBuilder.Entity<HistorialMedico>()
                .HasOne(h => h.Paciente)
                .WithMany(p => p.HistorialesMedicos)
                .HasForeignKey(h => h.PacienteID);

            modelBuilder.Entity<AnalisisClinico>()
                .HasOne(ac => ac.HistorialMedico)
                .WithMany(hm => hm.AnalisisClinicos)
                .HasForeignKey(ac => ac.HistorialID);
        }
    }
}




