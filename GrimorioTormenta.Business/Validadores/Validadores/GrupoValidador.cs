using FluentValidation;
using GrimorioTormenta.Intefaces.Instancia;
using GrimorioTormenta.Intefaces.Repositorio;
using GrimorioTormenta.Intefaces.Validadores;
using GrimorioTormenta.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Business.Validadores.Validadores
{
    public class GrupoValidador : Validador<GrupoDTO>
    {
        private IGrupoRepositorio _rep;

        public GrupoValidador(IGrupoRepositorio rep, IValidator<GrupoDTO> validator) : base(validator) 
        {
            _rep = rep;
        }

        public override bool ValidaId(GrupoDTO obj)
        {
            return _rep.get(obj.Id) is not null ? true : false;
        }

        public override bool ValidaInsert(GrupoDTO obj)
        {
            ValidaFluent(obj);

            if (obj.Id > 0)
            {
                addErro("Id","Id precisa ser 0");
            }

            return HasErros();
        }

        public override void ValidaInsertAndThrow(GrupoDTO obj)
        {
            if (ValidaInsert(obj))
            {
                ThrowErros();
            }
        }

        public override bool ValidaUpdate(GrupoDTO obj)
        {
            ValidaFluent(obj);

            if (obj.Id == 0)
            {
                addErro("Id","Id não pode ser 0");
            }

            if (!ValidaId(obj))
            {
                addErro("Id", "Id do grupo não existe");
            }

            return HasErros();
        }

        public override void ValidaUpdateAndThrow(GrupoDTO obj)
        {
            if (ValidaUpdate(obj))
            {
                ThrowErros();
            }
        }
    }
}
