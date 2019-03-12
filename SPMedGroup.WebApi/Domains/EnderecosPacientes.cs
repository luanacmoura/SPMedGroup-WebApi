using System;
using System.Collections.Generic;

namespace SPMedGroup.WebApi.Domains
{
    public partial class EnderecosPacientes
    {
        public EnderecosPacientes()
        {
            ProntuarioPaciente = new HashSet<ProntuarioPaciente>();
        }

        public int Id { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Endereco { get; set; }
        public long Cep { get; set; }

        public ICollection<ProntuarioPaciente> ProntuarioPaciente { get; set; }
    }
}
