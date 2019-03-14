using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPMedGroup.WebApi.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            ConsultaIdUsuarioMedicoNavigation = new HashSet<Consulta>();
            ConsultaIdUsuarioPacienteNavigation = new HashSet<Consulta>();
            Medicos = new HashSet<Medicos>();
            ProntuarioPaciente = new HashSet<ProntuarioPaciente>();
        }

        public int Id { get; set; }

        [Required (ErrorMessage = "Insira o email!", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insira a senha!", AllowEmptyStrings = false)]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 10 caracteres!")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O tipo de usuário é obrigatório.")]
        public int IdTipoUsuarios { get; set; }

        public TipoUsuarios IdTipoUsuariosNavigation { get; set; }
        public ICollection<Consulta> ConsultaIdUsuarioMedicoNavigation { get; set; }
        public ICollection<Consulta> ConsultaIdUsuarioPacienteNavigation { get; set; }
        public ICollection<Medicos> Medicos { get; set; }
        public ICollection<ProntuarioPaciente> ProntuarioPaciente { get; set; }
    }
}
