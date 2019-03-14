using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPMedGroup.WebApi.Domains
{
    public partial class TipoUsuarios
    {
        public TipoUsuarios()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        [Required (ErrorMessage = "Insira o nome!", AllowEmptyStrings = false)]
        [MinLength(3, ErrorMessage = "O nome deve conter no mínimo 3 caracteres!")]
        public string Nome { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
