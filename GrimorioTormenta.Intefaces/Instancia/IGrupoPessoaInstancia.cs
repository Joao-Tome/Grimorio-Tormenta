using GrimorioTormenta.Model.DTO;
using GrimorioTormenta.Model.Enums;
using GrimorioTormenta.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Intefaces.Instancia
{
    public interface IGrupoPessoaInstancia : IInstancia<GrupoPessoaDTO, GrupoPessoaModel, GrupoPessoaModel>
    {
        GrupoPessoaDTO AdicionarPessoa(GrupoDTO grupo, PessoaDTO pessoa, StatusGrupoPessoa status = StatusGrupoPessoa.Participante);
    }
}
