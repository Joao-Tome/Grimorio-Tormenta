﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Model.Models
{
    public class PessoaModel : ACModel
    {
        public string? NickName { get; set; }
        public string? Email{ get; set; }
        public string? Senha { get; set; }

    }
}