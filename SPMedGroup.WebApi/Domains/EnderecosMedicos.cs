using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPMedGroup.WebApi.Domains
{
    public partial class EnderecosMedicos
    {
        public EnderecosMedicos()
        {
            Medicos = new HashSet<Medicos>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Insira o estado!", AllowEmptyStrings = false)]
        [MaxLength(2, ErrorMessage = "O estado deve conter no máximo 2 caracteres!")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Insira a cidade!", AllowEmptyStrings = false)]
        [MinLength(3, ErrorMessage = "A cidade deve conter no mínimo 3 caracteres!")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Insira o bairro!", AllowEmptyStrings = false)]
        [MinLength(3, ErrorMessage = "O bairro deve conter no mínimo 3 caracteres!")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Insira o logradouro!", AllowEmptyStrings = false)]
        [MinLength(2, ErrorMessage = "O logradouro deve conter no mínimo 2 caracteres!")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Insira o endereço!", AllowEmptyStrings = false)]
        [MinLength(6, ErrorMessage = "O endereço deve conter no mínimo 6 caracteres!")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Insira o CEP!", AllowEmptyStrings = false)]
        [MinLength(8, ErrorMessage = "O CEP deve conter 8 caracteres!")]
        [MaxLength(8, ErrorMessage = "O CEP deve conter 8 caracteres!")]
        public long Cep { get; set; }

        public ICollection<Medicos> Medicos { get; set; }
    }
}
