using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedGroup.WebApi.Domains
{
    [Table("Usuarios")]
    public class UsuarioDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Informe o email!")]
        [Column(TypeName = "varchar(250)")] //lembrar de por.IsUnique no Context
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha!")]
        [Column(TypeName = "char(32)")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 10 caracteres!")]
        public string Senha { get; set; }

        [Required (ErrorMessage = "O tipo de usuário é obrigatório.")]
        public int TipoUsuarioId { get; set; }

        [ForeignKey("TipoUsuarioId")]
        public TipoUsuariosDomain TipoUsuario { get; set; }
    }
}
