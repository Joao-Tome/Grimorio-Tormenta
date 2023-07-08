using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using GrimorioTormenta.Intefaces.Conversor;
using GrimorioTormenta.Intefaces.Instancia;
using GrimorioTormenta.Intefaces.Repositorio;
using GrimorioTormenta.Intefaces.Validadores;
using GrimorioTormenta.Model.DTO;
using GrimorioTormenta.Model.Enums;
using GrimorioTormenta.Model.Models;
using GrimorioTormenta.Model.ViewModel;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace GrimorioTormenta.Business.Instancia
{

    public class GrupoInstancia : IGrupoInstancia
    {
        private readonly IGrupoRepositorio _rep;
        private readonly IGrupoConversor _convert;
        private readonly IValidador<GrupoDTO> _validator;
        private readonly IPessoaInstancia _pesInst;
        private readonly IGrupoPessoaInstancia _grupopesInst;

        public GrupoInstancia(IGrupoRepositorio rep, IGrupoConversor convert, IValidador<GrupoDTO> validator, IPessoaInstancia pessoaInstancia, IGrupoPessoaInstancia grupoPessoaInstancia)
        {
            _rep = rep;
            _convert = convert;
            _validator = validator;
            _pesInst = pessoaInstancia;
            _grupopesInst = grupoPessoaInstancia;
        }

        public GrupoDTO? Alterar(GrupoDTO? instancia)
        {
            _validator.ValidaUpdateAndThrow(instancia);

            GrupoModel model = _convert.ConverteToModel(instancia);

            model = _rep.update(model);

            return _convert.ConverteToDTO(model);
        }

        public GrupoDTO Alterar(GrupoDTO grupo, PessoaDTO pessoa)
        {
            GrupoPessoaDTO? grupoPessoa = _grupopesInst.GetInstancia(i => i.PessoaId == pessoa.Id && i.GrupoId == grupo.Id).FirstOrDefault();
            if (grupoPessoa is null)
            {
                throw new ValidationException("A pessoa não esta no grupo");
            }
            if(grupoPessoa.StatusGrupoPessoa != StatusGrupoPessoa.Dono)
            {
                throw new ValidationException("A pessoa Não tem direito de atualizar!");
            }
            return Alterar(grupo);

        }

        public void Deletar(int? id)
        {
            GrupoDTO instancia = GetInstanciaDTO(id);
            _rep.delete(_convert.ConverteToModel(instancia));
        }
        public void Deletar(int grupoid, PessoaDTO pessoa)
        {
            GrupoPessoaDTO? grupoPessoa = _grupopesInst.GetInstancia(i => i.PessoaId == pessoa.Id && i.GrupoId == grupoid).FirstOrDefault();
            if (grupoPessoa is null)
            {
                throw new ValidationException("A pessoa não esta no grupo");
            }
            if (grupoPessoa.StatusGrupoPessoa != StatusGrupoPessoa.Dono)
            {
                throw new ValidationException("A pessoa Não tem direito de Deletar!");
            }
            Deletar(grupoid);

        }

        public GrupoDTO GetInstanciaDTO(int? id)
        {
            GrupoModel? gp = _rep.get(id);
            return _convert.ConverteToDTO(gp);
        }

        public GrupoViewModel GetInstancia(int? id)
        {
            GrupoModel? gp = _rep.get(id);
            return _convert.ConverteToViewModel(gp);
        }

        public IEnumerable<GrupoDTO> GetInstancia(Func<GrupoModel, bool>? func)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GrupoViewModel>? GetInstancias()
        {
            IEnumerable<GrupoModel>? list = _rep.GetAll();
            return _convert.ConverteToViewList(list);
        }

        public GrupoDTO Inserir(GrupoDTO? instancia)
        {
            _validator.ValidaInsertAndThrow(instancia);

            GrupoModel model = _convert.ConverteToModel(instancia);

            model = _rep.insert(model);

            return _convert.ConverteToDTO(model);

        }

        public GrupoDTO Inserir(GrupoDTO grupo, PessoaDTO pessoa)
        {
            grupo = Inserir(grupo);
            _grupopesInst.AdicionarPessoa(grupo, pessoa, StatusGrupoPessoa.Dono);
            return grupo;
        }

        public IEnumerable<GrupoViewModel>? GetInstancias(bool inativos)
        {
            if (inativos)
            {
                return GetInstancias();
            }
            else
            {
                IEnumerable<GrupoModel>? list = _rep.Getlist(x => x.Status == Model.Enums.Status.Ativo);
                return _convert.ConverteToViewList(list);
            }
        }

        public GrupoDTO EntrarGrupo(int PessoaId, int GrupoId)
        {
            GrupoDTO grupo = GetInstanciaDTO(GrupoId);
            PessoaDTO pessoa = _pesInst.GetInstanciaDTO(PessoaId);
            _grupopesInst.AdicionarPessoa(grupo, pessoa);
            return grupo;
        }

        public IEnumerable<GrupoDTO> GetAllPessoa(PessoaDTO pessoa)
        {
            IEnumerable<GrupoPessoaDTO> gruposPessoa = _grupopesInst.GetInstancia(i => i.PessoaId == pessoa.Id && i.StatusGrupoPessoa != StatusGrupoPessoa.Convite);

            IEnumerable<GrupoDTO> grupos = GetAllDTOS(gruposPessoa);
            return grupos;
        }

        public IEnumerable<GrupoDTO> GetAllDTOS(IEnumerable<GrupoPessoaDTO> grupoPessoaDTOs)
        {
            List<GrupoDTO> list = new List<GrupoDTO>();

            foreach (GrupoPessoaDTO item in grupoPessoaDTOs)
            {
                list.Add(GetInstanciaDTO(item.Grupo.Id));
            }
            return list;
        }
    }
}
