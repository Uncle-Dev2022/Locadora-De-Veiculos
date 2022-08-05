﻿using System.ComponentModel;

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
