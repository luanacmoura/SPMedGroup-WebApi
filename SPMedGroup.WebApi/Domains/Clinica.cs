using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPMedGroup.WebApi.Domains
{
    public partial class Clinica
    {
        [Required (ErrorMessage = "Insira o cnpj!", AllowEmptyStrings = false)]
        [MinLength(14, ErrorMessage = "O cnpj deve conter pelo menos 14 caracteres!")]
        public long Cnpj { get; set; }

        [Required (ErrorMessage = "Insira o nome!", AllowEmptyStrings = false)]
        [MinLength(3, ErrorMessage = "O nome deve conter pelo menos 3 caracteres!")]
        public string Nome { get; set; }

        [Required (ErrorMessage = "Insira a Razão Social", AllowEmptyStrings = false)]
        [MinLength(3, ErrorMessage = "A razão social deve ter pelo menos 3 caracteres!")]
        public string RazaoSocial { get; set; }

        [Required (ErrorMessage = "Insira o endereço!", AllowEmptyStrings = false)]
        [MinLength(6, ErrorMessage = "O endereço deve conter pelo menos 6 caracteres!")]
        public string Endereco { get; set; }
    }
}
