using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedGroup.WebApi.Domains
{
    [Table("Tipo_Usuarios")]
    public class TipoUsuariosDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TipoUsuarioId { get; set; }

        [Required (ErrorMessage = "Informe o nome!")]
        [Column(TypeName = "varchar(250)")]
        [MinLength(3, ErrorMessage = "O nome deve conter no mínimo 3 caracteres!")]
        public string TipoUsuarioNome { get; set; }
    }
}
