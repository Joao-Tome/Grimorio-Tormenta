using FluentValidation;
using Grimorio_Tormenta_Back_End.Config.Services;
using GrimorioTormenta.Intefaces.Instancia;
using GrimorioTormenta.Model.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Grimorio_Tormenta_Back_End.Controllers.Admin
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class GrupoControllerAdmin : ControllerBase
    {
        private readonly IGrupoInstancia _instancia;
        private readonly ErrorService _errorService;

        public GrupoControllerAdmin(IGrupoInstancia grupoInstancia, ErrorService errorService)
        {
            _instancia = grupoInstancia;
            _errorService = errorService;
        }

        [HttpGet, Authorize]
        public ActionResult<IEnumerable<GrupoDTO>>? GetAll(bool inativos)
        {
            return Ok(_instancia.GetInstancias(inativos));
        }

        [HttpPost, Authorize]
        public ActionResult<GrupoDTO> Add(GrupoDTO obj)
        {
            try
            {
                return Ok(_instancia.Inserir(obj));
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

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                _instancia.Deletar(id);
                return Ok("Objeto Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return _errorService.HandleException(ex);
            }

        }

        [HttpPut]
        public ActionResult<GrupoDTO> Update(GrupoDTO obj)
        {
            try
            {
                return _instancia.Alterar(obj);
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

        [HttpPost("Entrar")]
        [Authorize]
        public ActionResult<GrupoDTO> EntrarGrupo(int PessoaId, int GrupoId)
        {
            try
            {
                return _instancia.EntrarGrupo(PessoaId, GrupoId);
            }
            catch (Exception ex)
            {
                return _errorService.HandleException(ex);
            }
        }

    }
}





