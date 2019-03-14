using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPMedGroup.WebApi.Domains
{
    public partial class Consulta
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Insira um id de um usuário do tipo paciente!", AllowEmptyStrings = false)]
        public int IdUsuarioPaciente { get; set; }

        [Required(ErrorMessage = "Insira um id de um usuário do tipo médico!", AllowEmptyStrings = false)]
        public int IdUsuarioMedico { get; set; }

        [Required(ErrorMessage = "Insira um id de um prontuário/paciente!", AllowEmptyStrings = false)]
        public int? IdProntuarioPaciente { get; set; }

        [Required (ErrorMessage = "Insira uma data para a consulta!", AllowEmptyStrings = false)]
        public DateTime DataConsulta { get; set; }
        public string StatusConsulta { get; set; }
        public string Descricao { get; set; }

        public ProntuarioPaciente IdProntuarioPacienteNavigation { get; set; }
        public Usuarios IdUsuarioMedicoNavigation { get; set; }
        public Usuarios IdUsuarioPacienteNavigation { get; set; }
    }
}
