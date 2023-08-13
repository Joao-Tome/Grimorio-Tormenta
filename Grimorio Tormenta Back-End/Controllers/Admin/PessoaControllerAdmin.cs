using FluentValidation;
using Grimorio_Tormenta_Back_End.Config.Services;
using GrimorioTormenta.Business.Instancia;
using GrimorioTormenta.Intefaces.Instancia;
using GrimorioTormenta.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Grimorio_Tormenta_Back_End.Controllers.Admin
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class PessoaControllerAdmin : ControllerBase
    {
        private readonly IPessoaInstancia _instancia;
        private readonly ErrorService _errorService;

        public PessoaControllerAdmin(IPessoaInstancia instancia, ErrorService errorService)
        {
            _instancia = instancia;
            _errorService = errorService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PessoaDTO>>? GetAll(bool Inativos)
        {
            return Ok(_instancia.GetInstancias(Inativos));
        }

        [HttpPost]
        public ActionResult<PessoaDTO> Add(PessoaDTO obj)
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
        public ActionResult<PessoaDTO> Update(PessoaDTO obj)
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
    }
}
