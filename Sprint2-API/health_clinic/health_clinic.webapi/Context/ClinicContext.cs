using health_clinic.webapi.Domain;
using Microsoft.EntityFrameworkCore;
using webapi.event_.tarde.Domains;

namespace health_clinic.webapi.Context
{
    public class ClinicContext : DbContext
    {
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Clinica> Clinica { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE13-S15; Database=health_clinica_tarde; User Id=sa; Pwd=Senai@134; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
