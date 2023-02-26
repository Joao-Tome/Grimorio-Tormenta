using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Intefaces.Instancia
{
    public interface IInstancia<X,Y>
    {
        public Y GetInstancia(int id);
        public X GetInstanciaDTO(int id);
        public IEnumerable<Y>? GetInstancias();
        public IEnumerable<Y>? GetInstancias(bool inativos);
        public IEnumerable<Y> GetInstancia(Func<X, bool> func);
        public X Inserir(X instancia);
        public X Alterar(X instancia);
        public void deletar(int id);

    }
}
