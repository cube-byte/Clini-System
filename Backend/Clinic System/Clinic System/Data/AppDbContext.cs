using Clinic_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinic_System.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Atencion> Atenciones { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<DetalleTratamiento> DetalleTratamientos { get; set; }
        public DbSet<Diagnostico> Diagnosticos { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Seguimiento> Seguimientos { get; set; }
        public DbSet<Tratamiento> Tratamientos { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<TipoCita> TipoCitas { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
    }
}
