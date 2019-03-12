using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedGroup.WebApi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "É obrigatório informar o email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "É obrigatório informar a senha!")]
        public string Senha { get; set; }
    }
}
