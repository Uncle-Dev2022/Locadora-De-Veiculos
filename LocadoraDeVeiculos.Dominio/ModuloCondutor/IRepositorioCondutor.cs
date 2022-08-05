using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public interface IRepositorioCondutor : IRepositorio<Condutor>
    {
        Condutor SelecionarCondutorPorCPF(string cPF);
        Condutor SelecionarCondutorPorNome(string nome);
        Condutor SelecionarCondutorPorCNH(string cNH);
    }
}
