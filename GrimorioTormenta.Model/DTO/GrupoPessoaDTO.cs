using GrimorioTormenta.Model.Enums;
using GrimorioTormenta.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Model.DTO
{
    public class GrupoPessoaDTO : ACDTO
    {
        public GrupoDTO? Grupo { get; set; }
        public PessoaDTO? Pessoa { get; set; }
        public StatusGrupoPessoa StatusGrupoPessoa { get; set; }
    }
}
