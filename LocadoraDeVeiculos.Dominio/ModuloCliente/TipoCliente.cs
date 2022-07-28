using System.ComponentModel;

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
