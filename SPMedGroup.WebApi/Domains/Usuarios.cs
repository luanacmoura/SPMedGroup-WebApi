using System;
using System.Collections.Generic;

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
        public string Email { get; set; }
        public string Senha { get; set; }
        public int IdTipoUsuarios { get; set; }

        public TipoUsuarios IdTipoUsuariosNavigation { get; set; }
        public ICollection<Consulta> ConsultaIdUsuarioMedicoNavigation { get; set; }
        public ICollection<Consulta> ConsultaIdUsuarioPacienteNavigation { get; set; }
        public ICollection<Medicos> Medicos { get; set; }
        public ICollection<ProntuarioPaciente> ProntuarioPaciente { get; set; }
    }
}
