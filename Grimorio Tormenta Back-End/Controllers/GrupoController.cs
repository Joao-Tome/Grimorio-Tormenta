using FluentValidation;
using GrimorioTormenta.Intefaces.Instancia;
using GrimorioTormenta.Intefaces.Repositorio;
using GrimorioTormenta.Model.DTO;
using GrimorioTormenta.Model.Models;
using GrimorioTormenta.Repositorio.Config;
using GrimorioTormenta.Repositorio.Repositorio;
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

        public GrupoController(IGrupoInstancia grupoInstancia)
        {
            _instancia = grupoInstancia;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GrupoDTO>>? GetAll()
        {
            return Ok(_instancia.GetInstancias());
        }

        [HttpPost]
        public ActionResult<GrupoDTO> Add(GrupoDTO obj)
        {
            try
            {
                return Ok(_instancia.Inserir(obj));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException.Message);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                _instancia.deletar(_instancia.GetInstancia(id));
                return Ok("Objeto Deletado com Sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPut]
        public ActionResult<GrupoDTO> Update(GrupoDTO obj)
        {
            try
            {
                return _instancia.Alterar(obj);
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}





