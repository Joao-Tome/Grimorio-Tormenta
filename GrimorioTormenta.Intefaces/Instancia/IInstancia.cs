using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Intefaces.Instancia
{
    public interface IInstancia<T>
    {
        public T GetInstancia(int id);
        public IEnumerable<T>? GetInstancias();
        public IEnumerable<T> GetInstancia(Func<T, bool> func);
        public void Inserir(T instancia);
        public void Alterar(T instancia);
        public void deletar(T instancia);

    }
}
