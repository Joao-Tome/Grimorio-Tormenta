using GrimorioTormenta.Intefaces.Conversor;
using GrimorioTormenta.Intefaces.Instancia;
using GrimorioTormenta.Intefaces.Repositorio;
using GrimorioTormenta.Model.DTO;
using GrimorioTormenta.Model.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Business.Conversor
{
    public class GrupoPessoaConversor : IGrupoPessoaConversor
    {
        private IGrupoConversor _grupoConversor;
        private IGrupoRepositorio _grupoRepositorio;
        private IPessoaConversor _pessoaConversor;
        private IPessoaRepositorio _pessoaRepositorio;

        public GrupoPessoaConversor(IGrupoConversor grupoConversor, IGrupoRepositorio grupoRepositorio, IPessoaConversor pessoaConversor, IPessoaRepositorio pessoaRepositorio)
        {
            _grupoConversor = grupoConversor;
            _grupoRepositorio = grupoRepositorio;
            _pessoaConversor = pessoaConversor;
            _pessoaRepositorio = pessoaRepositorio;
        }

        public GrupoPessoaDTO ConverteToDTO(GrupoPessoaModel? obj)
        {
            return new GrupoPessoaDTO
            {
                Id = obj.Id,
                Grupo = _grupoConversor.ConverteToDTO(_grupoRepositorio.get(obj.GrupoId)),
                Pessoa = _pessoaConversor.ConverteToDTO(_pessoaRepositorio.get(obj.PessoaId)),
                Status= obj.Status,
                StatusGrupoPessoa = obj.StatusGrupoPessoa
            };
        }

        public GrupoPessoaDTO ConverteToDTO(GrupoPessoaDTO obj)
        {
            return obj;
        }

        public IEnumerable<GrupoPessoaDTO>? ConverteToDTOList(IEnumerable<GrupoPessoaModel>? obj)
        {
            return (from GrupoPessoaDTO? gp in obj
                    select ConverteToDTO(gp)).ToList();
        }

        public GrupoPessoaModel ConverteToModel(GrupoPessoaDTO obj)
        {
            return new GrupoPessoaModel
            {
                Id = obj.Id,
                GrupoId = obj.Grupo.Id,
                PessoaId = obj.Pessoa.Id,
                Status = obj.Status,
                StatusGrupoPessoa = obj.StatusGrupoPessoa
            };
        }

        public IEnumerable<GrupoPessoaDTO>? ConverteToViewList(IEnumerable<GrupoPessoaModel>? obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GrupoPessoaDTO>? ConverteToViewList(IEnumerable<GrupoPessoaDTO>? obj)
        {
            throw new NotImplementedException();
        }

        public GrupoPessoaDTO ConverteToViewModel(GrupoPessoaModel obj)
        {
            throw new NotImplementedException();
        }

        public GrupoPessoaDTO ConverteToViewModel(GrupoPessoaDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
