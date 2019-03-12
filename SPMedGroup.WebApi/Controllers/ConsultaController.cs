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
    class ConsultaController : ControllerBase
    {
        private IConsultaRepository ConsultaRepository { get; set; }

        public ConsultaController() {
            ConsultaRepository = new ConsultaRepository();    
        }

        [Authorize (Roles = "1")]
        [HttpPost("{Cadastrar}")]
        public IActionResult Post(Consulta consulta)
        {
            try
            {
                ConsultaRepository.Cadastrar(consulta);
                return Ok("Consulta cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Algo deu errado :/");
            }
        }
    }
}
