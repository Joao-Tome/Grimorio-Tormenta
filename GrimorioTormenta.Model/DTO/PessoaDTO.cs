using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Model.DTO
{
    public class PessoaDTO : ACDTO
    {
        public string? NickName { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
    }
}
