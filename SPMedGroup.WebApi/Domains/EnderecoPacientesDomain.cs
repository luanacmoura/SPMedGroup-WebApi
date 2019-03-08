using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedGroup.WebApi.Domains
{
    [Table("Enderecos_Pacientes")]
    public class EnderecoPacientesDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnderecoPacienteId { get; set; }

        [Required (ErrorMessage = "Informe o estado!")]
        [Column(TypeName = "varchar(250)")]
        [MinLength(2, ErrorMessage = "O estado deve conter no mínimo 2 caracteres!")]
        public string Estado { get; set; }

        [Required (ErrorMessage = "Informe a cidade!")]
        [Column(TypeName = "varchar(250)")]
        [MinLength(3, ErrorMessage = "A cidade deve conter no mínimo 3 caracteres!")]
        public string Cidade { get; set; }

        [Required (ErrorMessage = "Informe o bairro!")]
        [Column(TypeName = "varchar(250)")]
        [MinLength(3, ErrorMessage = "O bairro deve conter no mínimo 3 caracteres!")]
        public string Bairro { get; set; }

        [Required (ErrorMessage = "Informe o logradouro!")]
        [Column(TypeName = "varchar(250)")]
        [MinLength(4, ErrorMessage = "O logradouro deve conter pelo menos 4 caracteres!")]
        public string Logradouro { get; set; }

        [Required (ErrorMessage = "Informe o endereço!")]
        [Column(TypeName = "varchar(250)")]
        [MinLength(6, ErrorMessage = "O endereço deve conter no mínimo 6 caracteres!")]
        public string Endereco { get; set; }

        [Required (ErrorMessage = "Informe o CEP!")] //lembrar de por.IsUnique no Context
        [Column(TypeName = "bigint")]
        [MinLength(8, ErrorMessage = "O CEP deve conter pelo menos 8 caracteres!")]
        public long CEP { get; set; }
    }
}
