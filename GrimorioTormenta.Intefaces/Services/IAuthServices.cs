using GrimorioTormenta.Model.DTO;
using GrimorioTormenta.Model.DTO.Diversos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Intefaces.Services
{
    public interface IAuthServices
    {
        public string Login(LoginDTO obj);
        public PessoaDTO Register(PessoaDTO obj);
    }
}
