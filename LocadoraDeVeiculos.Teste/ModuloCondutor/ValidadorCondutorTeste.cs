using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloCondutor
{
    [TestClass]
    public class ValidadorCondutorTeste
    {
        Condutor c1 = new Condutor("thiago","");
        Condutor c2 = new Condutor("Matilda", "aqui", "123.0245.0123-05", "12345678910", "matilda@hotmail.com");
        [TestMethod]
        public void Nome_Condutor_Obrigatorio()
        {
            Condutor
        }
    }
}
