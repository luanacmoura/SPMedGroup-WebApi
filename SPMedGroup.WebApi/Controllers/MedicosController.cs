using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPMedGroup.WebApi.Domains;
using SPMedGroup.WebApi.Interfaces;
using SPMedGroup.WebApi.Repositories;
using SPMedGroup.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPMedGroup.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private IMedicosRepository MedicosRepository;

        public MedicosController()
        {
            MedicosRepository = new MedicosRepository();
        }

        [Authorize (Roles = "1")] //Só o administrador pode cadastrar um médico!
        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar (MedicoViewModel medico)
        {
            try
            {
                UsuarioRepository usuarioRepository = new UsuarioRepository();
                EnderecosMedicosRepository enderecoMedicoRepository = new EnderecosMedicosRepository();
                MedicosRepository medicoRepository = new MedicosRepository();

                Usuarios usuario = new Usuarios();
                //atribuindo as informações do view model ao usuário
                usuario.IdTipoUsuarios = medico.IdTipoUsuarios;
                usuario.Email = medico.Email;
                usuario.Senha = medico.Senha;
                //cadastrando o usuário
                usuarioRepository.Cadastrar(usuario);

                EnderecosMedicos endereco = new EnderecosMedicos();
                //atribuindo as informações do view model ao endereço
                endereco.Estado = medico.Estado;
                endereco.Cidade = medico.Cidade;
                endereco.Bairro = medico.Bairro;
                endereco.Logradouro = medico.Logradouro;
                endereco.Endereco = medico.Endereco;
                endereco.Cep = medico.Cep;
                //cadastrando endereço
                enderecoMedicoRepository.Cadastrar(endereco);

                Medicos medicocad = new Medicos();
                medicocad.Crm = medico.Crm;
                medicocad.Nome = medico.Nome;
                medicocad.Telefone = medico.Telefone;
                medicocad.IdAreaClinica = medico.IdAreaClinica;
                medicocad.IdEndereco = endereco.Id;
                medicocad.IdUsuario = usuario.Id;
                
                //cadastrando prontuario/paciente
                medicoRepository.Cadastrar(medicocad);

                return Ok("Médico cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Algo deu errado :/");
            }
        }
    }
}
