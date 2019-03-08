using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedGroup.WebApi.Domains
{
    //Para que a data de nascimento não possa passar da data atual!
    public class DateAttribute : RangeAttribute
    {
        public DateAttribute()
          : base(typeof(DateTime), DateTime.Now.ToShortDateString(), DateTime.MaxValue.ToShortDateString()) { }
    }

    [Table("Prontuario_Pacientes")]
    public class ProntuarioPacientesDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProntuarioPacienteId { get; set; }

        [Required (ErrorMessage = "Informe o nome!")]
        [Column(TypeName = "varchar(250)")]
        [MinLength(3, ErrorMessage = "O nome deve conter pelo menos 3 caracteres!")]
        public string Nome { get; set; }

        [Required (ErrorMessage = "Informe o RG!")]
        [Column(TypeName = "varchar(14)")] //lembrar do .isunique no context
        [MaxLength(14, ErrorMessage = "O RG deve conter no máximo 14 caracteres!")] //coloquei max porque para cada estado há uma qtd de digitos diferentes então não tem como estabelecer uma qtd min
        public long RG { get; set; }

        [Required (ErrorMessage = "Informe o CPF!")]
        [Column(TypeName = "char(11)")] //lembrar do .isunique no context
        [MinLength(11, ErrorMessage = "CPF inválido! O CPF deve conter exatamente 11 caracteres.")]
        public long CPF { get; set; }

        [Required (ErrorMessage = "Informe a data de nascimento!")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida!")] //Não precisa de min length pq o data type já verifica!
        public DateTime Data_Nasc { get; set; }

        [Column(TypeName = "char(11)")] //não é obrigatório!
        public long? Telefone { get; set; } //portanto pode receber null

        [Required (ErrorMessage = "Informe o id do endereço!")]
        public int EnderecoPacienteId { get; set; }

        [ForeignKey("EnderecoPacienteId")]
        public EnderecoPacientesDomain Endereco { get; set; }

        [Required (ErrorMessage = "Informe o id do usuário!")]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public UsuarioDomain Usuario { get; set; }
    }
}
