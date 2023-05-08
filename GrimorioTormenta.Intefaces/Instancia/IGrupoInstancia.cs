using GrimorioTormenta.Model.DTO;
using GrimorioTormenta.Model.Models;
using GrimorioTormenta.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Intefaces.Instancia
{
    public interface IGrupoInstancia : IInstancia<GrupoDTO, GrupoViewModel, GrupoModel>
    {
        GrupoDTO EntrarGrupo(int PessoaId, int GrupoId);
    }
}
