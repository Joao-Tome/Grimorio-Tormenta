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
using GrimorioTormenta.Model.DTO;
using GrimorioTormenta.Model.Models;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace GrimorioTormenta.Business.Instancia
{

    public class GrupoInstancia : IGrupoInstancia
    {
        private readonly IGrupoRepositorio _rep;
        private readonly IGrupoConversor _convert;
        private readonly IValidator<GrupoDTO> _validator;

        public GrupoInstancia(IGrupoRepositorio rep, IGrupoConversor convert, IValidator<GrupoDTO> validator)
        {
            _rep = rep;
            _convert = convert;
            _validator = validator;
        }

        public GrupoDTO Alterar(GrupoDTO instancia)
        {
            throw new NotImplementedException();
        }

        public void deletar(GrupoDTO instancia)
        {
            _rep.delete(_convert.ConverteToModel(instancia));
        }

        public GrupoDTO GetInstancia(int id)
        {
            GrupoModel? gp = _rep.get(id);
            return _convert.ConverteToDTO(gp);
        }

        public IEnumerable<GrupoDTO> GetInstancia(Func<GrupoDTO, bool> func)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GrupoDTO>? GetInstancias()
        {
            IEnumerable<GrupoModel>? list = _rep.GetAll();
            return _convert.ConverteToDTOList(list);
        }

        public GrupoDTO Inserir(GrupoDTO instancia)
        {
            _validator.ValidateAndThrow(instancia);
    
            GrupoModel model = _convert.ConverteToModel(instancia);

            model = _rep.insert(model);

            return _convert.ConverteToDTO(model);

        }
    }
}
