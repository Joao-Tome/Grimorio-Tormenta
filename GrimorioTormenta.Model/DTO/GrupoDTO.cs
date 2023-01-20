using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Model.DTO
{
    public class GrupoDTO
    {
        public int Id { get; set; }
        [Required]
        public string? Nome{ get; set; }

    }
}
