using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedGroup.WebApi.ViewModels
{
    public class MedicoViewModel
    {
        [Required(ErrorMessage = "Insira o email!", AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insira a senha!", AllowEmptyStrings = false)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O tipo de usuário é obrigatório.")]
        public int IdTipoUsuarios { get; set; }

        [Required(ErrorMessage = "Insira o CRM", AllowEmptyStrings = false)]
        public string Crm { get; set; }

        [Required(ErrorMessage = "Insira o nome!", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira o telefone!", AllowEmptyStrings = false)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Insira o id da área clínica!", AllowEmptyStrings = false)]
        public int IdAreaClinica { get; set; }

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

    }
}
