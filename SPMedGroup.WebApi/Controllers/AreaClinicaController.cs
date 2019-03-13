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
    public class AreaClinicaController : ControllerBase
    {
        private IAreaClinicaRepository AreaClinicaRepository;

        public AreaClinicaController()
        {
            AreaClinicaRepository = new AreaClinicaRepository();
        }

        [Authorize (Roles = "1")] //Só um administrador pode cadastrar uma área clínica!
        [HttpPost("{Cadastrar}")]
        public IActionResult Cadastrar (AreaClinica area)
        {
            try
            {
                AreaClinicaRepository.Cadastrar(area);
                return Ok("Área Clínica cadastrada com sucesso!");
            }

            catch (Exception ex)
            {
                return BadRequest("Algo deu errado!");
            }
        }
    }
}
