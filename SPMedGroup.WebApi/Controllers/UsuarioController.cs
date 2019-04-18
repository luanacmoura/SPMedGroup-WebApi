using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPMedGroup.WebApi.Domains;
using SPMedGroup.WebApi.Interfaces;
using SPMedGroup.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedGroup.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository;

        public UsuarioController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [Authorize(Roles = "1")] //1 equivale a Administrador
        [HttpPost("Cadastrar")]
        public IActionResult Post(Usuarios usuario)
        {
            try
            {
                UsuarioRepository.Cadastrar(usuario);
                return Ok("Usuário cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Alguma coisa deu errado!");
            }
        }
    }
}
