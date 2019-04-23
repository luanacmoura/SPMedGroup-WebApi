using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPMedGroup.WebApi.Domains;
using SPMedGroup.WebApi.Interfaces;
using SPMedGroup.WebApi.Repositories;
using SPMedGroup.WebApi.ViewModels;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

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
        [HttpPost("Cadastrar")]
        public IActionResult CadastrarConsulta(ConsultaViewModel consultaV)
        {
            try
            {
                Consulta consulta = new Consulta();
                ProntuarioPacienteRepository prontuario = new ProntuarioPacienteRepository();

                consulta.IdProntuarioPaciente = consultaV.IdProntuarioPaciente;
                consulta.IdUsuarioMedico = consultaV.IdUsuarioMedico;
                consulta.DataConsulta = consultaV.DataConsulta;
                consulta.IdUsuarioPaciente = prontuario.BuscarIdUsuario(consultaV.IdProntuarioPaciente);

                ConsultaRepository.Cadastrar(consulta);
                return Ok("Consulta cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Algo deu errado :/");
            }
        }

        [Authorize(Roles = "2")] //O médico pode editar a consulta pra adicionar uma descrição, e qnd isso acontecer o status da consulta vai pra realizada!
        [HttpPut("Editar")]
        public IActionResult EditarConsulta(Consulta consulta)
        {
            try
            {
                if (ConsultaRepository.BuscarPorId(consulta.Id)==null)
                {
                    return NotFound("Não é possível editar uma consulta não existente!");
                }

                ConsultaRepository.Editar(consulta);
                return Ok("Consulta editada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Algo deu errado :/");
            }
        }

        [Authorize(Roles = "1")] //O admnistrador pode cancelar uma consulta!
        [HttpPut("Cancelar/{id}")]
        public IActionResult CancelarConsulta(int id)
        {
            try
            {
                if (ConsultaRepository.BuscarPorId(id) == null)
                {
                    return NotFound("Não é possível editar uma consulta não existente!");
                }

                ConsultaRepository.Cancelar(id);
                return Ok("Consulta cancelada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Algo deu errado :/");
            }
        }

        [Authorize(Roles = "1")] //Somente o administrador pode listar todas as consultas!
        [HttpGet("ListarTodas")]
        public IActionResult ListarTodas()
        {
            try
            {
                return Ok(ConsultaRepository.ListarTodas());
            }
            catch (Exception ex)
            {
                return BadRequest("Algo deu errado :/");
            }
        }

        [Authorize(Roles = "2")] //Somente o médico pode listar as próprias consultas!
        [HttpGet("ListardoMedico")]
        public IActionResult ListardoMedico()
        {
            try
            {
                int usuarioid = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                return Ok(ConsultaRepository.ListardoMedico(usuarioid));
            }
            catch (Exception ex)
            {
                return BadRequest("Algo deu errado :/");
            }
        }

        [Authorize(Roles = "3")] //Somente o paciente pode listar as próprias consultas!
        [HttpGet("ListardoPaciente")]
        public IActionResult ListardoPaciente()
        {
            try
            {
                int usuarioid = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(ConsultaRepository.ListardoPaciente(usuarioid));
            }
            catch (Exception ex)
            {
                return BadRequest("Algo deu errado :/");
            }
        }
    }
}
