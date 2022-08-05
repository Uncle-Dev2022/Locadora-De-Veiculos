using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos
{
    public interface IRepositorioGrupoDeVeiculo : IRepositorio<GrupoDeVeiculo>
    {
        GrupoDeVeiculo SelecionarGrupoDeVeiculoPorNome(string nome);
    }
}
