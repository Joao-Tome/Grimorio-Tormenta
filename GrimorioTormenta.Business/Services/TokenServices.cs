using GrimorioTormenta.Intefaces.Services;
using GrimorioTormenta.Model.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Business.Services
{
    public class TokenServices : ITokenServices
    {
        public TokenServices() { }

        public string GenerateToken(PessoaDTO pessoa)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,pessoa.NickName),
                new Claim(ClaimTypes.Email,pessoa.Email)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.Secret));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken
                (
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: cred
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
