using System;
using System.Collections.Generic;

namespace SPMedGroup.WebApi.Domains
{
    public partial class Consulta
    {
        public int Id { get; set; }
        public int IdUsuarioPaciente { get; set; }
        public int IdUsuarioMedico { get; set; }
        public int? IdProntuarioPaciente { get; set; }
        public DateTime DataConsulta { get; set; }
        public string StatusConsulta { get; set; }
        public string Descricao { get; set; }

        public ProntuarioPaciente IdProntuarioPacienteNavigation { get; set; }
        public Usuarios IdUsuarioMedicoNavigation { get; set; }
        public Usuarios IdUsuarioPacienteNavigation { get; set; }
    }
}
