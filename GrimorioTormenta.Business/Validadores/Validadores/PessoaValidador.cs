using FluentValidation;
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
    public class PessoaValidador : Validador<PessoaDTO>
    {
        public IPessoaRepositorio _rep{ get; set; }

        public PessoaValidador(IPessoaRepositorio rep, IValidator<PessoaDTO> validator) : base(validator)
        {
            _rep = rep;
        }

        public override bool ValidaId(PessoaDTO obj)
        {
            return _rep.get(obj.Id) is null ? false : true; 
        }

        public override bool ValidaInsert(PessoaDTO obj)
        {
            ValidaFluent(obj);

            if (obj.Id > 0)
            {
                addErro("Id", "Id precisa ser 0");
            }

            return HasErros();
        }

        public override void ValidaInsertAndThrow(PessoaDTO obj)
        {
            if (ValidaInsert(obj))
            {
                ThrowErros();
            }
        }

        public override bool ValidaUpdate(PessoaDTO obj)
        {
            ValidaFluent(obj);

            if (obj.Id == 0)
            {
                addErro("Id", "Id não pode ser 0");
            }

            if (!ValidaId(obj))
            {
                addErro("Id", "Id do grupo não existe");
            }

            return HasErros();
        }

        public override void ValidaUpdateAndThrow(PessoaDTO obj)
        {
            if (ValidaUpdate(obj))
            {
                ThrowErros();
            }
        }
    }
}
