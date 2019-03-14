using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPMedGroup.WebApi.Domains
{
    public partial class ProntuarioPaciente
    {

        public ProntuarioPaciente()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int Id { get; set; }
        [Required (ErrorMessage = "Insira o nome!", AllowEmptyStrings = false)] //para que não seja possível colocar espaços
        [MinLength(3, ErrorMessage = "O nome precisa conter no mínimo 3 caracteres!")]
        public string Nome { get; set; }

        [Required (ErrorMessage = "Insira o RG!", AllowEmptyStrings = false)]
        [MinLength(9, ErrorMessage = "O RG precisa conter no mínimo 9 caracteres!")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "Insira o CPF!", AllowEmptyStrings = false)]
        [MinLength(11, ErrorMessage = "O CPF precisa conter 11 caracteres!")]
        [MaxLength(11, ErrorMessage = "O CPF precisa conter 11 caracteres!")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Insira a data de nascimento!", AllowEmptyStrings = false)]
        public DateTime DataNasc { get; set; }

        [MinLength(8, ErrorMessage = "O telefone precisa conter no mínimo 8 caracteres!")]
        public string Telefone { get; set; }

        [Required (ErrorMessage = "Insira o id do endereçi do paciente!", AllowEmptyStrings = false)]
        public int IdEndereco { get; set; }

        [Required (ErrorMessage = "Insira o id de um usuário que seja do tipo paciente!", AllowEmptyStrings = false)]
        public int IdUsuario { get; set; }

        public EnderecosPacientes IdEnderecoNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
        public ICollection<Consulta> Consulta { get; set; }
    }
}
