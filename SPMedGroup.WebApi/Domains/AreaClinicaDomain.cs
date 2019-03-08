using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedGroup.WebApi.Domains
{
    [Table("Area_Clinica")]
    public class AreaClinicaDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AreaClinicaId { get; set; }

        [Required(ErrorMessage = "Informe o nome da área clínica!")]
        [Column(TypeName = "varchar(250)")]
        [MinLength(3, ErrorMessage = "O nome deve conter pelo menos 3 caracteres!")]
        public string AreaClinicaNome { get; set; }
    }
}
