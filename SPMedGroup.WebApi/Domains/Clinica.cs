using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPMedGroup.WebApi.Domains
{
    public partial class Clinica
    {
        [Required (ErrorMessage = "Insira o cnpj!", AllowEmptyStrings = false)]
        public long Cnpj { get; set; }

        [Required (ErrorMessage = "Insira o nome!", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required (ErrorMessage = "Insira a Razão Social", AllowEmptyStrings = false)]
        public string RazaoSocial { get; set; }

        [Required (ErrorMessage = "Insira o endereço!", AllowEmptyStrings = false)]
        public string Endereco { get; set; }
    }
}
