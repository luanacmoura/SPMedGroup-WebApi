using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPMedGroup.WebApi.Domains;
using SPMedGroup.WebApi.Interfaces;
using SPMedGroup.WebApi.Repositories;
using System.Linq;

namespace SPMedGroup.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class InfoAtendimentoController : ControllerBase
    {
        private IInfoAtendimentoRepository InfoAtendimentoRepository;

        public InfoAtendimentoController()
        {
            InfoAtendimentoRepository = new InfoAtendimentoRepository();
        }

        [Authorize(Roles="1")]
        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(InfoAtendimento informacoes)
        {
            try
            {
                using (SpMedGroupContext ctx = new SpMedGroupContext())
                {
                    AreaClinica especialidade = new AreaClinica();
                    especialidade = ctx.AreaClinica.FirstOrDefault(x => x.Id == informacoes.IdAreaClinica);
                    informacoes.IdAreaClinicaNavigation = especialidade;
                    if (especialidade == null)
                    {
                        return NotFound("Area Clinica não encontrada!");
                    }
                    else
                    {
                        InfoAtendimentoRepository.Cadastrar(informacoes);
                        return Ok("O cadastro foi realizado com sucesso!");
                    }
                }
            }
            catch
            {
                return BadRequest("Algo deu errado :/");
            }
        }
    }
}
