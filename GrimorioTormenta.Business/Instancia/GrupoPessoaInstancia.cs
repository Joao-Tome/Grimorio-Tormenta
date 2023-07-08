using GrimorioTormenta.Intefaces.Conversor;
using GrimorioTormenta.Intefaces.Instancia;
using GrimorioTormenta.Intefaces.Repositorio;
using GrimorioTormenta.Model.DTO;
using GrimorioTormenta.Model.Enums;
using GrimorioTormenta.Model.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Business.Instancia
{
    public class GrupoPessoaInstancia : IGrupoPessoaInstancia
    {
        private IGrupoPessoaRepositorio _rep { get; set; }
        private IGrupoPessoaConversor _conversor { get; set; }

        public GrupoPessoaInstancia(IGrupoPessoaRepositorio rep, IGrupoPessoaConversor conversor)
        {
            _rep = rep;
            _conversor= conversor;
        }

        public GrupoPessoaDTO Alterar(GrupoPessoaDTO? instancia)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int? id)
        {
            throw new NotImplementedException();
        }

        public GrupoPessoaModel GetInstancia(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GrupoPessoaDTO> GetInstancia(Func<GrupoPessoaModel, bool>? func)
        {
            IEnumerable<GrupoPessoaModel> list = _rep.Getlist(func);
            return _conversor.ConverteToDTOList(list);

        }

        public GrupoPessoaDTO GetInstanciaDTO(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GrupoPessoaModel>? GetInstancias()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GrupoPessoaModel>? GetInstancias(bool inativos)
        {
            throw new NotImplementedException();
        }

        public GrupoPessoaDTO Inserir(GrupoPessoaDTO? instancia)
        {
            GrupoPessoaModel model = _rep.insert( _conversor.ConverteToModel(instancia));
            return _conversor.ConverteToDTO(model);
        }

        public GrupoPessoaDTO AdicionarPessoa(GrupoDTO grupo, PessoaDTO pessoa, StatusGrupoPessoa status = StatusGrupoPessoa.Participante)
        {
            StatusGrupoPessoa statuspessoa = status;

            if (grupo.Tipo == TiposGrupo.Publico && statuspessoa == StatusGrupoPessoa.Convite)
            {
                statuspessoa = StatusGrupoPessoa.Participante;
            }

            if (grupo.Tipo == TiposGrupo.Privado && statuspessoa == StatusGrupoPessoa.Participante)
            {
                statuspessoa = StatusGrupoPessoa.Convite;
            }

            GrupoPessoaDTO dto = new GrupoPessoaDTO
            {
                Grupo = grupo,
                Pessoa = pessoa,
                StatusGrupoPessoa = statuspessoa,
                Status = Status.Ativo
            };

            return Inserir(dto);
        }
    }
}
