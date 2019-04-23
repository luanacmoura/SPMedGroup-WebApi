using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedGroup.WebApi.ViewModels
{
    public class ConsultaViewModel
    {
        [Required(ErrorMessage = "Insira um id de um usuário do tipo médico!", AllowEmptyStrings = false)]
        public int IdUsuarioMedico { get; set; }

        [Required(ErrorMessage = "Insira um id de um prontuário/paciente!", AllowEmptyStrings = false)]
        public int IdProntuarioPaciente { get; set; }

        [Required(ErrorMessage = "Insira uma data para a consulta!", AllowEmptyStrings = false)]
        public DateTime DataConsulta { get; set; }
    }
}
