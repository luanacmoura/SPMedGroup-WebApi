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
    public class EnderecosPacientesController : ControllerBase
    {
        private IEnderecosPacientesRepository EnderecosPacientesRepository;

        public EnderecosPacientesController()
        {
            EnderecosPacientesRepository = new EnderecosPacientesRepository();
        }

        [Authorize(Roles = "1")] //só um administrador pode cadastrar um endereço
        [HttpPost("{cadastrar}")]
        public IActionResult Cadastrar(EnderecosPacientes endereco)
        {
            try
            {
                EnderecosPacientesRepository.Cadastrar(endereco);
                return Ok("Endereço cadastrado!");
            }
            catch 
            {
                return BadRequest("Alguma coisa deu errado :/");
            }
        }
    }
}
