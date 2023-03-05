using GrimorioTormenta.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Model.Models
{
    public class GrupoPessoaModel : ACModel
    {
        [Required]
        public int? GrupoId{ get; set; }
        [Required]
        public int? PessoaId { get; set; }
        [Required]
        public StatusGrupoPessoa StatusGrupoPessoa{ get; set; }
    }
}
