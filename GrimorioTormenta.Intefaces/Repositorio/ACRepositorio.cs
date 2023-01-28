using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Intefaces.Repositorio
{
    internal abstract class ACRepositorio<T> : IRepositorio<T>
    {
        public void delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T? get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T>? GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T>? Getlist(Func<T, bool> func)
        {
            throw new NotImplementedException();
        }

        public T insert(T entity)
        {
            throw new NotImplementedException();
        }

        public T update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
