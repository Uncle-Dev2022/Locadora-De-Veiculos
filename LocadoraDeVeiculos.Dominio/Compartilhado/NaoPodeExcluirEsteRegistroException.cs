using System;

namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public class NaoPodeExcluirEsteRegistroException : Exception
    {
        public NaoPodeExcluirEsteRegistroException(Exception ex) : base("", ex)
        {

        }
    }
}
