using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPMedGroup.WebApi.Domains;
using SPMedGroup.WebApi.Interfaces;
using SPMedGroup.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPMedGroup.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private IMedicosRepository MedicosRepository;

        public MedicosController()
        {
            MedicosRepository = new MedicosRepository();
        }

        [Authorize (Roles = "1")] //Só o administrador pode cadastrar um médico!
        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar (Medicos medico)
        {
            try
            {
                if (MedicosRepository.Cadastrar(medico)==null)
                {
                    return BadRequest("Não é possível cadastrar um usuário do tipo admin/paciente num médico!");
                }

                return Ok("Médico cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Algo deu errado :/");
            }
        }
    }
}
