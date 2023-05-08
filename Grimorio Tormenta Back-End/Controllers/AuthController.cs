using FluentValidation;
using GrimorioTormenta.Intefaces.Conversor;
using GrimorioTormenta.Intefaces.Instancia;
using GrimorioTormenta.Intefaces.Services;
using GrimorioTormenta.Model.DTO;
using GrimorioTormenta.Model.DTO.Diversos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Grimorio_Tormenta_Back_End.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthServices _authServices;
        private readonly IPessoaServices _pessoaService;

        public AuthController(IAuthServices authServices, IPessoaServices pessoaService)
        {
            _authServices = authServices;
            _pessoaService = pessoaService;
        }

        [HttpPost("Register")]
        public ActionResult<PessoaDTO> Register([FromBody] PessoaDTO obj)
        {
            try
            {
                return Ok(_authServices.Register(obj));
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

        [HttpPost("Login")]
        public ActionResult<JsonContent> Login(LoginDTO obj)
        {
            try
            {
                var data = _authServices.Login(obj);
                return Ok(data);
            }
            catch (ValidationException ex)
            {
                if (ex.Errors.Any()) { 
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
        [HttpGet("Teste"), Authorize]
        public ActionResult<PessoaDTO> Get()
        {
            try
            {
                return Ok(_pessoaService.GetPessoa());
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
