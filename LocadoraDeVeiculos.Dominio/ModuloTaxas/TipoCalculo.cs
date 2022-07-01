using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxas
{
    public enum TipoCalculo
    {
        [Description("Cálculo Diário")]
        Diario,

        [Description("Cálculo Fixo")]
        Fixo,

    }
}
