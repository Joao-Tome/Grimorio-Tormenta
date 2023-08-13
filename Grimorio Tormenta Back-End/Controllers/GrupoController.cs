using FluentValidation;
using Grimorio_Tormenta_Back_End.Config.Services;
using GrimorioTormenta.Intefaces.Conversor;
using GrimorioTormenta.Intefaces.Instancia;
using GrimorioTormenta.Intefaces.Services;
using GrimorioTormenta.Model.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Grimorio_Tormenta_Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoController : ControllerBase
    {
        private readonly IGrupoInstancia _instancia;
        private readonly IPessoaServices _pessoaService;
        private readonly IGrupoConversor _grupoConversor;
        private readonly ErrorService _errorService;

        public GrupoController(IGrupoInstancia grupoInstancia, IPessoaServices pessoaService, IGrupoConversor grupoConversor, ErrorService errorService)
        {
            _pessoaService = pessoaService;
            _instancia = grupoInstancia;
            _grupoConversor = grupoConversor;
            _errorService = errorService;
        }

        [HttpGet, Authorize]
        public ActionResult<IEnumerable<GrupoDTO>>? GetAll()
        {
            try
            {
                PessoaDTO pessoa = _pessoaService.GetPessoa();

                IEnumerable<GrupoDTO> grupos = _instancia.GetAllPessoa(pessoa);

                return Ok(_grupoConversor.ConverteToViewList(grupos));
            }
            catch (Exception ex)
            {
                return _errorService.HandleException(ex);
            }
        }

        [HttpPost, Authorize]
        public ActionResult<GrupoDTO> Add(GrupoDTO obj)
        {
            try
            {
                PessoaDTO pessoa = _pessoaService.GetPessoa();

                GrupoDTO grupo = _instancia.Inserir(obj, pessoa);

                return Ok(_grupoConversor.ConverteToViewModel(grupo));
            }
            catch (ValidationException ex)
            {
                return _errorService.HandleValidationException(ex);
            }
            catch (Exception ex)
            {
                return _errorService.HandleException(ex);
            }
        }

        [HttpDelete, Authorize]
        public ActionResult Delete(int id)
        {
            try
            {
                PessoaDTO pessoa = _pessoaService.GetPessoa();

                _instancia.Deletar(id, pessoa);
                return Ok("Objeto Deletado com Sucesso");
            }
            catch (ValidationException ex)
            {
                return _errorService.HandleValidationException(ex);
            }
            catch (Exception ex)
            {
                return _errorService.HandleException(ex);
            }

        }

        [HttpPut, Authorize]
        public ActionResult<GrupoDTO> Update(GrupoDTO obj)
        {
            try
            {
                PessoaDTO pessoa = _pessoaService.GetPessoa();

                return _instancia.Alterar(obj, pessoa);
            }
            catch (ValidationException ex)
            {
                return _errorService.HandleValidationException(ex);
            }
            catch (Exception ex)
            {
                return _errorService.HandleException(ex);
            }
        }

        [HttpPost("Entrar"), Authorize]
        public ActionResult<GrupoDTO> EntrarGrupo(int GrupoId)
        {
            try
            {
                PessoaDTO pessoa = _pessoaService.GetPessoa();

                return _instancia.EntrarGrupo(pessoa.Id, GrupoId);
            }
            catch (Exception ex)
            {
                return _errorService.HandleException(ex);
            }
        }

    }
}





