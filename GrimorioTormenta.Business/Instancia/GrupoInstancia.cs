using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrimorioTormenta.Intefaces.Conversor;
using GrimorioTormenta.Intefaces.Instancia;
using GrimorioTormenta.Intefaces.Repositorio;
using GrimorioTormenta.Model.DTO;
using GrimorioTormenta.Model.Models;

namespace GrimorioTormenta.Business.Instancia
{

    public class GrupoInstancia : IGrupoInstancia
    {
        IGrupoRepositorio _rep;
        IGrupoConversor _convert;

        public GrupoInstancia(IGrupoRepositorio rep, IGrupoConversor convert)
        {
            _rep = rep;
            _convert = convert;
        }

        public void Alterar(GrupoDTO instancia)
        {
            throw new NotImplementedException();
        }

        public void deletar(GrupoDTO instancia)
        {
            throw new NotImplementedException();
        }

        public GrupoDTO GetInstancia(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GrupoDTO> GetInstancia(Func<GrupoDTO, bool> func)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GrupoDTO>? GetInstancias()
        {
            IEnumerable<GrupoModel>? list = _rep.GetAll();
            return _convert.Converte(list);
        }

        public void Inserir(GrupoDTO instancia)
        {
            throw new NotImplementedException();
        }
    }
}
