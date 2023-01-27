using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Intefaces.Validadores
{
    public abstract class Validador<T> : IValidador<T>
    {
        public IEnumerable<ValidationFailure>? Erros;
        protected IValidator<T> _fluentValidator;

        protected Validador(IValidator<T> validator) { 
            Erros = new List<ValidationFailure>();
            _fluentValidator = validator;
        }

        protected void ValidaFluent(T obj)
        {
            var result = _fluentValidator.Validate(obj);
            if (!result.IsValid)
            {
                addErro(result.Errors);
            }
        }

        public void ThrowErros()
        {
            throw new ValidationException(Erros);
        }

        public bool HasErros()
        {
            if (Erros == null)
            {
                throw new NullReferenceException();
            }

            return Erros.Count() > 0 ? true : false;
        }

        protected void addErro(string campo, string erro)
        {
            if (Erros == null)
            {
                throw new NullReferenceException();
            }

            Erros = Erros.Append(new ValidationFailure(campo,erro));
        }
        protected void addErro(IEnumerable<ValidationFailure> results)
        {
            if (Erros == null)
            {
                throw new NullReferenceException();
            }

            foreach (var item in results)
            {
                Erros = Erros.Append(item);
            }

        }

        public abstract bool ValidaId(T obj);
        public abstract bool ValidaInsert(T obj);
        public abstract bool ValidaUpdate(T obj);
        public abstract void ValidaInsertAndThrow(T obj);
        public abstract void ValidaUpdateAndThrow(T obj);
    }
}
