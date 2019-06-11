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
            catch 
            {
                return BadRequest("Alguma coisa deu errado!");
            }
        }

        [Authorize(Roles = "1")]
        [HttpPut("Editar")]
        public IActionResult Editar(Usuarios usuario)
        {
            try
            {
                Usuarios usuarioantigo = new Usuarios();
                usuarioantigo = UsuarioRepository.BuscarPorId(usuario.Id);

                usuarioantigo.Email = usuario.Email;
                usuarioantigo.Senha = usuario.Senha;
                UsuarioRepository.Editar(usuarioantigo);
                return Ok("Usuario editado com sucesso!");
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "1")]
        [HttpGet("ListarUsuarios")]
        public IActionResult ListarUsuarios ()
        {
            try
            {
                return Ok(UsuarioRepository.ListarUsuarios());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
