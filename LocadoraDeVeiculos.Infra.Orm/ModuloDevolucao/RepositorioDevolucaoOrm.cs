using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloDevolucao
{
    public class RepositorioDevolucaoOrm : RepositorioBaseOrm<Devolucao,
        MapeadorDevolucaoOrm>, IRepositorioDevolucao
    {
        public RepositorioDevolucaoOrm(LocadoraDeVeiculosDbContext db) : base(db)
        {
        }
    }
}
