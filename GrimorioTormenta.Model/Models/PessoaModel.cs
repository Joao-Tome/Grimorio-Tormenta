using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Model.Models
{
    public class PessoaModel : ACModel
    {
        [Required]
        [MaxLength(50)]
        public string? NickName { get; set; }
        [Required]
        [MaxLength(200)]
        public string? Email{ get; set; }
        [Required]
        [MaxLength(500)]
        public string? Senha { get; set; }

    }
}
