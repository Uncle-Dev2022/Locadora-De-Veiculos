using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public interface IRepositorioCliente : IRepositorio<Cliente>
    {
        Cliente SelecionarClientePorNome(string nome);

        Cliente SelecionarClientePorCPFOuCNPJ(string CPF_CNPJ);
    }
}
