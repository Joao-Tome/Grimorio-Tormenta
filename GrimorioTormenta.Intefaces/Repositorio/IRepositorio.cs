using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Intefaces.Repositorio
{
    public interface IRepositorio<T>
    {
        public void insert(T entity);
        public void update(T entity);
        public void delete(T entity);
        public T? get(int id);
        public IEnumerable<T>? Getlist(Func<T,bool> func);
        public IEnumerable<T>? GetAll();

    }
}
