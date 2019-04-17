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
        public string Nome { get; set; }

        [Required (ErrorMessage = "Insira o RG!", AllowEmptyStrings = false)]
        public string Rg { get; set; }

        [Required(ErrorMessage = "Insira o CPF!", AllowEmptyStrings = false)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Insira a data de nascimento!", AllowEmptyStrings = false)]
        public DateTime DataNasc { get; set; }

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
