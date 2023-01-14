using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Intefaces.Conversor
{
    public interface IConversor<Y, T>
    {
        public Y Converte(T obj);
        public IEnumerable<Y>? Converte(IEnumerable<T>? obj);
    }
}
