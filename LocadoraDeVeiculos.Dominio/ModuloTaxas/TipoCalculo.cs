using System.ComponentModel;

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
