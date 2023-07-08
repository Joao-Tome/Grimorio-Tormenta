using FluentValidation;
using FluentValidation.Results;
using GrimorioTormenta.Business.Services;
using GrimorioTormenta.Intefaces.Conversor;
using GrimorioTormenta.Intefaces.Instancia;
using GrimorioTormenta.Intefaces.Repositorio;
using GrimorioTormenta.Intefaces.Services;
using GrimorioTormenta.Intefaces.Validadores;
using GrimorioTormenta.Model.DTO;
using GrimorioTormenta.Model.DTO.Diversos;
using GrimorioTormenta.Model.Models;
using GrimorioTormenta.Model.PostModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GrimorioTormenta.Business.Instancia
{
    public class PessoaInstancia : IPessoaInstancia
    {
        private readonly IPessoaRepositorio _rep;
        private readonly IPessoaConversor _convert;
        private readonly IValidador<PessoaDTO> _validator;

        public PessoaInstancia(IPessoaRepositorio rep, IPessoaConversor convert, IValidador<PessoaDTO> validator)
        {
            _rep = rep;
            _convert = convert;
            _validator = validator;
        }

        public PessoaDTO Alterar(PessoaDTO? instancia)
        {
            _validator.ValidaUpdateAndThrow(instancia);

            PessoaModel model = _convert.ConverteToModel(instancia);

            model = _rep.update(model);

            return _convert.ConverteToDTO(model);
        }

        public void Deletar(int? id)
        {
            PessoaDTO instancia = GetInstanciaDTO(id);
            _rep.delete(_convert.ConverteToModel(instancia));
        }
        public PessoaDTO GetInstanciaDTO(int? id)
        {
            PessoaModel? gp = _rep.get(id);
            return _convert.ConverteToDTO(gp);
        }

        public PessoaViewModel GetInstancia(int? id)
        {
            PessoaModel? gp = _rep.get(id);
            return _convert.ConverteToViewModel(gp);
        }

        public IEnumerable<PessoaDTO>? GetInstancia(Func<PessoaModel, bool>? func)
        {
            IEnumerable<PessoaModel>? list = _rep.Getlist(func);
            return _convert.ConverteToDTOList(list);

        }

        public IEnumerable<PessoaDTO>? GetInstanciaDTO(Func<PessoaModel, bool>? func)
        {
            IEnumerable<PessoaModel>? list = _rep.Getlist(func);
            return _convert.ConverteToDTOList(list);
        }

        public IEnumerable<PessoaViewModel>? GetInstancias()
        {
            IEnumerable<PessoaModel>? list = _rep.GetAll();
            return _convert.ConverteToViewList(list);
        }

        public IEnumerable<PessoaViewModel>? GetInstancias(bool inativos)
        {
            if (inativos)
            {
                return GetInstancias();
            }
            else
            {
                IEnumerable<PessoaModel>? list = _rep.Getlist(x => x.Status == Model.Enums.Status.Ativo);
                return _convert.ConverteToViewList(list);
            }

        }

        public PessoaDTO Inserir(PessoaDTO? instancia)
        {
            _validator.ValidaInsertAndThrow(instancia);

            instancia.Senha = BCrypt.Net.BCrypt.HashPassword(instancia.Senha);

            PessoaModel model = _convert.ConverteToModel(instancia);

            model = _rep.insert(model);

            return _convert.ConverteToDTO(model);
        }

    }
}
