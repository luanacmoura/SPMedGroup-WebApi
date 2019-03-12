using System;
using System.Collections.Generic;

namespace SPMedGroup.WebApi.Domains
{
    public partial class Clinica
    {
        public long Cnpj { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Endereco { get; set; }
    }
}
