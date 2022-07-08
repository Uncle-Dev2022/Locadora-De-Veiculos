using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca
{
    public enum TipoPlano
    {
        [Description("Plano Diário")]
        Diario,

        [Description("Plano Livre")]
        Livre,

        [Description("Plano Controlado")]
        Controlado
    }
}
