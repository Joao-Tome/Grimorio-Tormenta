using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Grimorio_Tormenta_Back_End.Config.Services
{
    public class ErrorService
    {

        public virtual ObjectResult StatusCode([ActionResultStatusCode] int statusCode, [ActionResultObjectValue] object? value)
        {
            return new ObjectResult(value)
            {
                StatusCode = statusCode
            };
        }

        public ObjectResult HandleValidationException(ValidationException ex)
        {
            if (ex == null)
            {
                return HandleException(new ArgumentNullException());
            }

            if (ex.Errors.Any())
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Errors);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }


        public ObjectResult HandleException(Exception ex)
        {
            if (ex == null)
            {
                return HandleException(new ArgumentNullException());
            }
            //TODO: Enviar Email!
            return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString()); //Teste, alterar depois!


        }
    }
}
