using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedGroup.WebApi.Domains
{
    [Table("Clinica")]
    public class ClinicaDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClinicaId { get; set; }

        [Required (ErrorMessage = "Informe o CNPJ!")]
        [Column(TypeName = "bigint")]
        [MinLength(8, ErrorMessage = "O CNPJ deve conter no mínimo 8 caracteres!")]
        public long CNPJ { get; set; }

        [Required (ErrorMessage = "Informe o nome!")]
        [MinLength(3, ErrorMessage = "O nome deve conter pelo menos 3 caracteres!")]
        [Column(TypeName = "varchar(250)")]
        public string ClinicaNome { get; set; }

        [Required (ErrorMessage = "Informe a Razão Social!")]
        [MinLength(3, ErrorMessage ="A razão social deve conter pelo menos 3 caracteres!")]
        [Column(TypeName = "varchar(250)")]
        public string Razao_Social { get; set; }

        [Required (ErrorMessage = "Informe o endereço!")]
        [MinLength(6, ErrorMessage = "O enderereço deve conter pelo menos 6 caracteres!")]
        [Column(TypeName = "varchar(250)")]
        public string Endereco { get; set; }
    }
}
