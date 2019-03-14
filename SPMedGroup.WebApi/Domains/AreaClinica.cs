using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPMedGroup.WebApi.Domains
{
    public partial class AreaClinica
    {
        public AreaClinica()
        {
            Medicos = new HashSet<Medicos>();
        }

        public int Id { get; set; }
        [Required (ErrorMessage = "Insira o nome!", AllowEmptyStrings = false)]
        [MinLength(3, ErrorMessage = "O nome deve conter pelo menos 3 caracteres!")]
        public string Nome { get; set; }

        public ICollection<Medicos> Medicos { get; set; }
    }
}
