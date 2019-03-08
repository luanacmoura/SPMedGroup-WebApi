using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedGroup.WebApi.Domains
{
    [Table("Medicos")]
    public class MedicoDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicoId { get; set; }

        [Required (ErrorMessage = "Informe o CRM do médico!")] //lembrar de por unique no context
        [Column(TypeName = "char(32)")]
        public int CRM { get; set; }

        [Required (ErrorMessage = "Informe o nome!")]
        [Column(TypeName = "varchar(250)")]
        [MinLength(3, ErrorMessage ="O nome deve conter no mínimo 3 caracteres!")]
        public string Nome { get; set; }

        [Required (ErrorMessage = "Informe o telefone!")]
        [Column(TypeName = "char(11)")]
        [MinLength(10, ErrorMessage = "O telefone deve conter no mínimo 10 caracteres!")]
        public long Telefone { get; set; }

        [Required (ErrorMessage = "Informe o endereço!")]
        [Column(TypeName = "varchar(250)")]
        [MinLength(6, ErrorMessage = "O endereço deve conter no mínimo 6 caracteres!")]
        public string Endereco { get; set; }

        [Required (ErrorMessage = "Informe o id da área clínica!")]
        public int AreaClinicaId { get; set; }

        [ForeignKey("AreaClinicaId")]
        public AreaClinicaDomain AreaClinica { get; set; }

        [Required(ErrorMessage = "Informe o id do usuário!")]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public UsuarioDomain Usuario { get; set; }
    }
}
