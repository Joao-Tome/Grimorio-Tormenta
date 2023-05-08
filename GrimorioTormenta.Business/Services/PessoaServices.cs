using GrimorioTormenta.Intefaces.Instancia;
using GrimorioTormenta.Intefaces.Repositorio;
using GrimorioTormenta.Intefaces.Services;
using GrimorioTormenta.Model.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Business.Services
{
    public class PessoaServices : IPessoaServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPessoaInstancia _pessoaInstancia;

        public PessoaServices(IHttpContextAccessor accessor, IPessoaInstancia pessoaInstancia)
        {
            _httpContextAccessor = accessor;
            _pessoaInstancia= pessoaInstancia;
        }

        public string GetEmail()
        {
            var result = string.Empty;
            if (_httpContextAccessor != null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email) ?? string.Empty;
            }
            return result;
        }

        public PessoaDTO GetPessoa()
        {
            return _pessoaInstancia.GetInstanciaDTO(x => x.Email == GetEmail()).FirstOrDefault();
        }

        public string GetNickName()
        {
            var result = string.Empty;
            if (_httpContextAccessor != null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name) ?? string.Empty;
            }
            return result;
        }
    }
}
