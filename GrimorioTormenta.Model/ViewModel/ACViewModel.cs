using GrimorioTormenta.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Model.PostModels
{
    public abstract class ACViewModel
    {
        public int Id { get; set; }
        public Status Status{ get; set; }
    }
}
