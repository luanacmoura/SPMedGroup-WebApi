using System;
using System.Collections.Generic;

namespace SPMedGroup.WebApi.Domains
{
    public partial class EnderecosMedicos
    {
        public EnderecosMedicos()
        {
            Medicos = new HashSet<Medicos>();
        }

        public int Id { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Endereco { get; set; }
        public long Cep { get; set; }

        public ICollection<Medicos> Medicos { get; set; }
    }
}
