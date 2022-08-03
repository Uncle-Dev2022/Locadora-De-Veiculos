using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloCliente
{
    public class RepositorioClienteOrm : RepositorioBaseOrm<Cliente, MapeadorClienteOrm>, IRepositorioCliente
    {
        public RepositorioClienteOrm(IContextoPersistencia contexto) : base(contexto)
        {
            
        }

        public Cliente SelecionarClientePorNome(string nome)
        {
            return Dados.FirstOrDefault(x => x.Nome == nome);
        }

        public Cliente SelecionarClientePorCPFOuCNPJ(string CPF_CNPJ)
        {
            return Dados.FirstOrDefault(x => x.CPF_CNPJ == CPF_CNPJ);
        }
    }
}
