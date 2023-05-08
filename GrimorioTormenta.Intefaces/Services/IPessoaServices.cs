using GrimorioTormenta.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Intefaces.Services
{
    public interface IPessoaServices
    {
        public String GetNickName();
        public String GetEmail();
        public PessoaDTO GetPessoa();
    }
}
