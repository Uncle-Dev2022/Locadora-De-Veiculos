using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxas
{
    public interface IRepositorioTaxa : IRepositorio<Taxa>
    {
        Taxa SelecionarPorDescricao(string descricao);
    }
}
