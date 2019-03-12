using System;
using System.Collections.Generic;

namespace SPMedGroup.WebApi.Domains
{
    public partial class ProntuarioPaciente
    {
        public ProntuarioPaciente()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNasc { get; set; }
        public string Telefone { get; set; }
        public int? IdEndereco { get; set; }
        public int? IdUsuario { get; set; }

        public EnderecosPacientes IdEnderecoNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
        public ICollection<Consulta> Consulta { get; set; }
    }
}
