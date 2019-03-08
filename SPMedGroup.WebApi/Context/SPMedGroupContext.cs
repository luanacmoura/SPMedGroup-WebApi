using Microsoft.EntityFrameworkCore;
using SPMedGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedGroup.WebApi.Context
{
    public class SPMedGroupContext : DbContext
    {
        public DbSet<AreaClinicaDomain> AreaClinica { get; set; }
        public DbSet<ClinicaDomain> Clinica { get; set; }
        public DbSet<ConsultaDomain> Consulta { get; set; }
        public DbSet<EnderecoPacientesDomain> EnderecoPaciente { get; set; }
        public DbSet<MedicoDomain> Medico { get; set; }
        public DbSet<ProntuarioPacientesDomain> ProntuarioPaciente { get; set; }
        public DbSet<TipoUsuariosDomain> TipoUsuarios { get; set; }
        public DbSet<UsuarioDomain> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
             builder.Entity<ProntuarioPacientesDomain>().HasIndex(u => u.CPF).IsUnique();
             builder.Entity<ProntuarioPacientesDomain>().HasIndex(u => u.RG).IsUnique();
             builder.Entity<MedicoDomain>().HasIndex(u => u.CRM).IsUnique();
             builder.Entity<UsuarioDomain>().HasIndex(u => u.Email).IsUnique();
             builder.Entity<ClinicaDomain>().HasIndex(u => u.CNPJ).IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source =.\\SqlExpress; Initial Catalog = SPMedGroup_WebApi; User Id = sa; Pwd =132");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
