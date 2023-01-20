using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Intefaces.Conversor
{
    public interface IConversor<Y, T>
    {
        public Y ConverteToDTO(T obj);
        public T ConverteToModel(Y obj);
        public IEnumerable<Y>? ConverteToDTOList(IEnumerable<T>? obj);
    }
}
