using GrimorioTormenta.Model.DTO;
using GrimorioTormenta.Model.DTO.Diversos;
using GrimorioTormenta.Model.Models;
using GrimorioTormenta.Model.PostModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Intefaces.Instancia
{
    public interface IPessoaInstancia : IInstancia<PessoaDTO, PessoaViewModel, PessoaModel>
    {
        public IEnumerable<PessoaDTO>? GetInstanciaDTO(Func<PessoaModel, bool>? func);
    }
}
