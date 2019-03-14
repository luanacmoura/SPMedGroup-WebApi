using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPMedGroup.WebApi.Domains;
using SPMedGroup.WebApi.Interfaces;
using SPMedGroup.WebApi.Repositories;
using System;

namespace SPMedGroup.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository ClinicaRepository;

        public ClinicaController()
        {
            ClinicaRepository = new ClinicaRepository();
        }

        [Authorize (Roles = "1")] //Só o administrador pode cadastrar uma clínica
        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(Clinica clinica)
        {
            try
            {
                ClinicaRepository.Cadastrar(clinica);
                return Ok("Clínica cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Alguma coisa deu errado :/");
            }
        }
    }
}
