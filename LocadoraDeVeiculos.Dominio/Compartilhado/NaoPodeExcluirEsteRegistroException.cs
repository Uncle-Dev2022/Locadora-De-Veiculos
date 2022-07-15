using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public class NaoPodeExcluirEsteRegistroException : Exception
    {
        public NaoPodeExcluirEsteRegistroException(Exception ex) :base ("",ex)
        {
           
        }
    }
}
