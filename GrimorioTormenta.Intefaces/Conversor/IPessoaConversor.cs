using GrimorioTormenta.Model.DTO;
using GrimorioTormenta.Model.Models;
using GrimorioTormenta.Model.PostModels;
using GrimorioTormenta.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Intefaces.Conversor
{
    public interface IPessoaConversor : IConversor<PessoaModel, PessoaDTO, PessoaViewModel>
    {
    }
}
