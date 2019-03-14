using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SPMedGroup.WebApi.Domains
{
    public partial class SpMedGroupContext : DbContext
    {
        public SpMedGroupContext()
        {
        }

        public SpMedGroupContext(DbContextOptions<SpMedGroupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AreaClinica> AreaClinica { get; set; }
        public virtual DbSet<Clinica> Clinica { get; set; }
        public virtual DbSet<Consulta> Consulta { get; set; }
        public virtual DbSet<EnderecosMedicos> EnderecosMedicos { get; set; }
        public virtual DbSet<EnderecosPacientes> EnderecosPacientes { get; set; }
        public virtual DbSet<Medicos> Medicos { get; set; }
        public virtual DbSet<ProntuarioPaciente> ProntuarioPaciente { get; set; }
        public virtual DbSet<TipoUsuarios> TipoUsuarios { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog= SPMedGroup;  User Id = sa; Pwd = 132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AreaClinica>(entity =>
            {
                entity.ToTable("Area_Clinica");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Area_Cli__7D8FE3B25C0B09AA")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.Cnpj);

                entity.Property(e => e.Cnpj).ValueGeneratedNever();

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasColumnName("Razao_Social")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.Property(e => e.DataConsulta)
                    .HasColumnName("Data_consulta")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdProntuarioPaciente).HasColumnName("Id_Prontuario_Paciente");

                entity.Property(e => e.IdUsuarioMedico).HasColumnName("Id_Usuario_Medico");

                entity.Property(e => e.IdUsuarioPaciente).HasColumnName("Id_Usuario_Paciente");

                entity.Property(e => e.StatusConsulta)
                    .HasColumnName("Status_consulta")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Agendada')");

                entity.Property(e => e.Descricao).HasColumnName("Descricao");


                entity.HasOne(d => d.IdProntuarioPacienteNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdProntuarioPaciente)
                    .HasConstraintName("FK__Consulta__Id_Pro__66603565");

                entity.HasOne(d => d.IdUsuarioMedicoNavigation)
                    .WithMany(p => p.ConsultaIdUsuarioMedicoNavigation)
                    .HasForeignKey(d => d.IdUsuarioMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Consulta__Id_Usu__656C112C");

                entity.HasOne(d => d.IdUsuarioPacienteNavigation)
                    .WithMany(p => p.ConsultaIdUsuarioPacienteNavigation)
                    .HasForeignKey(d => d.IdUsuarioPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Consulta__Id_Usu__6477ECF3");
            });

            modelBuilder.Entity<EnderecosMedicos>(entity =>
            {
                entity.ToTable("Enderecos_Medicos");

                entity.HasIndex(e => e.Cep)
                    .HasName("UQ__Endereco__C1FF39CF4729A91D")
                    .IsUnique();

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Cep).HasColumnName("CEP");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnderecosPacientes>(entity =>
            {
                entity.ToTable("Enderecos_Pacientes");

                entity.HasIndex(e => e.Cep)
                    .HasName("UQ__Endereco__C1FF39CF4580E102")
                    .IsUnique();

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Cep).HasColumnName("CEP");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medicos>(entity =>
            {
                entity.HasKey(e => e.Crm);

                entity.Property(e => e.Crm)
                    .HasColumnName("CRM")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.IdAreaClinica).HasColumnName("Id_Area_Clinica");

                entity.Property(e => e.IdEndereco).HasColumnName("Id_Endereco");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAreaClinicaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdAreaClinica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Medicos__Id_Area__5AEE82B9");

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdEndereco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Medicos__Id_Ende__5BE2A6F2");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Medicos__Id_Usua__5CD6CB2B");
            });

            modelBuilder.Entity<ProntuarioPaciente>(entity =>
            {
                entity.ToTable("Prontuario_Paciente");

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__Prontuar__C1F897311AAD909A")
                    .IsUnique();

                entity.HasIndex(e => e.Rg)
                    .HasName("UQ__Prontuar__321537C87415672E")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.DataNasc)
                    .HasColumnName("Data_nasc")
                    .HasColumnType("date");

                entity.Property(e => e.IdEndereco).HasColumnName("Id_Endereco");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasColumnName("RG")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.ProntuarioPaciente)
                    .HasForeignKey(d => d.IdEndereco)
                    .HasConstraintName("FK__Prontuari__Id_En__619B8048");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.ProntuarioPaciente)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Prontuari__Id_Us__68487DD7");
            });

            modelBuilder.Entity<TipoUsuarios>(entity =>
            {
                entity.ToTable("Tipo_Usuarios");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Tipo_Usu__7D8FE3B2CD3DCC64")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D10534A4D2587B")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoUsuarios).HasColumnName("Id_Tipo_Usuarios");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuariosNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuarios)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuarios__Id_Tip__5812160E");
            });
        }
    }
}
