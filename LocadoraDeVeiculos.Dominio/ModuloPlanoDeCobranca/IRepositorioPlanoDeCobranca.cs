using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca
{
    public interface IRepositorioPlanoDeCobranca : IRepositorio<PlanoDeCobranca>
    {
        PlanoDeCobranca SelecionarPlanoDeCobrancaPorNome(string nome);
    }
}
