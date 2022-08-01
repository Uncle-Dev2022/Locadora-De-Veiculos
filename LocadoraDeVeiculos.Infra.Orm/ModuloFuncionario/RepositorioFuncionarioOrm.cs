using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloFuncionário;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloFuncionario
{
    public class RepositorioFuncionarioOrm : RepositorioBaseOrm<Funcionario,
        MapeadorFuncionarioOrm>,IRepositorioFuncionario
    {
        public RepositorioFuncionarioOrm(LocadoraDeVeiculosDbContext db) : base(db)
        {
        }

        public Funcionario SelecionarFuncionarioPorNome(string nome)
        {
            return Dados.FirstOrDefault(x => x.Nome == nome);
        }
        public Funcionario SelecionarFuncionarioPorLogin(string login)
        {
            return Dados.FirstOrDefault(x => x.Login == login);
        }

    }
}
