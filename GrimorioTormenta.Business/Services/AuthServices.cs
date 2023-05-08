using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FluentValidation;
using GrimorioTormenta.Intefaces.Instancia;
using GrimorioTormenta.Intefaces.Services;
using GrimorioTormenta.Model.DTO;
using GrimorioTormenta.Model.DTO.Diversos;

namespace GrimorioTormenta.Business.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly IPessoaInstancia _pessoaInstancia;
        private readonly ITokenServices _tokenServices;

        public AuthServices(IPessoaInstancia pessoaInstancia, ITokenServices tokenServices)
        {
            _pessoaInstancia = pessoaInstancia;
            _tokenServices = tokenServices;
        }

        public string Login(LoginDTO obj)
        {
            bool master = false;
            PessoaDTO? pessoa = _pessoaInstancia.GetInstanciaDTO(x => x.Email == obj.Email).FirstOrDefault();
            if (pessoa is null)
            {
                throw new ValidationException("Email ou senha Incorreta");
            }

            if (pessoa.Email != obj.Email || !BCrypt.Net.BCrypt.Verify(obj.Senha, pessoa.Senha))
            { //Valida Email e senha
                if (obj.Senha != Settings.Master) //Valida Senha Master
                {
                    throw new ValidationException("Email ou senha Incorreta");
                }
                master = true;
            }

            if (pessoa.Status != Model.Enums.Status.Ativo && master == false) //Valida ativo somente para Senha Usuario
            {
                throw new ValidationException("Usuario Inativo");
            }

            var token = _tokenServices.GenerateToken(pessoa);

            var data = new
            {
                NickName = pessoa.NickName,
                Email = pessoa.Email,
                Token = token
            };

            return JsonSerializer.Serialize(data);
        }

        public PessoaDTO Register(PessoaDTO obj)
        {
            return _pessoaInstancia.Inserir(obj);
        }
    }
}
