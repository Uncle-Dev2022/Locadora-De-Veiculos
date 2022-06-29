using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public enum TipoCliente
    {
        [Description("Pessoa Física")]
        PessoaFisica,

        [Description("Pessoa Juridica")]
        PessoaJuridica,
    }
}
