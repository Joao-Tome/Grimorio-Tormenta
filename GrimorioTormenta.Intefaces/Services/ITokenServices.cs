using GrimorioTormenta.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Intefaces.Services
{
    public interface ITokenServices
    {
        public string GenerateToken(PessoaDTO pessoa);
    }
}
