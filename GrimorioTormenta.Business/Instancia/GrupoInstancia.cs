using System;
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

        public GrupoInstancia(IGrupoRepositorio rep, IGrupoConversor convert, IValidador<GrupoDTO> validator)
        {
            _rep = rep;
            _convert = convert;
            _validator = validator;
        }

        public GrupoDTO Alterar(GrupoDTO instancia)
        {
            _validator.ValidaUpdateAndThrow(instancia);

            GrupoModel model = _convert.ConverteToModel(instancia);

            model = _rep.update(model);

            return _convert.ConverteToDTO(model);
        }

        public void deletar(int id)
        {
            GrupoDTO instancia = GetInstanciaDTO(id);
            _rep.delete(_convert.ConverteToModel(instancia));
        }

        public GrupoDTO GetInstanciaDTO(int id)
        {
            GrupoModel? gp = _rep.get(id);
            return _convert.ConverteToDTO(gp);
        }

        public GrupoViewModel GetInstancia(int id)
        {
            GrupoModel? gp = _rep.get(id);
            return _convert.ConverteToViewModel(gp);
        }

        public IEnumerable<GrupoViewModel> GetInstancia(Func<GrupoDTO, bool> func)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GrupoViewModel>? GetInstancias()
        {
            IEnumerable<GrupoModel>? list = _rep.GetAll();
            return _convert.ConverteToViewList(list);
        }

        public GrupoDTO Inserir(GrupoDTO instancia)
        {
            _validator.ValidaInsertAndThrow(instancia);

            GrupoModel model = _convert.ConverteToModel(instancia);

            model = _rep.insert(model);

            return _convert.ConverteToDTO(model);

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
    }
}
