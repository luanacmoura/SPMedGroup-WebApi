using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPMedGroup.WebApi.Domains;
using SPMedGroup.WebApi.Interfaces;
using SPMedGroup.WebApi.Repositories;

namespace SPMedGroup.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProntuarioPacienteController : ControllerBase
    {
        private IProntuarioPacienteRepository ProntuarioPacienteRepository;

        public ProntuarioPacienteController()
        {
            ProntuarioPacienteRepository = new ProntuarioPacienteRepository();
        }

        [Authorize (Roles = "1")] //Somente um administrador pode cadastrar um paciente
        [HttpPost ("{Cadastrar")]
        public IActionResult Cadastrar (ProntuarioPaciente paciente)
        {
            try
            {
                ProntuarioPacienteRepository.Cadastrar();
                return Ok("Paciente cadastrado com sucesso!");
            }
            catch
            {
                return BadRequest("Algo deu errado :/");
            }
        }
    }
}
