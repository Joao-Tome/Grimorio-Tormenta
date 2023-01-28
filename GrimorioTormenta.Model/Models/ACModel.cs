using GrimorioTormenta.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Model.Models
{
    public abstract class ACModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Status Status { get; set; }
    }
}
