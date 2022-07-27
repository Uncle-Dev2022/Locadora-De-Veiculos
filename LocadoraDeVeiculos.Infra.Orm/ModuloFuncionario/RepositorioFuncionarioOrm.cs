using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloFuncionario
{
    public class RepositorioFuncionarioOrm : RepositorioBaseOrm<Funcionario,
        MapeadorFuncionarioOrm>
    {
        public RepositorioFuncionarioOrm(LocadoraDeVeiculosDbContext db)
        {
            this.db = db;
            Dados = db.Set<Funcionario>();
        }

        public Funcionario SelecionarFuncionarioPorLogin(string login)
        {
            return Dados.FirstOrDefault(x => x.Login == login);
        }

    }
}
