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
        public string Estado { get; set; }

        [Required(ErrorMessage = "Insira a cidade!", AllowEmptyStrings = false)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Insira o bairro!", AllowEmptyStrings = false)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Insira o logradouro!", AllowEmptyStrings = false)]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Insira o endereço!", AllowEmptyStrings = false)]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Insira o CEP!", AllowEmptyStrings = false)]
        public long Cep { get; set; }

        public ICollection<Medicos> Medicos { get; set; }
    }
}
