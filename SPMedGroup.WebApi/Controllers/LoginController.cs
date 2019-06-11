using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SPMedGroup.WebApi.Domains;
using SPMedGroup.WebApi.Interfaces;
using SPMedGroup.WebApi.Repositories;
using SPMedGroup.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SPMedGroup.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public LoginController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {
                Usuarios usuario = UsuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);

                //Se o usuário não foi encontrado, então
                if (usuario == null)
                {
                    //Retorna o erro "NotFound"
                    return NotFound("Email ou senha inválido!");
                }

                //Se foi encontrado...
                else
                {
                    string nome;
                    using (SpMedGroupContext ctx = new SpMedGroupContext())
                    {
                        Medicos medico = new Medicos();
                        ProntuarioPaciente paciente = new ProntuarioPaciente();

                        if (ctx.Medicos.FirstOrDefault(x => x.IdUsuario == usuario.Id) != null)
                        {
                            medico = ctx.Medicos.FirstOrDefault(x => x.IdUsuario == usuario.Id);
                            nome = medico.Nome;
                        }
                        else if (ctx.ProntuarioPaciente.FirstOrDefault(x => x.IdUsuario == usuario.Id) != null)
                        {
                            paciente = ctx.ProntuarioPaciente.FirstOrDefault(x => x.IdUsuario == usuario.Id);
                            nome = paciente.Nome;
                        }
                        else
                        {
                            nome = "Administrador";
                        }

                    }
                    //Estabelecendo quais dados estarão no payload para serem acessados 
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                        new Claim(ClaimTypes.Role, usuario.IdTipoUsuarios.ToString()),
                        new Claim("Role", usuario.IdTipoUsuarios.ToString()),
                        new Claim("Nome", nome)
                    };
                               

                    //Chave para acesso ao token
                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("D0Mlmccm14D0Mlmccm14D0Mlmccm14D0Mlmccm14"));

                    //Header, credenciais, geradas automaticamente.
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    //Gerando o token
                    var token = new JwtSecurityToken(
                        issuer: "SPMedGroup.WebApi",
                        audience: "SPMedGroup.WebApi",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(10),
                        signingCredentials: creds
                    );

                    //Retorna Ok + o Token com as informações que queremos.
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    });
                }
            }

            catch 
            {
                return BadRequest("Alguma coisa deu errado");
            }
        }
    }
}
