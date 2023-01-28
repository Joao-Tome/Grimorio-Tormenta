using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Intefaces.Conversor
{
    /// <summary>
    /// Define um Conversor de um Tipo
    /// </summary>
    /// <typeparam name="X">Tipo Model</typeparam>
    /// <typeparam name="Y">Tipo DTO</typeparam>
    /// <typeparam name="Z">Tipo View</typeparam>
    public interface IConversor<X,Y,Z>
    {
        public Y ConverteToDTO(X obj);
        public Y ConverteToDTO(Z obj);
        public X ConverteToModel(Y obj);
        public X ConverteToModel(Z obj);
        public Z ConverteToViewModel(X obj);
        public Z ConverteToViewModel(Y obj);
        public IEnumerable<Y>? ConverteToDTOList(IEnumerable<X>? obj);
        public IEnumerable<Z>? ConverteToViewList(IEnumerable<X>? obj);
        public IEnumerable<Z>? ConverteToViewList(IEnumerable<Y>? obj);
    }
}
