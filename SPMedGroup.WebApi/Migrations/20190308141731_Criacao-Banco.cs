using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SPMedGroup.WebApi.Migrations
{
    public partial class CriacaoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area_Clinica",
                columns: table => new
                {
                    AreaClinicaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaClinicaNome = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area_Clinica", x => x.AreaClinicaId);
                });

            migrationBuilder.CreateTable(
                name: "Clinica",
                columns: table => new
                {
                    ClinicaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CNPJ = table.Column<long>(type: "bigint", nullable: false),
                    ClinicaNome = table.Column<string>(type: "varchar(250)", nullable: false),
                    Razao_Social = table.Column<string>(type: "varchar(250)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinica", x => x.ClinicaId);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos_Pacientes",
                columns: table => new
                {
                    EnderecoPacienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Estado = table.Column<string>(type: "varchar(250)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(250)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(250)", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(250)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(250)", nullable: false),
                    CEP = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos_Pacientes", x => x.EnderecoPacienteId);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Usuarios",
                columns: table => new
                {
                    TipoUsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipoUsuarioNome = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Usuarios", x => x.TipoUsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "varchar(250)", nullable: false),
                    Senha = table.Column<string>(type: "char(32)", maxLength: 10, nullable: false),
                    TipoUsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_Tipo_Usuarios_TipoUsuarioId",
                        column: x => x.TipoUsuarioId,
                        principalTable: "Tipo_Usuarios",
                        principalColumn: "TipoUsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    MedicoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CRM = table.Column<string>(type: "char(32)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: false),
                    Telefone = table.Column<string>(type: "char(11)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(250)", nullable: false),
                    AreaClinicaId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.MedicoId);
                    table.ForeignKey(
                        name: "FK_Medicos_Area_Clinica_AreaClinicaId",
                        column: x => x.AreaClinicaId,
                        principalTable: "Area_Clinica",
                        principalColumn: "AreaClinicaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prontuario_Pacientes",
                columns: table => new
                {
                    ProntuarioPacienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: false),
                    RG = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    CPF = table.Column<string>(type: "char(11)", nullable: false),
                    Data_Nasc = table.Column<DateTime>(nullable: false),
                    Telefone = table.Column<string>(type: "char(11)", nullable: true),
                    EnderecoPacienteId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prontuario_Pacientes", x => x.ProntuarioPacienteId);
                    table.ForeignKey(
                        name: "FK_Prontuario_Pacientes_Enderecos_Pacientes_EnderecoPacienteId",
                        column: x => x.EnderecoPacienteId,
                        principalTable: "Enderecos_Pacientes",
                        principalColumn: "EnderecoPacienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prontuario_Pacientes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    ConsultaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProntuarioPacienteId = table.Column<int>(nullable: false),
                    MedicoId = table.Column<int>(nullable: false),
                    DataConsulta = table.Column<DateTime>(nullable: false),
                    StatusConsulta = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.ConsultaId);
                    table.ForeignKey(
                        name: "FK_Consulta_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "MedicoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_Prontuario_Pacientes_ProntuarioPacienteId",
                        column: x => x.ProntuarioPacienteId,
                        principalTable: "Prontuario_Pacientes",
                        principalColumn: "ProntuarioPacienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clinica_CNPJ",
                table: "Clinica",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_MedicoId",
                table: "Consulta",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_ProntuarioPacienteId",
                table: "Consulta",
                column: "ProntuarioPacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_AreaClinicaId",
                table: "Medicos",
                column: "AreaClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_CRM",
                table: "Medicos",
                column: "CRM",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_UsuarioId",
                table: "Medicos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Prontuario_Pacientes_CPF",
                table: "Prontuario_Pacientes",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prontuario_Pacientes_EnderecoPacienteId",
                table: "Prontuario_Pacientes",
                column: "EnderecoPacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Prontuario_Pacientes_RG",
                table: "Prontuario_Pacientes",
                column: "RG",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prontuario_Pacientes_UsuarioId",
                table: "Prontuario_Pacientes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TipoUsuarioId",
                table: "Usuarios",
                column: "TipoUsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clinica");

            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Prontuario_Pacientes");

            migrationBuilder.DropTable(
                name: "Area_Clinica");

            migrationBuilder.DropTable(
                name: "Enderecos_Pacientes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Tipo_Usuarios");
        }
    }
}
