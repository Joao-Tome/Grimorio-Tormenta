using FluentValidation;
using Grimorio_Tormenta_Back_End.Config.Services;
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
        private readonly ErrorService _errorService;
        public AuthController(IAuthServices authServices, IPessoaServices pessoaService, ErrorService errorService)
        {
            _authServices = authServices;
            _pessoaService = pessoaService;
            _errorService = errorService;
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
                return _errorService.HandleValidationException(ex);
            }
            catch (Exception ex)
            {
                return _errorService.HandleException(ex);
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
                return _errorService.HandleValidationException(ex);
            }
            catch (Exception ex)
            {
                return _errorService.HandleException(ex);
            }
        }

        [HttpGet("Teste"), Authorize]
        public ActionResult<PessoaDTO> Get()
        {
            try
            {
                return Ok(_pessoaService.GetPessoa());
            }
            catch (Exception ex)
            {
                return _errorService.HandleException(ex);
            }
        }
    }
}
