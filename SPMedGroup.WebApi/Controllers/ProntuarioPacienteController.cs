using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPMedGroup.WebApi.Domains;
using SPMedGroup.WebApi.Interfaces;
using SPMedGroup.WebApi.Repositories;
using SPMedGroup.WebApi.ViewModels;
using System;

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
        [HttpPost ("Cadastrar")]
        public IActionResult Cadastrar (ProntuarioPacienteViewModel paciente)
        {
            try
            {
                UsuarioRepository usuarioRepository = new UsuarioRepository();
                EnderecosPacientesRepository enderecoPacienteRepository = new EnderecosPacientesRepository();
                ProntuarioPacienteRepository prontuarioPacienteRepository = new ProntuarioPacienteRepository();

                Usuarios usuario = new Usuarios();
                //atribuindo as informações do view model ao usuário
                usuario.IdTipoUsuarios = paciente.IdTipoUsuarios;
                usuario.Email = paciente.Email;
                usuario.Senha = paciente.Senha;
                //cadastrando o usuário
                usuarioRepository.Cadastrar(usuario);

                EnderecosPacientes endereco = new EnderecosPacientes();
                //atribuindo as informações do view model ao endereço
                endereco.Estado = paciente.Estado;
                endereco.Cidade = paciente.Cidade;
                endereco.Bairro = paciente.Bairro;
                endereco.Logradouro = paciente.Logradouro;
                endereco.Endereco = paciente.Endereco;
                endereco.Cep = paciente.Cep;
                //cadastrando endereço
                enderecoPacienteRepository.Cadastrar(endereco);

                ProntuarioPaciente prontuariopaciente = new ProntuarioPaciente();
                prontuariopaciente.Nome = paciente.Nome;
                prontuariopaciente.Rg = paciente.Rg;
                prontuariopaciente.Cpf = paciente.Cpf;
                prontuariopaciente.DataNasc = paciente.DataNasc.Date;
                prontuariopaciente.Telefone = paciente.Telefone;
                prontuariopaciente.IdEndereco = endereco.Id;
                prontuariopaciente.IdUsuario = usuario.Id;
                //cadastrando prontuario/paciente
                prontuarioPacienteRepository.Cadastrar(prontuariopaciente);

                return Ok("Paciente cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Algo deu errado :/");
            }
        }

        [Authorize(Roles = "1")]//1 equivale a Administrador
        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(ProntuarioPacienteRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
