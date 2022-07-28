using System;

namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public class EntidadeBase<T> where T : class
    {
        public Guid Id { get; set; }

        public EntidadeBase()
        {
            Id = Guid.NewGuid();
        }

        public T Clonar()
        {
            return MemberwiseClone() as T;
        }

    }
}
