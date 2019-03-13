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
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository ConsultaRepository;

        public ConsultaController()
        {
            ConsultaRepository = new ConsultaRepository();    
        }

        [Authorize(Roles = "1")] //Somente o administrador pode cadastrar uma consulta
        [HttpPost("{Cadastrar}")]
        public IActionResult CadastrarConsulta(Consulta consulta)
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

        [Authorize(Roles = "2")] //O médico pode editar a consulta pra adicionar uma descrição, e qnd isso acontecer o status da consulta vai pra realizada!
        [HttpPut("{Editar}")]
        public IActionResult EditarConsulta(Consulta consulta)
        {
            try
            {
                if (ConsultaRepository.BuscarPorId(consulta.Id)==null)
                {
                    return NotFound("Não é possível editar uma consulta não existente!");
                }

                consulta.DataConsulta = ConsultaRepository.BuscarPorId(consulta.Id).DataConsulta;
                consulta.IdProntuarioPaciente = ConsultaRepository.BuscarPorId(consulta.Id).IdProntuarioPaciente;
                consulta.IdUsuarioMedico = ConsultaRepository.BuscarPorId(consulta.Id).IdUsuarioMedico;
                consulta.IdUsuarioPaciente = ConsultaRepository.BuscarPorId(consulta.Id).IdUsuarioPaciente;
                consulta.StatusConsulta = "Realizada";

                ConsultaRepository.Editar(consulta);
                return Ok("Consulta editada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Algo deu errado :/");
            }
        }
    }
}
