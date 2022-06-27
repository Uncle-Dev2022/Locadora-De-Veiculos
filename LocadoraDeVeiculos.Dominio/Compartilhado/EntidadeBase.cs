using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public  class EntidadeBase<T> where T : class
    {
        public int Id { get; set; }

        public T Clonar()
        {
            return MemberwiseClone() as T;
        }

    }
}
