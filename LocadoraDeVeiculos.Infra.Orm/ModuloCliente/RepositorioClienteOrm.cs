using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloCliente
{
    public class RepositorioClienteOrm : RepositorioBaseOrm<Cliente,MapeadorClienteOrm>
    {
        public RepositorioClienteOrm(LocadoraDeVeiculosDbContext db)
        {
            this.db = db;
            Dados = db.Set<Cliente>();
        }
    }
}
