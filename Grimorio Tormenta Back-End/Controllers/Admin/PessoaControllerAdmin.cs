using FluentValidation;
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

        public PessoaControllerAdmin(IPessoaInstancia instancia)
        {
            _instancia = instancia;
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
                if (ex.Errors.Any())
                {
                    return BadRequest(ex.Errors);
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
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
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
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
                if (ex.Errors.Any())
                {
                    return BadRequest(ex.Errors);
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
