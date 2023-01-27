using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Intefaces.Validadores
{
    public interface IValidador<T>
    {
        bool ValidaId(T obj);
        bool ValidaInsert(T obj);
        void ValidaInsertAndThrow(T obj);
        bool ValidaUpdate(T obj);
        void ValidaUpdateAndThrow(T obj);

    }
}
