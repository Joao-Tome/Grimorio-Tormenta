using GrimorioTormenta.Model.DTO;
using GrimorioTormenta.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrimorioTormenta.Intefaces;
using GrimorioTormenta.Intefaces.Conversor;

namespace GrimorioTormenta.Business.Conversor
{
    public class GrupoConversor : IGrupoConversor
    {
        public GrupoDTO Converte(GrupoModel obj)
        {
            GrupoDTO gp = new GrupoDTO() { Id = obj.Id, Nome = obj.Nome };
            return gp;
        }

        public IEnumerable<GrupoDTO>? Converte(IEnumerable<GrupoModel>? obj)
        {
            return (from GrupoModel? gp in obj
                    select Converte(gp)).ToList();
        }
    }
}
