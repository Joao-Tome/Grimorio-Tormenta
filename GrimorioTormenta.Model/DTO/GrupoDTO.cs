using GrimorioTormenta.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Model.DTO
{
    public class GrupoDTO : ACDTO
    {
        public string? Nome{ get; set; }
        public TiposGrupo Tipo { get; set;}

    }
}
