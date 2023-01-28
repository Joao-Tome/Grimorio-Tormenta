using GrimorioTormenta.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Model.Models
{
    public class GrupoModel : ACModel
    {
        [Required]
        [MaxLength(50)]
        public string? Nome { get; set; }
        public TiposGrupo Tipo { get; set; }
    }
}
